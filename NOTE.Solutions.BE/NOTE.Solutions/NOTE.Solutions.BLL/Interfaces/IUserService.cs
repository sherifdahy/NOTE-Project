using NOTE.Solutions.BLL.Contracts.User.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Interfaces;
public interface IUserService
{
    Task<Result<IEnumerable<UserResponse>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<BranchResponse>>> GetBranchesAsync(int userId, CancellationToken cancellationToken = default);
}
