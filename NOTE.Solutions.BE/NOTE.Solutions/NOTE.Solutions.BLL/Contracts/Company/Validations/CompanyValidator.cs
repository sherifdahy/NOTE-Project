namespace NOTE.Solutions.BLL.Contracts.Company.Validations;

public class CompanyValidator : AbstractValidator<CompanyRequest>
{
    public CompanyValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Length(3,100);
        RuleFor(x => x.RIN).NotEmpty().Must(x=>x.Length == 9);
    }
}
