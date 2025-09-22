using NOTE.Solutions.BLL.Contracts.Document.Requests;
using NOTE.Solutions.BLL.Contracts.DocumentDetail.Requests;
using NOTE.Solutions.BLL.Contracts.DocumentDetail.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Contracts.Document.Validations;

public class DocumentValidator : AbstractValidator<DocumentRequest>
{
    public DocumentValidator()
    {
        RuleFor(x => x.PaymentMethod)
            .IsInEnum().WithMessage("Invalid payment method.");

        RuleFor(x => x.DocumentTypeId)
            .GreaterThan(0).WithMessage("Document type must be valid.");

        RuleFor(x => x.DocumentDetails)
            .NotEmpty().WithMessage("Document must have at least one detail.");

        RuleFor(x => x.ActiveCodeId)
            .NotEmpty().WithMessage("Active Code required.");

        RuleForEach(x => x.DocumentDetails)
            .SetValidator(new DocumentDetailValidator());
    }
}
