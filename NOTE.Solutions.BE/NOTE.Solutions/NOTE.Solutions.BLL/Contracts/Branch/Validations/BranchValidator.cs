using NOTE.Solutions.BLL.Contracts.Branch.Requests;
using NOTE.Solutions.BLL.Contracts.User.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Contracts.Branch.Validations;

public class BranchValidator : AbstractValidator<BranchRequest>
{
    public BranchValidator()
    {
        RuleFor(x => x.CityId)
            .NotEmpty().WithMessage("City is required.");

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Branch code is required.")
            .MaximumLength(50).WithMessage("Branch code must not exceed 50 characters.");

        RuleFor(x => x.ApplicationUser)
            .NotNull().WithMessage("User information is required.")
            .SetValidator(new UserValidator());
    }
}
