using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.Entities.Abstractions.Consts;
public static class DefaultRoles
{
    public const string Admin = nameof(Admin);
    public const string AdminRoleConcurrencyStamp = "727F7C04-0A04-4012-9AA0-5BDF83C53788";
    public const int AdminRoleId = 1;

    public const string Member = nameof(Member);
    public const string MemberRoleConcurrencyStamp = "10208DE5-8AD0-41E3-BFED-CFD49C46BEDF";
    public const int MemberRoleId= 2;

}
