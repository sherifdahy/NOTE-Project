
//using NOTE.Solutions.Entities.Enums;

//namespace NOTE.Solutions.BLL.Services;
//public class RoleService(IUnitOfWork unitOfWork) : IRoleService
//{
//    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    
   

//    public async Task<Result<RoleResponse>> CreateAsync(RoleRequest request, CancellationToken cancellationToken = default)
//    {
//        if(_unitOfWork.Roles.IsExist(x=>x.Role == request.Role))
//            return Result.Failure<RoleResponse>(RoleErrors.Duplicated);

//        var appRole = request.Adapt<ApplicationRole>();
        
//        await _unitOfWork.Roles.AddAsync(appRole,cancellationToken);
//        await _unitOfWork.SaveAsync(cancellationToken);

//        return Result.Success(appRole.Adapt<RoleResponse>());
//    }

//    public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
//    {
//        if(id <= 0)
//            return Result.Failure(RoleErrors.InvalidId);

//        var appRole = await _unitOfWork.Roles.GetByIdAsync(id,cancellationToken);

//        if(appRole is null)
//            return Result.Failure(RoleErrors.NotFound);

//        _unitOfWork.Roles.Delete(appRole);
//        await _unitOfWork.SaveAsync(cancellationToken);

//        return Result.Success();
//    }

//    public async Task<Result<IEnumerable<RoleResponse>>> GetAllAsync(CancellationToken cancellationToken = default)
//    {
//        var roles = await _unitOfWork.Roles.GetAllAsync(cancellationToken);

//        return Result.Success(roles.Adapt<IEnumerable<RoleResponse>>());
//    }

//    public async Task<Result<RoleResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
//    {
//        if (id <= 0)
//            return Result.Failure<RoleResponse>(RoleErrors.InvalidId);

//        var appRole = await _unitOfWork.Roles.GetByIdAsync(id,cancellationToken);

//        if (appRole is null)
//            return Result.Failure<RoleResponse>(RoleErrors.NotFound);

//        return Result.Success(appRole.Adapt<RoleResponse>());
//    }

//    public async Task<Result> UpdateAsync(int id, RoleRequest request, CancellationToken cancellationToken = default)
//    {
//        if (id <= 0)
//            return Result.Failure<RoleResponse>(RoleErrors.InvalidId);

//        var appRole = await _unitOfWork.Roles.GetByIdAsync(id,cancellationToken);

//        if (appRole is null)
//            return Result.Failure<RoleResponse>(RoleErrors.NotFound);

//        request.Adapt(appRole);

//        _unitOfWork.Roles.Update(appRole);
//        await _unitOfWork.SaveAsync(cancellationToken);

//        return Result.Success();
//    }
   
//}
