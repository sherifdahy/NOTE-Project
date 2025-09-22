using NOTE.Solutions.BLL.Contracts.POS.Requests;
using NOTE.Solutions.BLL.Contracts.POS.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Interfaces;

public interface IPOSService
{
    Task<Result<IEnumerable<POSResponse>>> GetAllAsync(int branchId,CancellationToken cancellationToken = default);
    Task<Result<POSResponse>> GetById(int id, CancellationToken cancellationToken = default);
    Task<Result<POSResponse>> CreateAsync(int branchId,POSRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(int id,int branchId ,POSRequest request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
