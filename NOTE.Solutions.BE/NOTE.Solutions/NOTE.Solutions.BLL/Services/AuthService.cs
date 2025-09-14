using NOTE.Solutions.BLL.Authentication;
using NOTE.Solutions.BLL.Contracts.Auth.Requests;
using NOTE.Solutions.BLL.Contracts.Auth.Responses;
using NOTE.Solutions.Entities.Entities.Company;
using NOTE.Solutions.Entities.Enums;

namespace NOTE.Solutions.BLL.Services;

public class AuthService(IRoleService roleService,IUnitOfWork unitOfWork, IJWTProvider provider) : IAuthService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IJWTProvider _provider = provider;
    private readonly IRoleService _roleService = roleService;
    private readonly string[] _includes = [
        nameof(ApplicationUser.ApplicationRole)
    ];

    public async Task<Result<AuthResponse>> LoginAsync(LoginRequest authRequest,CancellationToken cancellationToken)
    {
        var applicationUser = await _unitOfWork.Users.FindAsync(x=> x.Email == authRequest.Email, _includes,cancellationToken);

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

    public async Task<Result<bool>> RegisterCompanyAsync(RegisterCompanyRequest request, CancellationToken cancellationToken)
    {
        if (_unitOfWork.Companies.IsExist(x => x.RIN == request.RIN))
            return Result.Failure<bool>(CompanyErrors.Duplicated);

        if (_unitOfWork.Users.IsExist(x => x.Email == request.Branch.ApplicationUser.Email))
            return Result.Failure<bool>(AuthErrors.DuplicatedEmail);

        if(!_unitOfWork.ActiveCodes.IsExist(x=>x.Id == request.ActiveCodeId))
            return Result.Failure<bool>(ActiveCodeErrors.NotFound);

        if (!_unitOfWork.Cities.IsExist(x => x.Id == request.Branch.CityId))
            return Result.Failure<bool>(CityErrors.NotFound);


        var company = request.Adapt<Company>();

        var asignReleResult = await _roleService.AssignToRoleAsync(company.Branches.SelectMany(x => x.ApplicationUsers).ToList(),RoleType.Customer);
        
        if (!asignReleResult.IsSuccess)
            return Result.Failure<bool>(asignReleResult.Error);


        await _unitOfWork.Companies.AddAsync(company,cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success<bool>(true);
    }
    
}
