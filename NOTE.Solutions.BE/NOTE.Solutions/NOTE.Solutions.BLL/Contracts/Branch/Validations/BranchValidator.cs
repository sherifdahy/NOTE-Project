using NOTE.Solutions.BLL.Contracts.Branch.Requests;
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
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Code is required.")
            .MaximumLength(10).WithMessage("Code must not exceed 10 characters.");
        RuleFor(x => x.CompanyId)
            .GreaterThan(0).WithMessage("CompanyId must be greater than 0.");
        RuleFor(x => x.CityId)
            .GreaterThan(0).WithMessage("CityId must be greater than 0.");
    }
}
