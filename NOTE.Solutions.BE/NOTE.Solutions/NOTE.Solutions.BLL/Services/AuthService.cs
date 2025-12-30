using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace NOTE.Solutions.BLL.Services;
public class AuthService(IUnitOfWork unit,SignInManager<ApplicationUser> signInManager,UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,IUnitOfWork unitOfWork, IJWTProvider provider) : IAuthService
{
    private readonly IJWTProvider _provider = provider;
    private readonly IUnitOfWork _unitOfWork = unit;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly RoleManager<ApplicationRole> _roleManager = roleManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private readonly int _refreshTokenExpiryDays = 14;
    public async Task<Result<AuthResponse>> GetTokenAsync(LoginRequest authRequest,CancellationToken cancellationToken)
    {
        var applicationUser = _userManager.Users
                                            .Include(w=>w.RefreshTokens)
                                            .Include(s=>s.PermissionOverrides)
                                                .ThenInclude(po => po.RoleClaim)
                                            .FirstOrDefault(x=>x.Email == authRequest.Email);
        
        if(applicationUser is null)
            return Result.Failure<AuthResponse>(UserErrors.InvalidCredentials);

        if (applicationUser.IsDeleted)
            return Result.Failure<AuthResponse>(UserErrors.DisabledUser);

        var checkPasswordResult = await _signInManager
            .PasswordSignInAsync(applicationUser,
            authRequest.Password,
            false,
            true);

        if(checkPasswordResult.Succeeded)
        {
            var roles = await _userManager.GetRolesAsync(applicationUser);

            var permissions = new List<string>();

            foreach (var roleName in roles)
            {
                var role = await _roleManager.FindByNameAsync(roleName);

                if (role is null) continue;

                var rolePermissions = await _roleManager.GetClaimsAsync(role);

                permissions.AddRange(rolePermissions.Select(x => x.Value).Distinct());
            }

            foreach (var over in applicationUser.PermissionOverrides)
            {
                var permissionValue = over.RoleClaim.ClaimValue;

                if (over.IsAllowed)
                {
                    permissions.Add(permissionValue!);
                }
                else
                {
                    permissions.Remove(permissionValue!);
                }
            }

            var result = _provider.GeneratedToken(applicationUser, roles, permissions);

            // token dosn't related to jwt token
            var refreshToken = GenerateRefreshToken();
            var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

            applicationUser.RefreshTokens.Add(new RefreshToken()
            {
                Token = refreshToken,
                ExpiresOn = refreshTokenExpiration,
            });

            await _userManager.UpdateAsync(applicationUser);

            AuthResponse response = new()
            {
                Token = result.token,
                ExpireIn = result.expiresIn,
                RefreshToken = refreshToken,
                RefreshTokenExpiration = refreshTokenExpiration,
            };

            return Result.Success(response);
        }

        var error = checkPasswordResult.IsNotAllowed
            ? UserErrors.EmailNotConfirmed
            : checkPasswordResult.IsLockedOut
            ? UserErrors.LockedUser
            : UserErrors.InvalidCredentials;

        return Result.Failure<AuthResponse>(error);        
    }
    public async Task<Result<AuthResponse>> GetRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default)
    {
        var userId = _provider.ValidateToken(token);

        if(userId is null)
            return Result.Failure<AuthResponse>(UserErrors.InvalidCredentials);

        var applicationUser = await _userManager.FindByIdAsync(userId.ToString()!);

        if (applicationUser is null)
            return Result.Failure<AuthResponse>(UserErrors.InvalidCredentials);

        if (applicationUser.IsDeleted)
            return Result.Failure<AuthResponse>(UserErrors.DisabledUser);

        if (applicationUser.LockoutEnd > DateTime.UtcNow)
            return Result.Failure<AuthResponse>(UserErrors.LockedUser);

        var userRefreshToken = applicationUser.RefreshTokens.SingleOrDefault(x=>x.Token == refreshToken && x.IsActive);

        if (userRefreshToken is null)
            return Result.Failure<AuthResponse>(UserErrors.InvalidRefreshToken);

        userRefreshToken.RevokedOn = DateTime.UtcNow;

        var roles = await _userManager.GetRolesAsync(applicationUser);

        var permissions = new List<string>();

        foreach (var roleName in roles)
        {
            var role = await _roleManager.FindByNameAsync(roleName);

            if (role is null) continue;

            var rolePermissions = await _roleManager.GetClaimsAsync(role);

            permissions.AddRange(rolePermissions.Select(x => x.Value).Distinct());
        }

        foreach (var over in applicationUser.PermissionOverrides)
        {
            var permissionValue = over.RoleClaim.ClaimValue;

            if (over.IsAllowed)
            {
                permissions.Add(permissionValue!);
            }
            else
            {
                permissions.Remove(permissionValue!);
            }
        }

        var result = _provider.GeneratedToken(applicationUser, roles,permissions);

        // token dosn't related to jwt token
        var newRefreshToken = GenerateRefreshToken();
        var newRefreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

        applicationUser.RefreshTokens.Add(new RefreshToken()
        {
            Token = newRefreshToken,
            ExpiresOn = newRefreshTokenExpiration,
        });

        await _userManager.UpdateAsync(applicationUser);

        AuthResponse response = new()
        {
            Token = result.token,
            ExpireIn = result.expiresIn,
            RefreshToken = newRefreshToken,
            RefreshTokenExpiration = newRefreshTokenExpiration,
        };

        return Result.Success(response);
    }
    private static string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }
    public async Task<Result> RevokeAsync(string token, string refreshToken, CancellationToken cancellationToken = default)
    {
        var userId = _provider.ValidateToken(token);

        if (userId is null)
            return Result.Failure(UserErrors.InvalidJwtToken);

        var applicationUser = await _userManager.FindByIdAsync(userId.ToString()!);

        if (applicationUser is null)
            return Result.Failure(UserErrors.InvalidJwtToken);

        var userRefreshToken = applicationUser.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken && x.IsActive);

        if (userRefreshToken is null)
            return Result.Failure(UserErrors.InvalidRefreshToken);

        userRefreshToken.RevokedOn = DateTime.UtcNow;

        await _userManager.UpdateAsync(applicationUser);

        return Result.Success();
    }
}
