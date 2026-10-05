using System;
using System.Collections.Generic;

namespace Harmic.Models;

/// <summary>
/// Bài viết blog (mẹo, công thức, chia sẻ)
/// </summary>
public partial class TbBlog
{
    /// <summary>
    /// Khóa chính, mã bài blog
    /// </summary>
    public int BlogId { get; set; }

    /// <summary>
    /// Tiêu đề / tên hiển thị
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Chuỗi không dấu, nối bằng gạch ngang, dùng làm URL thân thiện (slug). VD: xoai-cat-hoa-loc
    /// </summary>
    public string? Alias { get; set; }

    /// <summary>
    /// Khóa ngoại -&gt; tb_Category: danh mục của bài
    /// </summary>
    public int? CategoryId { get; set; }

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

    /// <summary>
    /// Khóa ngoại -&gt; tb_Account: tác giả bài viết
    /// </summary>
    public int? AccountId { get; set; }

    /// <summary>
    /// Trạng thái: 1 = hiển thị/hoạt động, 0 = ẩn/khóa (xóa mềm)
    /// </summary>
    public bool IsActive { get; set; }

    public virtual TbAccount? Account { get; set; }

    public virtual TbCategory? Category { get; set; }

    public virtual ICollection<TbBlogComment> TbBlogComments { get; set; } = new List<TbBlogComment>();
}
