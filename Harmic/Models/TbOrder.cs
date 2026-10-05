using System;
using System.Collections.Generic;

namespace Harmic.Models;

/// <summary>
/// Đơn đặt hàng (phần đầu đơn: người nhận, tổng tiền, trạng thái)
/// </summary>
public partial class TbOrder
{
    /// <summary>
    /// Khóa chính, mã đơn hàng (nội bộ)
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// Mã đơn hiển thị cho khách, VD DH0001
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// Tên người nhận hàng
    /// </summary>
    public string? CustomerName { get; set; }

    /// <summary>
    /// SĐT người nhận
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Địa chỉ giao hàng
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Tổng tiền đơn = SUM(Price*Quantity) ở tb_OrderDetail
    /// </summary>
    public int? TotalAmount { get; set; }

    /// <summary>
    /// Tổng số lượng sản phẩm trong đơn (tên cột sai chính tả theo đề)
    /// </summary>
    public int? Quanlity { get; set; }

    /// <summary>
    /// Khóa ngoại -&gt; tb_OrderStatus: trạng thái đơn
    /// </summary>
    public int? OrderStatusId { get; set; }

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

    public virtual TbOrderStatus? OrderStatus { get; set; }

    public virtual ICollection<TbOrderDetail> TbOrderDetails { get; set; } = new List<TbOrderDetail>();
}
