using System;
using System.Collections.Generic;

namespace Harmic.Models;

/// <summary>
/// Bình luận của người đọc trên bài blog
/// </summary>
public partial class TbBlogComment
{
    /// <summary>
    /// Khóa chính, mã bình luận
    /// </summary>
    public int CommentId { get; set; }

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
    /// Nội dung bình luận
    /// </summary>
    public string? Detail { get; set; }

    /// <summary>
    /// Khóa ngoại -&gt; tb_Blog: bài được bình luận
    /// </summary>
    public int? BlogId { get; set; }

    /// <summary>
    /// 1 = đã duyệt, hiển thị; 0 = chờ duyệt
    /// </summary>
    public bool IsActive { get; set; }

    public virtual TbBlog? Blog { get; set; }
}
