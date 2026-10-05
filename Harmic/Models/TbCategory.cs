using System;
using System.Collections.Generic;

namespace Harmic.Models;

/// <summary>
/// Danh mục bài viết, dùng chung cho Blog và Tin tức
/// </summary>
public partial class TbCategory
{
    /// <summary>
    /// Khóa chính, mã danh mục bài viết
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Tiêu đề / tên hiển thị
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Chuỗi không dấu, nối bằng gạch ngang, dùng làm URL thân thiện (slug). VD: xoai-cat-hoa-loc
    /// </summary>
    public string? Alias { get; set; }

    /// <summary>
    /// Mô tả ngắn
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Thứ tự sắp xếp khi hiển thị (số nhỏ đứng trước)
    /// </summary>
    public int? Position { get; set; }

    /// <summary>
    /// Thẻ &lt;title&gt; phục vụ SEO
    /// </summary>
    public string? SeoTitle { get; set; }

    /// <summary>
    /// Thẻ meta description phục vụ SEO
    /// </summary>
    public string? SeoDescription { get; set; }

    /// <summary>
    /// Thẻ meta keywords phục vụ SEO
    /// </summary>
    public string? SeoKeywords { get; set; }

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

    public virtual ICollection<TbBlog> TbBlogs { get; set; } = new List<TbBlog>();

    public virtual ICollection<TbNews> TbNews { get; set; } = new List<TbNews>();
}
