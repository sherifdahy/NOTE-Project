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
        RuleFor(x => x.DateTime)
            .NotEmpty().WithMessage("Document date is required.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Document date cannot be in the future.");

        RuleFor(x => x.DocumentNumber)
            .NotEmpty().WithMessage("Document number is required.")
            .MaximumLength(50).WithMessage("Document number must not exceed 50 characters.");

        RuleFor(x => x.BuyerName)
            .NotEmpty().WithMessage("Buyer name is required.")
            .MaximumLength(200).WithMessage("Buyer name must not exceed 200 characters.");

        RuleFor(x => x.BuyerSSN)
            .NotEmpty().WithMessage("Buyer SSN is required.")
            .Matches(@"^\d{14}$").WithMessage("Buyer SSN must be 14 digits.");

        RuleFor(x => x.BuyerType)
            .IsInEnum().WithMessage("Invalid buyer type.");

        RuleFor(x => x.PaymentMethod)
            .IsInEnum().WithMessage("Invalid payment method.");

        RuleFor(x => x.DocumentTypeId)
            .GreaterThan(0).WithMessage("Document type must be valid.");

        RuleFor(x => x.DocumentDetails)
            .NotEmpty().WithMessage("Document must have at least one detail.");

        RuleForEach(x => x.DocumentDetails)
            .SetValidator(new DocumentDetailValidator());
    }
}
