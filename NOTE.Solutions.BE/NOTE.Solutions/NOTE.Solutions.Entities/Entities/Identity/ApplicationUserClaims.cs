using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOTE.Solutions.Entities.Entities.Identity;

public class ApplicationUserClaims : IdentityUserClaim<int>
{
    public bool IsActive { get; set; }
}
