using Microsoft.AspNetCore.Http;
using NOTE.Solutions.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Errors;

public static class RoleErrors
{
    public static readonly Error NotFound
        = new Error("Role.NotFound", "Role is Not Exist.", StatusCodes.Status404NotFound);
    public static readonly Error InvalidId
        = new Error("Role.InvalidId", "Invalid Id.", StatusCodes.Status400BadRequest);
    public static readonly Error Duplicated =
            new("Role.DuplicatedRole", "Role is Already Exist.", StatusCodes.Status409Conflict);
}
