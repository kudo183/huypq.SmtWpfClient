//user tepmlate tag <ModelBuilderConfigEFFull> to generate context class for EF Full, <ModelBuilderConfigEFCore> to generate context class for EF Core.
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace huypq.SmtWpfClientSQL.Demo.Entities
{
    public partial class SqlDbContext : DbContext, IDbContext
    {
        public SqlDbContext() : base(Settings.ConnectionString)
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<rBaiXe>().HasKey(p => p.ID);
            modelBuilder.Entity<rBaiXe>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<rBaiXe>().Property(p => p.DiaDiemBaiXe).IsRequired().HasMaxLength(300);

            modelBuilder.Entity<rCanhBaoTonKho>().HasKey(p => p.ID);
            modelBuilder.Entity<rCanhBaoTonKho>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<rCanhBaoTonKho>().HasRequired(d => d.MaKhoHangNavigation).WithMany(p => p.rCanhBaoTonKhoMaKhoHangNavigation).HasForeignKey(d => d.MaKhoHang).WillCascadeOnDelete(false);
            modelBuilder.Entity<rCanhBaoTonKho>().HasRequired(d => d.MaMatHangNavigation).WithMany(p => p.rCanhBaoTonKhoMaMatHangNavigation).HasForeignKey(d => d.MaMatHang).WillCascadeOnDelete(false);

            modelBuilder.Entity<rChanh>().HasKey(p => p.ID);
            modelBuilder.Entity<rChanh>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<rChanh>().Property(p => p.TenChanh).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<rChanh>().HasRequired(d => d.MaBaiXeNavigation).WithMany(p => p.rChanhMaBaiXeNavigation).HasForeignKey(d => d.MaBaiXe).WillCascadeOnDelete(false);

            modelBuilder.Entity<rDiaDiem>().HasKey(p => p.ID);
            modelBuilder.Entity<rDiaDiem>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<rDiaDiem>().Property(p => p.Tinh).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<rDiaDiem>().HasRequired(d => d.MaNuocNavigation).WithMany(p => p.rDiaDiemMaNuocNavigation).HasForeignKey(d => d.MaNuoc).WillCascadeOnDelete(false);

            modelBuilder.Entity<rKhachHang>().HasKey(p => p.ID);
            modelBuilder.Entity<rKhachHang>().HasIndex(p => p.TenKhachHang).IsUnique();
            modelBuilder.Entity<rKhachHang>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<rKhachHang>().Property(p => p.TenKhachHang).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<rKhachHang>().HasRequired(d => d.MaDiaDiemNavigation).WithMany(p => p.rKhachHangMaDiaDiemNavigation).HasForeignKey(d => d.MaDiaDiem).WillCascadeOnDelete(false);

            modelBuilder.Entity<rKhachHangChanh>().HasKey(p => p.ID);
            modelBuilder.Entity<rKhachHangChanh>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<rKhachHangChanh>().HasRequired(d => d.MaChanhNavigation).WithMany(p => p.rKhachHangChanhMaChanhNavigation).HasForeignKey(d => d.MaChanh).WillCascadeOnDelete(false);
            modelBuilder.Entity<rKhachHangChanh>().HasRequired(d => d.MaKhachHangNavigation).WithMany(p => p.rKhachHangChanhMaKhachHangNavigation).HasForeignKey(d => d.MaKhachHang).WillCascadeOnDelete(false);

            modelBuilder.Entity<rKhoHang>().HasKey(p => p.ID);
            modelBuilder.Entity<rKhoHang>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<rKhoHang>().Property(p => p.TenKho).IsRequired().HasMaxLength(200);

            modelBuilder.Entity<rLoaiChiPhi>().HasKey(p => p.ID);
            modelBuilder.Entity<rLoaiChiPhi>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<rLoaiChiPhi>().Property(p => p.TenLoaiChiPhi).IsRequired().HasMaxLength(200);

            modelBuilder.Entity<rLoaiHang>().HasKey(p => p.ID);
            modelBuilder.Entity<rLoaiHang>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<rLoaiHang>().Property(p => p.TenLoai).IsRequired().HasMaxLength(200);

            modelBuilder.Entity<rLoaiNguyenLieu>().HasKey(p => p.ID);
            modelBuilder.Entity<rLoaiNguyenLieu>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<rLoaiNguyenLieu>().Property(p => p.TenLoai).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<rMatHangNguyenLieu>().HasKey(p => p.ID);
            modelBuilder.Entity<rMatHangNguyenLieu>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<rMatHangNguyenLieu>().HasRequired(d => d.MaNguyenLieuNavigation).WithMany(p => p.rMatHangNguyenLieuMaNguyenLieuNavigation).HasForeignKey(d => d.MaNguyenLieu).WillCascadeOnDelete(false);
            modelBuilder.Entity<rMatHangNguyenLieu>().HasRequired(d => d.MaMatHangNavigation).WithMany(p => p.rMatHangNguyenLieuMaMatHangNavigation).HasForeignKey(d => d.MaMatHang).WillCascadeOnDelete(false);

            modelBuilder.Entity<rNuoc>().HasKey(p => p.ID);
            modelBuilder.Entity<rNuoc>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<rNuoc>().Property(p => p.TenNuoc).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<rNguyenLieu>().HasKey(p => p.ID);
            modelBuilder.Entity<rNguyenLieu>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<rNguyenLieu>().HasRequired(d => d.MaLoaiNguyenLieuNavigation).WithMany(p => p.rNguyenLieuMaLoaiNguyenLieuNavigation).HasForeignKey(d => d.MaLoaiNguyenLieu).WillCascadeOnDelete(false);

            modelBuilder.Entity<rNhaCungCap>().HasKey(p => p.ID);
            modelBuilder.Entity<rNhaCungCap>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<rNhaCungCap>().Property(p => p.TenNhaCungCap).IsRequired().HasMaxLength(200);

            modelBuilder.Entity<rNhanVien>().HasKey(p => p.ID);
            modelBuilder.Entity<rNhanVien>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<rNhanVien>().Property(p => p.TenNhanVien).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<rNhanVien>().HasRequired(d => d.MaPhuongTienNavigation).WithMany(p => p.rNhanVienMaPhuongTienNavigation).HasForeignKey(d => d.MaPhuongTien).WillCascadeOnDelete(false);

            modelBuilder.Entity<rPhuongTien>().HasKey(p => p.ID);
            modelBuilder.Entity<rPhuongTien>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<rPhuongTien>().Property(p => p.TenPhuongTien).IsRequired().HasMaxLength(200);

            modelBuilder.Entity<tCongNoKhachHang>().HasKey(p => p.ID);
            modelBuilder.Entity<tCongNoKhachHang>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<tCongNoKhachHang>().HasRequired(d => d.MaKhachHangNavigation).WithMany(p => p.tCongNoKhachHangMaKhachHangNavigation).HasForeignKey(d => d.MaKhachHang).WillCascadeOnDelete(false);

            modelBuilder.Entity<tChiPhi>().HasKey(p => p.ID);
            modelBuilder.Entity<tChiPhi>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<tChiPhi>().HasRequired(d => d.MaLoaiChiPhiNavigation).WithMany(p => p.tChiPhiMaLoaiChiPhiNavigation).HasForeignKey(d => d.MaLoaiChiPhi).WillCascadeOnDelete(false);
            modelBuilder.Entity<tChiPhi>().HasRequired(d => d.MaNhanVienGiaoHangNavigation).WithMany(p => p.tChiPhiMaNhanVienGiaoHangNavigation).HasForeignKey(d => d.MaNhanVienGiaoHang).WillCascadeOnDelete(false);

            modelBuilder.Entity<tChiTietChuyenHangDonHang>().HasKey(p => p.ID);
            modelBuilder.Entity<tChiTietChuyenHangDonHang>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<tChiTietChuyenHangDonHang>().HasRequired(d => d.MaChiTietDonHangNavigation).WithMany(p => p.tChiTietChuyenHangDonHangMaChiTietDonHangNavigation).HasForeignKey(d => d.MaChiTietDonHang).WillCascadeOnDelete(false);
            modelBuilder.Entity<tChiTietChuyenHangDonHang>().HasRequired(d => d.MaChuyenHangDonHangNavigation).WithMany(p => p.tChiTietChuyenHangDonHangMaChuyenHangDonHangNavigation).HasForeignKey(d => d.MaChuyenHangDonHang).WillCascadeOnDelete(false);

            modelBuilder.Entity<tChiTietChuyenKho>().HasKey(p => p.ID);
            modelBuilder.Entity<tChiTietChuyenKho>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<tChiTietChuyenKho>().HasRequired(d => d.MaChuyenKhoNavigation).WithMany(p => p.tChiTietChuyenKhoMaChuyenKhoNavigation).HasForeignKey(d => d.MaChuyenKho).WillCascadeOnDelete(false);
            modelBuilder.Entity<tChiTietChuyenKho>().HasRequired(d => d.MaMatHangNavigation).WithMany(p => p.tChiTietChuyenKhoMaMatHangNavigation).HasForeignKey(d => d.MaMatHang).WillCascadeOnDelete(false);

            modelBuilder.Entity<tChiTietDonHang>().HasKey(p => p.ID);
            modelBuilder.Entity<tChiTietDonHang>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<tChiTietDonHang>().HasRequired(d => d.MaDonHangNavigation).WithMany(p => p.tChiTietDonHangMaDonHangNavigation).HasForeignKey(d => d.MaDonHang).WillCascadeOnDelete(false);
            modelBuilder.Entity<tChiTietDonHang>().HasRequired(d => d.MaMatHangNavigation).WithMany(p => p.tChiTietDonHangMaMatHangNavigation).HasForeignKey(d => d.MaMatHang).WillCascadeOnDelete(false);

            modelBuilder.Entity<tChiTietNhapHang>().HasKey(p => p.ID);
            modelBuilder.Entity<tChiTietNhapHang>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<tChiTietNhapHang>().HasRequired(d => d.MaNhapHangNavigation).WithMany(p => p.tChiTietNhapHangMaNhapHangNavigation).HasForeignKey(d => d.MaNhapHang).WillCascadeOnDelete(false);
            modelBuilder.Entity<tChiTietNhapHang>().HasRequired(d => d.MaMatHangNavigation).WithMany(p => p.tChiTietNhapHangMaMatHangNavigation).HasForeignKey(d => d.MaMatHang).WillCascadeOnDelete(false);

            modelBuilder.Entity<tChiTietToaHang>().HasKey(p => p.ID);
            modelBuilder.Entity<tChiTietToaHang>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<tChiTietToaHang>().HasRequired(d => d.MaChiTietDonHangNavigation).WithMany(p => p.tChiTietToaHangMaChiTietDonHangNavigation).HasForeignKey(d => d.MaChiTietDonHang).WillCascadeOnDelete(false);
            modelBuilder.Entity<tChiTietToaHang>().HasRequired(d => d.MaToaHangNavigation).WithMany(p => p.tChiTietToaHangMaToaHangNavigation).HasForeignKey(d => d.MaToaHang).WillCascadeOnDelete(false);

            modelBuilder.Entity<tChuyenHang>().HasKey(p => p.ID);
            modelBuilder.Entity<tChuyenHang>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<tChuyenHang>().Property(p => p.Gio).HasColumnType("time").HasPrecision(0);
            modelBuilder.Entity<tChuyenHang>().HasRequired(d => d.MaNhanVienGiaoHangNavigation).WithMany(p => p.tChuyenHangMaNhanVienGiaoHangNavigation).HasForeignKey(d => d.MaNhanVienGiaoHang).WillCascadeOnDelete(false);

            modelBuilder.Entity<tChuyenHangDonHang>().HasKey(p => p.ID);
            modelBuilder.Entity<tChuyenHangDonHang>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<tChuyenHangDonHang>().HasRequired(d => d.MaChuyenHangNavigation).WithMany(p => p.tChuyenHangDonHangMaChuyenHangNavigation).HasForeignKey(d => d.MaChuyenHang).WillCascadeOnDelete(false);
            modelBuilder.Entity<tChuyenHangDonHang>().HasRequired(d => d.MaDonHangNavigation).WithMany(p => p.tChuyenHangDonHangMaDonHangNavigation).HasForeignKey(d => d.MaDonHang).WillCascadeOnDelete(false);

            modelBuilder.Entity<tChuyenKho>().HasKey(p => p.ID);
            modelBuilder.Entity<tChuyenKho>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<tChuyenKho>().HasRequired(d => d.MaKhoHangNhapNavigation).WithMany(p => p.tChuyenKhoMaKhoHangNhapNavigation).HasForeignKey(d => d.MaKhoHangNhap).WillCascadeOnDelete(false);
            modelBuilder.Entity<tChuyenKho>().HasRequired(d => d.MaKhoHangXuatNavigation).WithMany(p => p.tChuyenKhoMaKhoHangXuatNavigation).HasForeignKey(d => d.MaKhoHangXuat).WillCascadeOnDelete(false);
            modelBuilder.Entity<tChuyenKho>().HasRequired(d => d.MaNhanVienNavigation).WithMany(p => p.tChuyenKhoMaNhanVienNavigation).HasForeignKey(d => d.MaNhanVien).WillCascadeOnDelete(false);

            modelBuilder.Entity<tDonHang>().HasKey(p => p.ID);
            modelBuilder.Entity<tDonHang>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<tDonHang>().HasRequired(d => d.MaChanhNavigation).WithMany(p => p.tDonHangMaChanhNavigation).HasForeignKey(d => d.MaChanh).WillCascadeOnDelete(false);
            modelBuilder.Entity<tDonHang>().HasRequired(d => d.MaKhachHangNavigation).WithMany(p => p.tDonHangMaKhachHangNavigation).HasForeignKey(d => d.MaKhachHang).WillCascadeOnDelete(false);
            modelBuilder.Entity<tDonHang>().HasRequired(d => d.MaKhoHangNavigation).WithMany(p => p.tDonHangMaKhoHangNavigation).HasForeignKey(d => d.MaKhoHang).WillCascadeOnDelete(false);

            modelBuilder.Entity<tGiamTruKhachHang>().HasKey(p => p.ID);
            modelBuilder.Entity<tGiamTruKhachHang>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<tGiamTruKhachHang>().Property(p => p.GhiChu).IsRequired().HasMaxLength(300);
            modelBuilder.Entity<tGiamTruKhachHang>().HasRequired(d => d.MaKhachHangNavigation).WithMany(p => p.tGiamTruKhachHangMaKhachHangNavigation).HasForeignKey(d => d.MaKhachHang).WillCascadeOnDelete(false);

            modelBuilder.Entity<tMatHang>().HasKey(p => p.ID);
            modelBuilder.Entity<tMatHang>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<tMatHang>().Property(p => p.TenMatHang).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<tMatHang>().Property(p => p.TenMatHangDayDu).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<tMatHang>().Property(p => p.TenMatHangIn).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<tMatHang>().HasRequired(d => d.MaLoaiNavigation).WithMany(p => p.tMatHangMaLoaiNavigation).HasForeignKey(d => d.MaLoai).WillCascadeOnDelete(false);

            modelBuilder.Entity<tNhanTienKhachHang>().HasKey(p => p.ID);
            modelBuilder.Entity<tNhanTienKhachHang>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<tNhanTienKhachHang>().HasRequired(d => d.MaKhachHangNavigation).WithMany(p => p.tNhanTienKhachHangMaKhachHangNavigation).HasForeignKey(d => d.MaKhachHang).WillCascadeOnDelete(false);

            modelBuilder.Entity<tNhapHang>().HasKey(p => p.ID);
            modelBuilder.Entity<tNhapHang>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<tNhapHang>().HasRequired(d => d.MaKhoHangNavigation).WithMany(p => p.tNhapHangMaKhoHangNavigation).HasForeignKey(d => d.MaKhoHang).WillCascadeOnDelete(false);
            modelBuilder.Entity<tNhapHang>().HasRequired(d => d.MaNhaCungCapNavigation).WithMany(p => p.tNhapHangMaNhaCungCapNavigation).HasForeignKey(d => d.MaNhaCungCap).WillCascadeOnDelete(false);
            modelBuilder.Entity<tNhapHang>().HasRequired(d => d.MaNhanVienNavigation).WithMany(p => p.tNhapHangMaNhanVienNavigation).HasForeignKey(d => d.MaNhanVien).WillCascadeOnDelete(false);

            modelBuilder.Entity<tNhapNguyenLieu>().HasKey(p => p.ID);
            modelBuilder.Entity<tNhapNguyenLieu>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<tNhapNguyenLieu>().HasRequired(d => d.MaNguyenLieuNavigation).WithMany(p => p.tNhapNguyenLieuMaNguyenLieuNavigation).HasForeignKey(d => d.MaNguyenLieu).WillCascadeOnDelete(false);
            modelBuilder.Entity<tNhapNguyenLieu>().HasRequired(d => d.MaNhaCungCapNavigation).WithMany(p => p.tNhapNguyenLieuMaNhaCungCapNavigation).HasForeignKey(d => d.MaNhaCungCap).WillCascadeOnDelete(false);

            modelBuilder.Entity<tPhuThuKhachHang>().HasKey(p => p.ID);
            modelBuilder.Entity<tPhuThuKhachHang>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<tPhuThuKhachHang>().Property(p => p.GhiChu).IsRequired().HasMaxLength(300);
            modelBuilder.Entity<tPhuThuKhachHang>().HasRequired(d => d.MaKhachHangNavigation).WithMany(p => p.tPhuThuKhachHangMaKhachHangNavigation).HasForeignKey(d => d.MaKhachHang).WillCascadeOnDelete(false);

            modelBuilder.Entity<tToaHang>().HasKey(p => p.ID);
            modelBuilder.Entity<tToaHang>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<tToaHang>().HasRequired(d => d.MaKhachHangNavigation).WithMany(p => p.tToaHangMaKhachHangNavigation).HasForeignKey(d => d.MaKhachHang).WillCascadeOnDelete(false);

            modelBuilder.Entity<tTonKho>().HasKey(p => p.ID);
            modelBuilder.Entity<tTonKho>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<tTonKho>().HasRequired(d => d.MaKhoHangNavigation).WithMany(p => p.tTonKhoMaKhoHangNavigation).HasForeignKey(d => d.MaKhoHang).WillCascadeOnDelete(false);
            modelBuilder.Entity<tTonKho>().HasRequired(d => d.MaMatHangNavigation).WithMany(p => p.tTonKhoMaMatHangNavigation).HasForeignKey(d => d.MaMatHang).WillCascadeOnDelete(false);

            modelBuilder.Entity<ThamSoNgay>().HasKey(p => p.ID);
            modelBuilder.Entity<ThamSoNgay>().Property(p => p.ID).HasColumnName("Ma");
            modelBuilder.Entity<ThamSoNgay>().Property(p => p.Ten).IsRequired().HasMaxLength(50);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(DbModelBuilder modelBuilder);

        public DbSet<SmtTable> SmtTable { get; set; }
        public DbSet<SmtDeletedItem> SmtDeletedItem { get; set; }
        public DbSet<SmtTenant> SmtTenant { get; set; }
        public DbSet<SmtUser> SmtUser { get; set; }
        public DbSet<SmtUserClaim> SmtUserClaim { get; set; }
        public DbSet<rBaiXe> rBaiXe { get; set; }
        public DbSet<rCanhBaoTonKho> rCanhBaoTonKho { get; set; }
        public DbSet<rChanh> rChanh { get; set; }
        public DbSet<rDiaDiem> rDiaDiem { get; set; }
        public DbSet<rKhachHang> rKhachHang { get; set; }
        public DbSet<rKhachHangChanh> rKhachHangChanh { get; set; }
        public DbSet<rKhoHang> rKhoHang { get; set; }
        public DbSet<rLoaiChiPhi> rLoaiChiPhi { get; set; }
        public DbSet<rLoaiHang> rLoaiHang { get; set; }
        public DbSet<rLoaiNguyenLieu> rLoaiNguyenLieu { get; set; }
        public DbSet<rMatHangNguyenLieu> rMatHangNguyenLieu { get; set; }
        public DbSet<rNuoc> rNuoc { get; set; }
        public DbSet<rNguyenLieu> rNguyenLieu { get; set; }
        public DbSet<rNhaCungCap> rNhaCungCap { get; set; }
        public DbSet<rNhanVien> rNhanVien { get; set; }
        public DbSet<rPhuongTien> rPhuongTien { get; set; }
        public DbSet<tCongNoKhachHang> tCongNoKhachHang { get; set; }
        public DbSet<tChiPhi> tChiPhi { get; set; }
        public DbSet<tChiTietChuyenHangDonHang> tChiTietChuyenHangDonHang { get; set; }
        public DbSet<tChiTietChuyenKho> tChiTietChuyenKho { get; set; }
        public DbSet<tChiTietDonHang> tChiTietDonHang { get; set; }
        public DbSet<tChiTietNhapHang> tChiTietNhapHang { get; set; }
        public DbSet<tChiTietToaHang> tChiTietToaHang { get; set; }
        public DbSet<tChuyenHang> tChuyenHang { get; set; }
        public DbSet<tChuyenHangDonHang> tChuyenHangDonHang { get; set; }
        public DbSet<tChuyenKho> tChuyenKho { get; set; }
        public DbSet<tDonHang> tDonHang { get; set; }
        public DbSet<tGiamTruKhachHang> tGiamTruKhachHang { get; set; }
        public DbSet<tMatHang> tMatHang { get; set; }
        public DbSet<tNhanTienKhachHang> tNhanTienKhachHang { get; set; }
        public DbSet<tNhapHang> tNhapHang { get; set; }
        public DbSet<tNhapNguyenLieu> tNhapNguyenLieu { get; set; }
        public DbSet<tPhuThuKhachHang> tPhuThuKhachHang { get; set; }
        public DbSet<tToaHang> tToaHang { get; set; }
        public DbSet<tTonKho> tTonKho { get; set; }
        public DbSet<ThamSoNgay> ThamSoNgay { get; set; }
    }
}
