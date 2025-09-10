using NOTE.Solutions.BLL.Contracts.Document.Requests;
using NOTE.Solutions.BLL.Contracts.Document.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Interfaces
{
    public interface IDocumentService
    {
        Task<Result<IEnumerable<DocumentResponse>>> GetAllAsync(int branchId,CancellationToken cancellationToken = default);
        Task<Result<DocumentResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<DocumentResponse>> CreateAsync(DocumentRequest request, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(int id, DocumentRequest request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
