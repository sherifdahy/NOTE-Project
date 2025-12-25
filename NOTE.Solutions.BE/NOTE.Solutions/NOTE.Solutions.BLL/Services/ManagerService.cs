using Microsoft.EntityFrameworkCore;
using NOTE.Solutions.BLL.Contracts.Manager.Requests;
using NOTE.Solutions.BLL.Contracts.Manager.Responses;
using NOTE.Solutions.Entities.Entities.Manager;
using System.Linq.Expressions;

namespace NOTE.Solutions.BLL.Services;

public class ManagerService(IUnitOfWork unitOfWork,UserManager<ApplicationUser> userManager) : IManagerService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<Result<ManagerResponse>> CreateAsync(int companyId, ManagerRequest request, CancellationToken cancellationToken = default)
    {

        if (!_unitOfWork.Companies.IsExist(x=>x.Id == companyId))
            return Result.Failure<ManagerResponse>(CompanyErrors.NotFound);

        if (_unitOfWork.Managers.IsExist(x => (x.ApplicationUser.IdentifierNumber == request.IdentifierNumber) && (x.CompanyId == companyId)))
            return Result.Failure<ManagerResponse>(ManagerErrors.EmailDuplicated);


        var applicationUser = request.Adapt<ApplicationUser>();

        var result = await _userManager.CreateAsync(applicationUser);

        if (result.Succeeded)
        {
            var manager = new Manager()
            {
                CompanyId = companyId,
                ApplicationUser = applicationUser
            };

            await _unitOfWork.Managers.AddAsync(manager, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            return Result.Success<ManagerResponse>(manager.Adapt<ManagerResponse>());
        }
        var error = result.Errors.First();
        return Result.Failure<ManagerResponse>(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
    }

    public async Task<Result> ToggleStatusAsync(int managerId, CancellationToken cancellationToken = default)
    {
        var manager = await _unitOfWork.Managers.FindAsync(x => x.Id == managerId, [x=>x.Include(d=>d.ApplicationUser)], cancellationToken);

        if (manager is null)
            return Result.Failure(ManagerErrors.NotFound);

        manager.ApplicationUser.IsDeleted = !manager.ApplicationUser.IsDeleted;

        await _userManager.UpdateAsync(manager.ApplicationUser);

        return Result.Success();
    }

    public async Task<Result<IEnumerable<ManagerResponse>>> GetAllAsync(int companyId, CancellationToken cancellationToken = default)
    {

        if (_unitOfWork.Companies.IsExist(x => x.Id == companyId) is false)
            return Result.Failure<IEnumerable<ManagerResponse>>(CompanyErrors.NotFound);

        var managers = await _unitOfWork.Managers.FindAllAsync(x => x.CompanyId == companyId, [x => x.Include(d => d.ApplicationUser)], cancellationToken);
        
        return Result.Success(managers.Adapt<IEnumerable<ManagerResponse>>());
    }

    public async Task<Result<ManagerResponse>> GetByIdAsync(int managerId, CancellationToken cancellationToken = default)
    {
        var manager = await _unitOfWork.Managers.FindAsync(x => x.Id == managerId, [x => x.Include(d => d.ApplicationUser)], cancellationToken);

        if (manager is null)
            return Result.Failure<ManagerResponse>(ManagerErrors.NotFound);

        return Result.Success(manager.Adapt<ManagerResponse>());
    }

    public async Task<Result> UpdateAsync(int managerId, ManagerRequest request, CancellationToken cancellationToken = default)
    {
        var manager = await _unitOfWork.Managers.FindAsync(x => x.Id == managerId, null, cancellationToken);

        if (manager is null)
            return Result.Failure<ManagerResponse>(ManagerErrors.NotFound);

        request.Adapt(manager.ApplicationUser);

        var result = await _userManager.UpdateAsync(manager.ApplicationUser);

        if(!result.Succeeded)
        {
            var error = result.Errors.First();
            return Result.Failure(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
        }

        return Result.Success();
    }
}
