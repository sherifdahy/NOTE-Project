using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Errors;

public static class AuthErrors
{
    public static Error DuplicatedEmail => new Error("Auth.DuplicatedEmail", "Email is Already Exist.", StatusCodes.Status401Unauthorized);
    public static Error Unauthorized => new Error("Auth.Unauthorized", "Invalid Email or Password.", StatusCodes.Status401Unauthorized);

}
