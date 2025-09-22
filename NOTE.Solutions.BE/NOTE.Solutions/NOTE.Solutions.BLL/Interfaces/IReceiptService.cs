using NOTE.Solutions.BLL.Contracts.Document.Requests;
using NOTE.Solutions.BLL.Contracts.Document.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Interfaces;

public interface IReceiptService
{
    Task<Result<DocumentResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<DocumentResponse>>> GetAllAsync(int branchId, CancellationToken cancellationToken = default);
    Task<Result<DocumentResponse>> CreateAsync(int branchId, int activeCodeId, int posId, DocumentRequest documentRequest, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
