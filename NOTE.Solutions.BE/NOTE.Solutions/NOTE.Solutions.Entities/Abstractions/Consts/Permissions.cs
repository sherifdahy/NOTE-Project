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

    #region Roles Permissions
    public const string GetRoles = "roles:read";
    public const string CreateRoles = "roles:create";
    public const string UpdateRoles = "roles:update";
    public const string ToggleStatus = "roles:toggleStatus";
    #endregion
    public static IList<string> GetAllPermissions() 
    { 
        return typeof(Permissions).GetFields().Select(x=>x.GetValue(x) as string).ToList()!;
    }
}
