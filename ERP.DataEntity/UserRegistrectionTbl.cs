using System;
using System.Collections.Generic;

namespace ERP.DataEntity;

public partial class UserRegistrectionTbl
{
    public int UserId { get; set; }

    public string Fname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordSalt { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateOnly Dob { get; set; }

    public string? UserName { get; set; }

    public string Mobile { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public int? RoleId { get; set; }

    public bool? IssSub { get; set; }

    public virtual UserRoleTbl? Role { get; set; }
}
