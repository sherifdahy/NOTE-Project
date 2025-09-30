using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.Abstractions.Consts;
public static class Permissions
{
    // property
    public static string Type { get; } = "permissions";


    // fields
    public const string GetBranches = "branches:read";

    public static IList<string> GetAllPermissions() 
    { 
        return typeof(Permissions).GetFields().Select(x=>x.GetValue(x) as string).ToList()!;
    }
}
