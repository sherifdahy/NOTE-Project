using NOTE.Solutions.Entities.Enums;
using System.Security.Cryptography;

namespace NOTE.Solutions.BLL.Services;
public class AuthService(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork, IJWTProvider provider) : IAuthService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IJWTProvider _provider = provider;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly int _refreshTokenExpiryDays = 14;

    public async Task<Result<AuthResponse>> LoginAsync(LoginRequest authRequest,CancellationToken cancellationToken)
    {

        var applicationUser = await _userManager.FindByEmailAsync(authRequest.Email);

        if(applicationUser is null)
            return Result.Failure<AuthResponse>(AuthErrors.Unauthorized);

        var isValidPassword = await _userManager.CheckPasswordAsync(applicationUser, authRequest.Password);

        if(!isValidPassword)
            return Result.Failure<AuthResponse>(AuthErrors.Unauthorized);

        var roles = await _userManager.GetRolesAsync(applicationUser);
        
        var result = _provider.GeneratedToken(applicationUser,roles);


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


    private static string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }

    public async Task<Result<bool>> RegisterCompanyAsync(RegisterCompanyRequest request, CancellationToken cancellationToken)
    {
        if (_unitOfWork.Companies.IsExist(x => x.RIN == request.RIN))
            return Result.Failure<bool>(CompanyErrors.Duplicated);

        var applicationUser = new ApplicationUser()
        {
            Email = request.Manager.Email,
            UserName = request.Manager.Email,
            IdentifierNumber = request.Manager.IdentifierNumber,
            Name = request.Manager.Name,
            PhoneNumber = request.Manager.PhoneNumber,
        };

        var creationResult = await _userManager.CreateAsync(applicationUser,request.Manager.Password);

        if(!creationResult.Succeeded)
        {
            var error = creationResult.Errors.First();
            return Result.Failure<bool>(new Error("Auth.Registration",error.Description,StatusCodes.Status400BadRequest));
        }

        try
        {
            var assignUserToRole = await _userManager.AddToRoleAsync(applicationUser, nameof(RoleType.Manager));

            if (!assignUserToRole.Succeeded)
            {
                var error = assignUserToRole.Errors.First();
                return Result.Failure<bool>(new Error("Auth.Assign To Role", error.Description, StatusCodes.Status400BadRequest));
            }
        }
        catch (Exception)
        {
            await _userManager.DeleteAsync(applicationUser);
            throw;
        }
        
        return Result.Success<bool>(true);
    }
    
}
