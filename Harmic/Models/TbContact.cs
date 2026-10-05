using System;
using System.Collections.Generic;

namespace Harmic.Models;

/// <summary>
/// Tin nhắn khách gửi từ form Liên hệ
/// </summary>
public partial class TbContact
{
    /// <summary>
    /// Khóa chính, mã liên hệ
    /// </summary>
    public int ContactId { get; set; }

    /// <summary>
    /// Họ tên người gửi
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Số điện thoại
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Địa chỉ email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Nội dung khách gửi
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// 0 = chưa đọc, 1 = quản trị đã đọc/xử lý
    /// </summary>
    public int? IsRead { get; set; }

    /// <summary>
    /// Thời điểm tạo bản ghi
    /// </summary>
    public DateTime? CreatedDate { get; set; }

    /// <summary>
    /// Người tạo bản ghi (username)
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// Thời điểm sửa gần nhất
    /// </summary>
    public DateTime? ModifiedDate { get; set; }

    /// <summary>
    /// Người sửa gần nhất
    /// </summary>
    public string? ModifiedBy { get; set; }
}
