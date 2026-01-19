using NOTE.Solutions.Entities.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOTE.Solutions.Entities.Entities.Company;

public class UserCompanies
{
    public int ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; } = default!;
    public int CompanyId { get; set; }
    public Company Company { get; set; } = default!;
}
