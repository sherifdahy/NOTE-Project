using NOTE.Solutions.BLL.Contracts.DocumentType.Requests;
using NOTE.Solutions.BLL.Contracts.DocumentType.Responses;

namespace NOTE.Solutions.BLL.Interfaces;

public interface IDocumentTypeService
{
    Task<Result<IEnumerable<DocumentTypeResponse>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<DocumentTypeResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<DocumentTypeResponse>> CreateAsync(DocumentTypeRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(int id, DocumentTypeRequest request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
