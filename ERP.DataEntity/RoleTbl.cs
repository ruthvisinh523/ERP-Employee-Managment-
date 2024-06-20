using System;
using System.Collections.Generic;

namespace ERP.DataEntity;

public partial class RoleTbl
{
    public int RoleId { get; set; }

    public string? User { get; set; }

    public string? Admin { get; set; }

    public virtual ICollection<UserRegistrectionTbl> UserRegistrectionTbls { get; set; } = new List<UserRegistrectionTbl>();
}
