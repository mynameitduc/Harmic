using System;
using System.Collections.Generic;

namespace Harmic.Models;

/// <summary>
/// Menu điều hướng của website, hỗ trợ menu nhiều cấp
/// </summary>
public partial class TbMenu
{
    /// <summary>
    /// Khóa chính, mã menu
    /// </summary>
    public int MenuId { get; set; }

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
    /// Cấp của menu: 1 = menu gốc, 2 = menu con...
    /// </summary>
    public int? Levels { get; set; }

    /// <summary>
    /// Mã menu cha (MenuId); NULL nếu là menu gốc
    /// </summary>
    public int? ParentId { get; set; }

    /// <summary>
    /// Thứ tự sắp xếp khi hiển thị (số nhỏ đứng trước)
    /// </summary>
    public int? Position { get; set; }

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
    /// Trạng thái: 1 = hiển thị/hoạt động, 0 = ẩn/khóa (xóa mềm)
    /// </summary>
    public bool IsActive { get; set; }
}
