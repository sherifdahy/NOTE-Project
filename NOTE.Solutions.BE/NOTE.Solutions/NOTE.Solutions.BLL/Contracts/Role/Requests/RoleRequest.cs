﻿using NOTE.Solutions.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Contracts.Role.Requests;

public class RoleRequest
{
    public RoleType Role { get; set; }
}
