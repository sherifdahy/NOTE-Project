using NOTE.Solutions.BLL.Contracts.Document.Requests;
using NOTE.Solutions.BLL.Contracts.Document.Responses;

namespace NOTE.Solutions.BLL.Services;

public class DocumentService : IDocumentService
{
    public Task<Result<DocumentResponse>> CreateAsync(DocumentRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result<IEnumerable<DocumentResponse>>> GetAllAsync(int branchId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result<DocumentResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result> UpdateAsync(int id, DocumentRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
