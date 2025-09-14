using NOTE.Solutions.BLL.Contracts.Auth.Requests;
using NOTE.Solutions.Entities.Entities.Company;

namespace NOTE.Solutions.API.ApplicationConfiguration;

public class MapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterCompanyRequest, Company>()
            .Map(dist => dist.Branches, src => new List<Branch>()
            {
                new Branch()
                {
                    CityId = src.Branch.CityId,
                    Code = src.Branch.Code,
                    ApplicationUsers = new List<ApplicationUser>()
                    {
                        new ApplicationUser()
                        {
                            Name = src.Branch.ApplicationUser.Name,
                            SSN = src.Branch.ApplicationUser.SSN,
                            Email = src.Branch.ApplicationUser.Email,
                            Password = src.Branch.ApplicationUser.Password,
                            PhoneNumber = src.Branch.ApplicationUser.PhoneNumber,
                        }
                }
            }});
    }
}
