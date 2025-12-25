using NOTE.Solutions.BLL.Contracts.Employee.Requests;
using NOTE.Solutions.BLL.Contracts.Employee.Responses;
using NOTE.Solutions.BLL.Contracts.Manager.Responses;
using NOTE.Solutions.Entities.Entities.Employee;
using NOTE.Solutions.Entities.Entities.Manager;

namespace NOTE.Solutions.API.ApplicationConfiguration;

public class MapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Company, CompanyDetailResponse>()
            .Map(dest => dest.ActiveCodes, src => src.ActiveCodeCompanies.Select(x => x.ActiveCode));

        config.NewConfig<Employee,EmployeeResponse>()
            .Map(dest=> dest.Email,src=> src.ApplicationUser.Email)
            .Map(dest => dest.Name, src => src.ApplicationUser.Name)
            .Map(dest => dest.PhoneNumber, src => src.ApplicationUser.PhoneNumber)
            .Map(dest=>dest.IdentifierNumber ,src=>src.ApplicationUser.IdentifierNumber);

        config.NewConfig<Manager,ManagerResponse>()
            .Map(dest => dest.Email,src => src.ApplicationUser.Email)
            .Map(dest => dest.Name,src => src.ApplicationUser.Name)
            .Map(dest => dest.PhoneNumber,src=>src.ApplicationUser.PhoneNumber)
            .Map(dest => dest.IdentifierNumber, src => src.ApplicationUser.IdentifierNumber)
            .Map(dest => dest.IsDeleted,src=>src.ApplicationUser.IsDeleted);

    }
}
