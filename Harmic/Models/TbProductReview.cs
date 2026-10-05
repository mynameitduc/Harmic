using System;
using System.Collections.Generic;

namespace Harmic.Models;

/// <summary>
/// Đánh giá, nhận xét của khách về sản phẩm
/// </summary>
public partial class TbProductReview
{
    /// <summary>
    /// Khóa chính, mã đánh giá
    /// </summary>
    public int ProductReviewId { get; set; }

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
    /// Thời điểm tạo bản ghi
    /// </summary>
    public DateTime? CreatedDate { get; set; }

    /// <summary>
    /// Nội dung nhận xét
    /// </summary>
    public string? Detail { get; set; }

    /// <summary>
    /// Số sao đánh giá (1-5)
    /// </summary>
    public int? Star { get; set; }

    /// <summary>
    /// Khóa ngoại -&gt; tb_Product: sản phẩm được đánh giá
    /// </summary>
    public int? ProductId { get; set; }

    /// <summary>
    /// 1 = đã duyệt, hiển thị; 0 = chờ duyệt
    /// </summary>
    public bool IsActive { get; set; }

    public virtual TbProduct? Product { get; set; }
}
