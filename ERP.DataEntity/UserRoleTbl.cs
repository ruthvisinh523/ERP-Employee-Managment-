using System;
using System.Collections.Generic;

namespace ERP.DataEntity;

public partial class UserRoleTbl
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<UserRegistrectionTbl> UserRegistrectionTbls { get; set; } = new List<UserRegistrectionTbl>();
}
