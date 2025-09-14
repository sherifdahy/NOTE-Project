using NOTE.Solutions.BLL.Contracts.Auth.Requests;
using NOTE.Solutions.BLL.Contracts.Branch.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Contracts.Auth.Validations;

public class RegisterCompanyValidator : AbstractValidator<RegisterCompanyRequest>
{
    public RegisterCompanyValidator()
    {
        // Company name
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Company name is required.")
            .MaximumLength(200).WithMessage("Company name must not exceed 200 characters.");

        // RIN
        RuleFor(x => x.RIN)
            .NotEmpty().WithMessage("RIN is required.")
            .Matches(@"^\d{9,15}$").WithMessage("RIN must be numeric and between 9 to 15 digits.");

        // ActiveCodeId
        RuleFor(x => x.ActiveCodeId)
            .NotEmpty().WithMessage("Activation code is required.")
            .GreaterThan(0).WithMessage("Activation code must be greater than zero.");

        // Branch
        RuleFor(x => x.Branch)
            .NotNull().WithMessage("Branch information is required.")
            .SetValidator(new BranchValidator());
    }
}
