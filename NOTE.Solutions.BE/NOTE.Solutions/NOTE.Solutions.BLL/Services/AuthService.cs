using NOTE.Solutions.BLL.Authentication;
using NOTE.Solutions.BLL.Contracts.Auth.Requests;
using NOTE.Solutions.BLL.Contracts.Auth.Responses;

namespace NOTE.Solutions.BLL.Services;

public class AuthService(IUnitOfWork unitOfWork, IJWTProvider provider) : IAuthService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IJWTProvider _provider = provider;

    public async Task<Result<AuthResponse>> LoginAsync(LoginRequest authRequest,CancellationToken cancellationToken)
    {
        var applicationUser = await _unitOfWork.Users.FindAsync(x=> x.Email == authRequest.Email,cancellationToken:cancellationToken);

        if (applicationUser is null)
            return Result.Failure<AuthResponse>(AuthErrors.Unauthorized);

        if(applicationUser.Password != authRequest.Password)
            return Result.Failure<AuthResponse>(AuthErrors.Unauthorized);

        var result = _provider.GeneratedToken(applicationUser);

        AuthResponse response = new()
        {
            Token = result.token,
            ExpireIn = result.expiresIn,
        };

        return Result.Success(response);
    }

    public async Task<Result<AuthResponse>> RegisterAsync(RegisterRequest request,CancellationToken cancellationToken)
    {
        if (_unitOfWork.Users.IsExist(x => x.Email == request.Email)) 
            return Result.Failure<AuthResponse>(AuthErrors.Unauthorized);

        var applicationUser = request.Adapt<ApplicationUser>();

        applicationUser.ApplicationRoleId = 2;

        await _unitOfWork.Users.AddAsync(applicationUser,cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        var result = _provider.GeneratedToken(applicationUser);

        AuthResponse response = new()
        {
            Token = result.token,
            ExpireIn = result.expiresIn,
        };

        return Result.Success(response);
    }
}
