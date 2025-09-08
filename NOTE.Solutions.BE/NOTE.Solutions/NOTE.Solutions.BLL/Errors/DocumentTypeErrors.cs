namespace NOTE.Solutions.BLL.Errors;

public static class DocumentTypeErrors
{
    public static readonly Error Duplicated = new("DocumentType.Duplicated", "The document type already exists.", 400);
    public static readonly Error InvalidId = new("DocumentType.InvalidId", "The provided document type ID is invalid.", 400);
    public static readonly Error NotFound = new("DocumentType.NotFound", "The document type was not found.", 404);
    public static readonly Error InvalidType = new("DocumentType.InvalidType", "Type is required and must not exceed 100 characters.", 400);
    public static readonly Error InvalidVersion = new("DocumentType.InvalidVersion", "Version is required and must not exceed 20 characters.", 400);
}
