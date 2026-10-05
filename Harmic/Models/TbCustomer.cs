using System;
using System.Collections.Generic;

namespace Harmic.Models;

/// <summary>
/// Tài khoản khách hàng mua hàng trên website
/// </summary>
public partial class TbCustomer
{
    /// <summary>
    /// Khóa chính, mã khách hàng
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Tên đăng nhập
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// Mật khẩu (thực tế nên lưu dạng băm, không lưu bản rõ)
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Ngày sinh
    /// </summary>
    public DateTime? Birthday { get; set; }

    /// <summary>
    /// Tên file ảnh đại diện
    /// </summary>
    public string? Avatar { get; set; }

    /// <summary>
    /// Số điện thoại
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Địa chỉ email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Mã khu vực/tỉnh thành (chưa có bảng Location trong đề)
    /// </summary>
    public int? LocationId { get; set; }

    /// <summary>
    /// Thời điểm đăng nhập gần nhất
    /// </summary>
    public DateTime? LastLogin { get; set; }

    /// <summary>
    /// 1 = tài khoản hoạt động, 0 = bị khóa
    /// </summary>
    public bool IsActive { get; set; }
}
