using NOTE.Solutions.BLL.Contracts.Auth.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Contracts.Auth.Validations;

public class RegisterValidator : AbstractValidator<RegisterRequest>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x=>x.SSN).NotEmpty().Length(14);
        RuleFor(x=>x.Name).NotEmpty().Length(3,50);
        RuleFor(x=>x.PhoneNumber).NotEmpty().Length(11);
    }
}
