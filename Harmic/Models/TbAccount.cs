using System;
using System.Collections.Generic;

namespace Harmic.Models;

/// <summary>
/// Tài khoản đăng nhập trang quản trị (admin, biên tập, nhân viên)
/// </summary>
public partial class TbAccount
{
    /// <summary>
    /// Khóa chính, mã tài khoản quản trị
    /// </summary>
    public int AccountId { get; set; }

    /// <summary>
    /// Tên đăng nhập
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// Mật khẩu (thực tế nên lưu dạng băm, không lưu bản rõ)
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Họ tên nhân viên
    /// </summary>
    public string? FullName { get; set; }

    /// <summary>
    /// Số điện thoại
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Địa chỉ email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Khóa ngoại -&gt; tb_Role: vai trò của tài khoản
    /// </summary>
    public int? RoleId { get; set; }

    /// <summary>
    /// Lần đăng nhập gần nhất (đề cho kiểu nchar(10) nên chỉ lưu được yyyy-MM-dd; nên đổi sang datetime)
    /// </summary>
    public string? LastLogin { get; set; }

    /// <summary>
    /// 1 = tài khoản được phép đăng nhập, 0 = bị khóa
    /// </summary>
    public bool IsActive { get; set; }

    public virtual TbRole? Role { get; set; }

    public virtual ICollection<TbBlog> TbBlogs { get; set; } = new List<TbBlog>();
}
