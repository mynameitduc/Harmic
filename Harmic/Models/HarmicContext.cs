using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Harmic.Models;

public partial class HarmicContext : DbContext
{
    public HarmicContext()
    {
    }

    public HarmicContext(DbContextOptions<HarmicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAccount> TbAccounts { get; set; }

    public virtual DbSet<TbBlog> TbBlogs { get; set; }

    public virtual DbSet<TbBlogComment> TbBlogComments { get; set; }

    public virtual DbSet<TbCategory> TbCategories { get; set; }

    public virtual DbSet<TbContact> TbContacts { get; set; }

    public virtual DbSet<TbCustomer> TbCustomers { get; set; }

    public virtual DbSet<TbMenu> TbMenus { get; set; }

    public virtual DbSet<TbNews> TbNews { get; set; }

    public virtual DbSet<TbOrder> TbOrders { get; set; }

    public virtual DbSet<TbOrderDetail> TbOrderDetails { get; set; }

    public virtual DbSet<TbOrderStatus> TbOrderStatuses { get; set; }

    public virtual DbSet<TbProduct> TbProducts { get; set; }

    public virtual DbSet<TbProductCategory> TbProductCategories { get; set; }

    public virtual DbSet<TbProductReview> TbProductReviews { get; set; }

    public virtual DbSet<TbRole> TbRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId);

            entity.ToTable("tb_Account", tb => tb.HasComment("Tài khoản đăng nhập trang quản trị (admin, biên tập, nhân viên)"));

            entity.Property(e => e.AccountId).HasComment("Khóa chính, mã tài khoản quản trị");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasComment("Địa chỉ email");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasComment("Họ tên nhân viên");
            entity.Property(e => e.IsActive)
                .HasComment("1 = tài khoản được phép đăng nhập, 0 = bị khóa")
                .HasDefaultValue(true, "DF_tb_Account_IsActive");
            entity.Property(e => e.LastLogin)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasComment("Lần đăng nhập gần nhất (đề cho kiểu nchar(10) nên chỉ lưu được yyyy-MM-dd; nên đổi sang datetime)");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasComment("Mật khẩu (thực tế nên lưu dạng băm, không lưu bản rõ)");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasComment("Số điện thoại");
            entity.Property(e => e.RoleId).HasComment("Khóa ngoại -> tb_Role: vai trò của tài khoản");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasComment("Tên đăng nhập");

            entity.HasOne(d => d.Role).WithMany(p => p.TbAccounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_tb_Account_tb_Role");
        });

        modelBuilder.Entity<TbBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("tb_Blog", tb => tb.HasComment("Bài viết blog (mẹo, công thức, chia sẻ)"));

            entity.Property(e => e.BlogId).HasComment("Khóa chính, mã bài blog");
            entity.Property(e => e.AccountId).HasComment("Khóa ngoại -> tb_Account: tác giả bài viết");
            entity.Property(e => e.Alias)
                .HasMaxLength(250)
                .HasComment("Chuỗi không dấu, nối bằng gạch ngang, dùng làm URL thân thiện (slug). VD: xoai-cat-hoa-loc");
            entity.Property(e => e.CategoryId).HasComment("Khóa ngoại -> tb_Category: danh mục của bài");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(150)
                .HasComment("Người tạo bản ghi (username)");
            entity.Property(e => e.CreatedDate)
                .HasComment("Thời điểm tạo bản ghi")
                .HasDefaultValueSql("(getdate())", "DF_tb_Blog_CreatedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(4000)
                .HasComment("Mô tả ngắn");
            entity.Property(e => e.Detail).HasComment("Nội dung chi tiết (thường là HTML từ trình soạn thảo)");
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .HasComment("Đường dẫn ảnh đại diện");
            entity.Property(e => e.IsActive)
                .HasComment("Trạng thái: 1 = hiển thị/hoạt động, 0 = ẩn/khóa (xóa mềm)")
                .HasDefaultValue(true, "DF_tb_Blog_IsActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(150)
                .HasComment("Người sửa gần nhất");
            entity.Property(e => e.ModifiedDate)
                .HasComment("Thời điểm sửa gần nhất")
                .HasColumnType("datetime");
            entity.Property(e => e.SeoDescription)
                .HasMaxLength(500)
                .HasComment("Thẻ meta description phục vụ SEO");
            entity.Property(e => e.SeoKeywords)
                .HasMaxLength(250)
                .HasComment("Thẻ meta keywords phục vụ SEO");
            entity.Property(e => e.SeoTitle)
                .HasMaxLength(250)
                .HasComment("Thẻ <title> phục vụ SEO");
            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .HasComment("Tiêu đề / tên hiển thị");

            entity.HasOne(d => d.Account).WithMany(p => p.TbBlogs)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_tb_Blog_tb_Account");

            entity.HasOne(d => d.Category).WithMany(p => p.TbBlogs)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_tb_Blog_tb_Category");
        });

        modelBuilder.Entity<TbBlogComment>(entity =>
        {
            entity.HasKey(e => e.CommentId);

            entity.ToTable("tb_BlogComment", tb => tb.HasComment("Bình luận của người đọc trên bài blog"));

            entity.Property(e => e.CommentId).HasComment("Khóa chính, mã bình luận");
            entity.Property(e => e.BlogId).HasComment("Khóa ngoại -> tb_Blog: bài được bình luận");
            entity.Property(e => e.CreatedDate)
                .HasComment("Thời điểm tạo bản ghi")
                .HasDefaultValueSql("(getdate())", "DF_tb_BlogComment_CreatedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.Detail)
                .HasMaxLength(200)
                .HasComment("Nội dung bình luận");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasComment("Địa chỉ email");
            entity.Property(e => e.IsActive).HasComment("1 = đã duyệt, hiển thị; 0 = chờ duyệt");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("Họ tên người gửi");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasComment("Số điện thoại");

            entity.HasOne(d => d.Blog).WithMany(p => p.TbBlogComments)
                .HasForeignKey(d => d.BlogId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_tb_BlogComment_tb_Blog");
        });

        modelBuilder.Entity<TbCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId);

            entity.ToTable("tb_Category", tb => tb.HasComment("Danh mục bài viết, dùng chung cho Blog và Tin tức"));

            entity.Property(e => e.CategoryId).HasComment("Khóa chính, mã danh mục bài viết");
            entity.Property(e => e.Alias)
                .HasMaxLength(150)
                .HasComment("Chuỗi không dấu, nối bằng gạch ngang, dùng làm URL thân thiện (slug). VD: xoai-cat-hoa-loc");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(150)
                .HasComment("Người tạo bản ghi (username)");
            entity.Property(e => e.CreatedDate)
                .HasComment("Thời điểm tạo bản ghi")
                .HasDefaultValueSql("(getdate())", "DF_tb_Category_CreatedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasComment("Mô tả ngắn");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(150)
                .HasComment("Người sửa gần nhất");
            entity.Property(e => e.ModifiedDate)
                .HasComment("Thời điểm sửa gần nhất")
                .HasColumnType("datetime");
            entity.Property(e => e.Position).HasComment("Thứ tự sắp xếp khi hiển thị (số nhỏ đứng trước)");
            entity.Property(e => e.SeoDescription)
                .HasMaxLength(500)
                .HasComment("Thẻ meta description phục vụ SEO");
            entity.Property(e => e.SeoKeywords)
                .HasMaxLength(250)
                .HasComment("Thẻ meta keywords phục vụ SEO");
            entity.Property(e => e.SeoTitle)
                .HasMaxLength(250)
                .HasComment("Thẻ <title> phục vụ SEO");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .HasComment("Tiêu đề / tên hiển thị");
        });

        modelBuilder.Entity<TbContact>(entity =>
        {
            entity.HasKey(e => e.ContactId);

            entity.ToTable("tb_Contact", tb => tb.HasComment("Tin nhắn khách gửi từ form Liên hệ"));

            entity.Property(e => e.ContactId).HasComment("Khóa chính, mã liên hệ");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(150)
                .HasComment("Người tạo bản ghi (username)");
            entity.Property(e => e.CreatedDate)
                .HasComment("Thời điểm tạo bản ghi")
                .HasDefaultValueSql("(getdate())", "DF_tb_Contact_CreatedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasComment("Địa chỉ email");
            entity.Property(e => e.IsRead)
                .HasComment("0 = chưa đọc, 1 = quản trị đã đọc/xử lý")
                .HasDefaultValue(0, "DF_tb_Contact_IsRead");
            entity.Property(e => e.Message).HasComment("Nội dung khách gửi");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(150)
                .HasComment("Người sửa gần nhất");
            entity.Property(e => e.ModifiedDate)
                .HasComment("Thời điểm sửa gần nhất")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasComment("Họ tên người gửi");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasComment("Số điện thoại");
        });

        modelBuilder.Entity<TbCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.ToTable("tb_Customer", tb => tb.HasComment("Tài khoản khách hàng mua hàng trên website"));

            entity.Property(e => e.CustomerId).HasComment("Khóa chính, mã khách hàng");
            entity.Property(e => e.Avatar)
                .HasMaxLength(50)
                .HasComment("Tên file ảnh đại diện");
            entity.Property(e => e.Birthday)
                .HasComment("Ngày sinh")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasComment("Địa chỉ email");
            entity.Property(e => e.IsActive)
                .HasComment("1 = tài khoản hoạt động, 0 = bị khóa")
                .HasDefaultValue(true, "DF_tb_Customer_IsActive");
            entity.Property(e => e.LastLogin)
                .HasComment("Thời điểm đăng nhập gần nhất")
                .HasColumnType("datetime");
            entity.Property(e => e.LocationId).HasComment("Mã khu vực/tỉnh thành (chưa có bảng Location trong đề)");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasComment("Mật khẩu (thực tế nên lưu dạng băm, không lưu bản rõ)");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasComment("Số điện thoại");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasComment("Tên đăng nhập");
        });

        modelBuilder.Entity<TbMenu>(entity =>
        {
            entity.HasKey(e => e.MenuId);

            entity.ToTable("tb_Menu", tb => tb.HasComment("Menu điều hướng của website, hỗ trợ menu nhiều cấp"));

            entity.Property(e => e.MenuId).HasComment("Khóa chính, mã menu");
            entity.Property(e => e.Alias)
                .HasMaxLength(150)
                .HasComment("Chuỗi không dấu, nối bằng gạch ngang, dùng làm URL thân thiện (slug). VD: xoai-cat-hoa-loc");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(150)
                .HasComment("Người tạo bản ghi (username)");
            entity.Property(e => e.CreatedDate)
                .HasComment("Thời điểm tạo bản ghi")
                .HasDefaultValueSql("(getdate())", "DF_tb_Menu_CreatedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasComment("Mô tả ngắn");
            entity.Property(e => e.IsActive)
                .HasComment("Trạng thái: 1 = hiển thị/hoạt động, 0 = ẩn/khóa (xóa mềm)")
                .HasDefaultValue(true, "DF_tb_Menu_IsActive");
            entity.Property(e => e.Levels).HasComment("Cấp của menu: 1 = menu gốc, 2 = menu con...");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(150)
                .HasComment("Người sửa gần nhất");
            entity.Property(e => e.ModifiedDate)
                .HasComment("Thời điểm sửa gần nhất")
                .HasColumnType("datetime");
            entity.Property(e => e.ParentId).HasComment("Mã menu cha (MenuId); NULL nếu là menu gốc");
            entity.Property(e => e.Position).HasComment("Thứ tự sắp xếp khi hiển thị (số nhỏ đứng trước)");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .HasComment("Tiêu đề / tên hiển thị");
        });

        modelBuilder.Entity<TbNews>(entity =>
        {
            entity.HasKey(e => e.NewsId);

            entity.ToTable("tb_News", tb => tb.HasComment("Tin tức của cửa hàng"));

            entity.Property(e => e.NewsId).HasComment("Khóa chính, mã tin tức");
            entity.Property(e => e.Alias)
                .HasMaxLength(250)
                .HasComment("Chuỗi không dấu, nối bằng gạch ngang, dùng làm URL thân thiện (slug). VD: xoai-cat-hoa-loc");
            entity.Property(e => e.CategoryId).HasComment("Khóa ngoại -> tb_Category: danh mục của tin");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(150)
                .HasComment("Người tạo bản ghi (username)");
            entity.Property(e => e.CreatedDate)
                .HasComment("Thời điểm tạo bản ghi")
                .HasDefaultValueSql("(getdate())", "DF_tb_News_CreatedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(4000)
                .HasComment("Mô tả ngắn");
            entity.Property(e => e.Detail).HasComment("Nội dung chi tiết (thường là HTML từ trình soạn thảo)");
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .HasComment("Đường dẫn ảnh đại diện");
            entity.Property(e => e.IsActive)
                .HasComment("Trạng thái: 1 = hiển thị/hoạt động, 0 = ẩn/khóa (xóa mềm)")
                .HasDefaultValue(true, "DF_tb_News_IsActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(150)
                .HasComment("Người sửa gần nhất");
            entity.Property(e => e.ModifiedDate)
                .HasComment("Thời điểm sửa gần nhất")
                .HasColumnType("datetime");
            entity.Property(e => e.SeoDescription)
                .HasMaxLength(500)
                .HasComment("Thẻ meta description phục vụ SEO");
            entity.Property(e => e.SeoKeywords)
                .HasMaxLength(250)
                .HasComment("Thẻ meta keywords phục vụ SEO");
            entity.Property(e => e.SeoTitle)
                .HasMaxLength(250)
                .HasComment("Thẻ <title> phục vụ SEO");
            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .HasComment("Tiêu đề / tên hiển thị");

            entity.HasOne(d => d.Category).WithMany(p => p.TbNews)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_tb_News_tb_Category");
        });

        modelBuilder.Entity<TbOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.ToTable("tb_Order", tb => tb.HasComment("Đơn đặt hàng (phần đầu đơn: người nhận, tổng tiền, trạng thái)"));

            entity.Property(e => e.OrderId).HasComment("Khóa chính, mã đơn hàng (nội bộ)");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .HasComment("Địa chỉ giao hàng");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasComment("Mã đơn hiển thị cho khách, VD DH0001");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(150)
                .HasComment("Người tạo bản ghi (username)");
            entity.Property(e => e.CreatedDate)
                .HasComment("Thời điểm tạo bản ghi")
                .HasDefaultValueSql("(getdate())", "DF_tb_Order_CreatedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(150)
                .HasComment("Tên người nhận hàng");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(150)
                .HasComment("Người sửa gần nhất");
            entity.Property(e => e.ModifiedDate)
                .HasComment("Thời điểm sửa gần nhất")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderStatusId).HasComment("Khóa ngoại -> tb_OrderStatus: trạng thái đơn");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasComment("SĐT người nhận");
            entity.Property(e => e.Quanlity).HasComment("Tổng số lượng sản phẩm trong đơn (tên cột sai chính tả theo đề)");
            entity.Property(e => e.TotalAmount).HasComment("Tổng tiền đơn = SUM(Price*Quantity) ở tb_OrderDetail");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.TbOrders)
                .HasForeignKey(d => d.OrderStatusId)
                .HasConstraintName("FK_tb_Order_tb_OrderStatus");
        });

        modelBuilder.Entity<TbOrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId);

            entity.ToTable("tb_OrderDetail", tb => tb.HasComment("Chi tiết đơn hàng: mỗi dòng là 1 sản phẩm trong đơn"));

            entity.Property(e => e.OrderDetailId).HasComment("Khóa chính, mã dòng chi tiết");
            entity.Property(e => e.OrderId).HasComment("Khóa ngoại -> tb_Order: thuộc đơn hàng nào");
            entity.Property(e => e.Price)
                .HasComment("Đơn giá TẠI THỜI ĐIỂM mua (lưu lại để giá sản phẩm đổi sau này không ảnh hưởng đơn cũ)")
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductId).HasComment("Khóa ngoại -> tb_Product: sản phẩm được mua");
            entity.Property(e => e.Quantity).HasComment("Số lượng mua");

            entity.HasOne(d => d.Order).WithMany(p => p.TbOrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_tb_OrderDetail_tb_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.TbOrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_tb_OrderDetail_tb_Product");
        });

        modelBuilder.Entity<TbOrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderStatusId);

            entity.ToTable("tb_OrderStatus", tb => tb.HasComment("Danh mục trạng thái đơn hàng"));

            entity.Property(e => e.OrderStatusId).HasComment("Khóa chính, mã trạng thái");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasComment("Giải thích trạng thái");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("Tên trạng thái (Chờ xác nhận, Đang giao...)");
        });

        modelBuilder.Entity<TbProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("tb_Product", tb => tb.HasComment("Sản phẩm hoa quả được bán"));

            entity.Property(e => e.ProductId).HasComment("Khóa chính, mã sản phẩm");
            entity.Property(e => e.Alias)
                .HasMaxLength(250)
                .HasComment("Chuỗi không dấu, nối bằng gạch ngang, dùng làm URL thân thiện (slug). VD: xoai-cat-hoa-loc");
            entity.Property(e => e.CategoryProductId).HasComment("Khóa ngoại -> tb_ProductCategory: danh mục sản phẩm");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(150)
                .HasComment("Người tạo bản ghi (username)");
            entity.Property(e => e.CreatedDate)
                .HasComment("Thời điểm tạo bản ghi")
                .HasDefaultValueSql("(getdate())", "DF_tb_Product_CreatedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(4000)
                .HasComment("Mô tả ngắn");
            entity.Property(e => e.Detail).HasComment("Nội dung chi tiết (thường là HTML từ trình soạn thảo)");
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .HasComment("Đường dẫn ảnh đại diện");
            entity.Property(e => e.IsActive)
                .HasComment("Trạng thái: 1 = hiển thị/hoạt động, 0 = ẩn/khóa (xóa mềm)")
                .HasDefaultValue(true, "DF_tb_Product_IsActive");
            entity.Property(e => e.IsBestSeller).HasComment("1 = sản phẩm bán chạy");
            entity.Property(e => e.IsNew).HasComment("1 = sản phẩm mới (hiện ở mục Hàng mới về)");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(150)
                .HasComment("Người sửa gần nhất");
            entity.Property(e => e.ModifiedDate)
                .HasComment("Thời điểm sửa gần nhất")
                .HasColumnType("datetime");
            entity.Property(e => e.Price).HasComment("Giá gốc (VNĐ)");
            entity.Property(e => e.PriceSale).HasComment("Giá khuyến mãi (VNĐ); NULL = không khuyến mãi");
            entity.Property(e => e.Quantity).HasComment("Tổng số lượng nhập");
            entity.Property(e => e.Star).HasComment("Điểm sao trung bình hiển thị (0-5)");
            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .HasComment("Tiêu đề / tên hiển thị");
            entity.Property(e => e.UnitInStock).HasComment("Số lượng còn tồn kho, giảm khi bán");

            entity.HasOne(d => d.CategoryProduct).WithMany(p => p.TbProducts)
                .HasForeignKey(d => d.CategoryProductId)
                .HasConstraintName("FK_tb_Product_tb_ProductCategory");
        });

        modelBuilder.Entity<TbProductCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryProductId);

            entity.ToTable("tb_ProductCategory", tb => tb.HasComment("Danh mục sản phẩm (nhóm hoa quả)"));

            entity.Property(e => e.CategoryProductId).HasComment("Khóa chính, mã danh mục sản phẩm");
            entity.Property(e => e.Alias)
                .HasMaxLength(150)
                .HasComment("Chuỗi không dấu, nối bằng gạch ngang, dùng làm URL thân thiện (slug). VD: xoai-cat-hoa-loc");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(150)
                .HasComment("Người tạo bản ghi (username)");
            entity.Property(e => e.CreatedDate)
                .HasComment("Thời điểm tạo bản ghi")
                .HasDefaultValueSql("(getdate())", "DF_tb_ProductCategory_CreatedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasComment("Mô tả ngắn");
            entity.Property(e => e.Icon)
                .HasMaxLength(500)
                .HasComment("Đường dẫn icon của danh mục");
            entity.Property(e => e.IsActive)
                .HasComment("Trạng thái: 1 = hiển thị/hoạt động, 0 = ẩn/khóa (xóa mềm)")
                .HasDefaultValue(true, "DF_tb_ProductCategory_IsActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(150)
                .HasComment("Người sửa gần nhất");
            entity.Property(e => e.ModifiedDate)
                .HasComment("Thời điểm sửa gần nhất")
                .HasColumnType("datetime");
            entity.Property(e => e.Position).HasComment("Thứ tự sắp xếp khi hiển thị (số nhỏ đứng trước)");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .HasComment("Tiêu đề / tên hiển thị");
        });

        modelBuilder.Entity<TbProductReview>(entity =>
        {
            entity.HasKey(e => e.ProductReviewId);

            entity.ToTable("tb_ProductReview", tb => tb.HasComment("Đánh giá, nhận xét của khách về sản phẩm"));

            entity.Property(e => e.ProductReviewId).HasComment("Khóa chính, mã đánh giá");
            entity.Property(e => e.CreatedDate)
                .HasComment("Thời điểm tạo bản ghi")
                .HasDefaultValueSql("(getdate())", "DF_tb_ProductReview_CreatedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.Detail)
                .HasMaxLength(200)
                .HasComment("Nội dung nhận xét");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasComment("Địa chỉ email");
            entity.Property(e => e.IsActive).HasComment("1 = đã duyệt, hiển thị; 0 = chờ duyệt");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("Họ tên người gửi");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasComment("Số điện thoại");
            entity.Property(e => e.ProductId).HasComment("Khóa ngoại -> tb_Product: sản phẩm được đánh giá");
            entity.Property(e => e.Star).HasComment("Số sao đánh giá (1-5)");

            entity.HasOne(d => d.Product).WithMany(p => p.TbProductReviews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_tb_ProductReview_tb_Product");
        });

        modelBuilder.Entity<TbRole>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("tb_Role", tb => tb.HasComment("Vai trò/nhóm quyền của tài khoản quản trị"));

            entity.Property(e => e.RoleId).HasComment("Khóa chính, mã vai trò");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasComment("Mô tả quyền hạn của vai trò");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasComment("Tên vai trò (Admin, Editor, Sales)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
