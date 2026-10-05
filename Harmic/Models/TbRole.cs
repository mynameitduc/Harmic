using System;
using System.Collections.Generic;

namespace Harmic.Models;

/// <summary>
/// Vai trò/nhóm quyền của tài khoản quản trị
/// </summary>
public partial class TbRole
{
    /// <summary>
    /// Khóa chính, mã vai trò
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// Tên vai trò (Admin, Editor, Sales)
    /// </summary>
    public string? RoleName { get; set; }

    /// <summary>
    /// Mô tả quyền hạn của vai trò
    /// </summary>
    public string? Description { get; set; }

    public virtual ICollection<TbAccount> TbAccounts { get; set; } = new List<TbAccount>();
}
