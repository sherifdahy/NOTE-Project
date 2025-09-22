using NOTE.Solutions.BLL.Contracts.Document.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Contracts.Document.Validations;

public class DocumentBuyerValidator : AbstractValidator<DocumentBuyerRequest>
{
    public DocumentBuyerValidator()
    {
        RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Buyer name is required.")
                .MaximumLength(200).WithMessage("Buyer name must not exceed 200 characters.");

        RuleFor(x => x.SSN)
                .NotEmpty().WithMessage("Buyer SSN is required.")
                .Matches(@"^\d{14}$").WithMessage("Buyer SSN must be 14 digits.");

        RuleFor(x => x.Type)
                .IsInEnum().WithMessage("Invalid buyer type.");
    }
}
