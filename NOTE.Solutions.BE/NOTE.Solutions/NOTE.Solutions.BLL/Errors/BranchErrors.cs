using Microsoft.AspNetCore.Http;
using NOTE.Solutions.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Errors;

public static class BranchErrors
{
    public static readonly Error NotFound
        = new Error("Branch.NotFound", "Branch is Not Exist.", StatusCodes.Status404NotFound);
    public static readonly Error InvalidId
        = new Error("Branch.InvalidId", "Invalid Id.", StatusCodes.Status400BadRequest);
    public static readonly Error Duplicated =
            new("Branch.Duplicated", "This Branch is Already Exist.", StatusCodes.Status409Conflict);
}
