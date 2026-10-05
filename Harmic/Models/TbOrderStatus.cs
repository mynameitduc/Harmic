using System;
using System.Collections.Generic;

namespace Harmic.Models;

/// <summary>
/// Danh mục trạng thái đơn hàng
/// </summary>
public partial class TbOrderStatus
{
    /// <summary>
    /// Khóa chính, mã trạng thái
    /// </summary>
    public int OrderStatusId { get; set; }

    /// <summary>
    /// Tên trạng thái (Chờ xác nhận, Đang giao...)
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Giải thích trạng thái
    /// </summary>
    public string? Description { get; set; }

    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();
}
