using FluentValidation;
using NOTE.Solutions.BLL.Contracts.Role.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Contracts.Role.Validations;

public class RoleValidator : AbstractValidator<RoleRequest>
{
    public RoleValidator()
    {
        RuleFor(x => x.Name).Length(3,50).NotEmpty();
    }
}
