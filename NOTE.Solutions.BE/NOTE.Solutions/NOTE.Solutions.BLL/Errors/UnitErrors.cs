using Microsoft.AspNetCore.Http;
using NOTE.Solutions.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Errors;

public static class UnitErrors
{
    public static readonly Error NotFound
        = new Error("Unit.NotFound", "Unit is Not Exist.", StatusCodes.Status404NotFound);
    public static readonly Error InvalidId
        = new Error("Unit.InvalidId", "Invalid Id.", StatusCodes.Status400BadRequest);
    public static readonly Error Duplicated =
            new("Unit.Duplicated", "Unit is Already Exist.", StatusCodes.Status409Conflict);
}
