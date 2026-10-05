using System;
using System.Collections.Generic;

namespace Harmic.Models;

/// <summary>
/// Sản phẩm hoa quả được bán
/// </summary>
public partial class TbProduct
{
    /// <summary>
    /// Khóa chính, mã sản phẩm
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Tiêu đề / tên hiển thị
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Chuỗi không dấu, nối bằng gạch ngang, dùng làm URL thân thiện (slug). VD: xoai-cat-hoa-loc
    /// </summary>
    public string? Alias { get; set; }

    /// <summary>
    /// Khóa ngoại -&gt; tb_ProductCategory: danh mục sản phẩm
    /// </summary>
    public int? CategoryProductId { get; set; }

    /// <summary>
    /// Mô tả ngắn
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Nội dung chi tiết (thường là HTML từ trình soạn thảo)
    /// </summary>
    public string? Detail { get; set; }

    /// <summary>
    /// Đường dẫn ảnh đại diện
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    /// Giá gốc (VNĐ)
    /// </summary>
    public int? Price { get; set; }

    /// <summary>
    /// Giá khuyến mãi (VNĐ); NULL = không khuyến mãi
    /// </summary>
    public int? PriceSale { get; set; }

    /// <summary>
    /// Tổng số lượng nhập
    /// </summary>
    public int? Quantity { get; set; }

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

    /// <summary>
    /// 1 = sản phẩm mới (hiện ở mục Hàng mới về)
    /// </summary>
    public bool IsNew { get; set; }

    /// <summary>
    /// 1 = sản phẩm bán chạy
    /// </summary>
    public bool IsBestSeller { get; set; }

    /// <summary>
    /// Số lượng còn tồn kho, giảm khi bán
    /// </summary>
    public int? UnitInStock { get; set; }

    /// <summary>
    /// Trạng thái: 1 = hiển thị/hoạt động, 0 = ẩn/khóa (xóa mềm)
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Điểm sao trung bình hiển thị (0-5)
    /// </summary>
    public int? Star { get; set; }

    public virtual TbProductCategory? CategoryProduct { get; set; }

    public virtual ICollection<TbOrderDetail> TbOrderDetails { get; set; } = new List<TbOrderDetail>();

    public virtual ICollection<TbProductReview> TbProductReviews { get; set; } = new List<TbProductReview>();
}
