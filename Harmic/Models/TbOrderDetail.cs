using System;
using System.Collections.Generic;

namespace Harmic.Models;

/// <summary>
/// Chi tiết đơn hàng: mỗi dòng là 1 sản phẩm trong đơn
/// </summary>
public partial class TbOrderDetail
{
    /// <summary>
    /// Khóa chính, mã dòng chi tiết
    /// </summary>
    public int OrderDetailId { get; set; }

    /// <summary>
    /// Khóa ngoại -&gt; tb_Order: thuộc đơn hàng nào
    /// </summary>
    public int? OrderId { get; set; }

    /// <summary>
    /// Khóa ngoại -&gt; tb_Product: sản phẩm được mua
    /// </summary>
    public int? ProductId { get; set; }

    /// <summary>
    /// Đơn giá TẠI THỜI ĐIỂM mua (lưu lại để giá sản phẩm đổi sau này không ảnh hưởng đơn cũ)
    /// </summary>
    public decimal? Price { get; set; }

    /// <summary>
    /// Số lượng mua
    /// </summary>
    public int? Quantity { get; set; }

    public virtual TbOrder? Order { get; set; }

    public virtual TbProduct? Product { get; set; }
}
