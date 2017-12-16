using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;

namespace huypq.SmtWpfClientSQL.Demo
{
    public static partial class TextManager
    {
        static partial void InitDefaultLanguageDataPartial();

        static readonly Dictionary<string, string> _dic = new Dictionary<string, string>();
        public static string Language;

        static TextManager()
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject()) == true)
            {
                InitDefaultLanguageData();
                return;
            }

            var language = Language;
            if (string.IsNullOrEmpty(language) == true)
            {
                language = Thread.CurrentThread.CurrentUICulture.Name.ToLower();
            }

            var fileName = language + ".txt";
            var di = new System.IO.DirectoryInfo("text");
            var filePath = System.IO.Path.Combine(di.FullName, fileName);
            if (System.IO.File.Exists(fileName) == true)
            {
                foreach (var line in System.IO.File.ReadLines(fileName))
                {
                    var texts = line.Split(new[] { "\t\t" }, System.StringSplitOptions.None);
                    _dic.Add(texts[0], texts[1]);
                }
            }
            else
            {
                InitDefaultLanguageData();
            }
        }

        public static string rBaiXe_ID { get { return GetText(); } }
        public static string rBaiXe_DiaDiemBaiXe { get { return GetText(); } }
        public static string rBaiXe_TenantID { get { return GetText(); } }
        public static string rBaiXe_CreateTime { get { return GetText(); } }
        public static string rBaiXe_LastUpdateTime { get { return GetText(); } }
        public static string rCanhBaoTonKho_ID { get { return GetText(); } }
        public static string rCanhBaoTonKho_MaMatHang { get { return GetText(); } }
        public static string rCanhBaoTonKho_MaKhoHang { get { return GetText(); } }
        public static string rCanhBaoTonKho_TonCaoNhat { get { return GetText(); } }
        public static string rCanhBaoTonKho_TonThapNhat { get { return GetText(); } }
        public static string rCanhBaoTonKho_TenantID { get { return GetText(); } }
        public static string rCanhBaoTonKho_CreateTime { get { return GetText(); } }
        public static string rCanhBaoTonKho_LastUpdateTime { get { return GetText(); } }
        public static string rChanh_ID { get { return GetText(); } }
        public static string rChanh_MaBaiXe { get { return GetText(); } }
        public static string rChanh_TenChanh { get { return GetText(); } }
        public static string rChanh_TenantID { get { return GetText(); } }
        public static string rChanh_CreateTime { get { return GetText(); } }
        public static string rChanh_LastUpdateTime { get { return GetText(); } }
        public static string rDiaDiem_ID { get { return GetText(); } }
        public static string rDiaDiem_MaNuoc { get { return GetText(); } }
        public static string rDiaDiem_Tinh { get { return GetText(); } }
        public static string rDiaDiem_TenantID { get { return GetText(); } }
        public static string rDiaDiem_CreateTime { get { return GetText(); } }
        public static string rDiaDiem_LastUpdateTime { get { return GetText(); } }
        public static string rKhachHang_ID { get { return GetText(); } }
        public static string rKhachHang_MaDiaDiem { get { return GetText(); } }
        public static string rKhachHang_TenKhachHang { get { return GetText(); } }
        public static string rKhachHang_KhachRieng { get { return GetText(); } }
        public static string rKhachHang_TenantID { get { return GetText(); } }
        public static string rKhachHang_CreateTime { get { return GetText(); } }
        public static string rKhachHang_LastUpdateTime { get { return GetText(); } }
        public static string rKhachHangChanh_ID { get { return GetText(); } }
        public static string rKhachHangChanh_MaChanh { get { return GetText(); } }
        public static string rKhachHangChanh_MaKhachHang { get { return GetText(); } }
        public static string rKhachHangChanh_LaMacDinh { get { return GetText(); } }
        public static string rKhachHangChanh_TenantID { get { return GetText(); } }
        public static string rKhachHangChanh_CreateTime { get { return GetText(); } }
        public static string rKhachHangChanh_LastUpdateTime { get { return GetText(); } }
        public static string rKhoHang_ID { get { return GetText(); } }
        public static string rKhoHang_TenKho { get { return GetText(); } }
        public static string rKhoHang_TrangThai { get { return GetText(); } }
        public static string rKhoHang_TenantID { get { return GetText(); } }
        public static string rKhoHang_CreateTime { get { return GetText(); } }
        public static string rKhoHang_LastUpdateTime { get { return GetText(); } }
        public static string rLoaiChiPhi_ID { get { return GetText(); } }
        public static string rLoaiChiPhi_TenLoaiChiPhi { get { return GetText(); } }
        public static string rLoaiChiPhi_TenantID { get { return GetText(); } }
        public static string rLoaiChiPhi_CreateTime { get { return GetText(); } }
        public static string rLoaiChiPhi_LastUpdateTime { get { return GetText(); } }
        public static string rLoaiHang_ID { get { return GetText(); } }
        public static string rLoaiHang_TenLoai { get { return GetText(); } }
        public static string rLoaiHang_HangNhaLam { get { return GetText(); } }
        public static string rLoaiHang_TenantID { get { return GetText(); } }
        public static string rLoaiHang_CreateTime { get { return GetText(); } }
        public static string rLoaiHang_LastUpdateTime { get { return GetText(); } }
        public static string rLoaiNguyenLieu_ID { get { return GetText(); } }
        public static string rLoaiNguyenLieu_TenLoai { get { return GetText(); } }
        public static string rLoaiNguyenLieu_TenantID { get { return GetText(); } }
        public static string rLoaiNguyenLieu_CreateTime { get { return GetText(); } }
        public static string rLoaiNguyenLieu_LastUpdateTime { get { return GetText(); } }
        public static string rMatHangNguyenLieu_ID { get { return GetText(); } }
        public static string rMatHangNguyenLieu_MaMatHang { get { return GetText(); } }
        public static string rMatHangNguyenLieu_MaNguyenLieu { get { return GetText(); } }
        public static string rMatHangNguyenLieu_TenantID { get { return GetText(); } }
        public static string rMatHangNguyenLieu_CreateTime { get { return GetText(); } }
        public static string rMatHangNguyenLieu_LastUpdateTime { get { return GetText(); } }
        public static string rNuoc_ID { get { return GetText(); } }
        public static string rNuoc_TenNuoc { get { return GetText(); } }
        public static string rNuoc_TenantID { get { return GetText(); } }
        public static string rNuoc_CreateTime { get { return GetText(); } }
        public static string rNuoc_LastUpdateTime { get { return GetText(); } }
        public static string rNguyenLieu_ID { get { return GetText(); } }
        public static string rNguyenLieu_MaLoaiNguyenLieu { get { return GetText(); } }
        public static string rNguyenLieu_DuongKinh { get { return GetText(); } }
        public static string rNguyenLieu_TenantID { get { return GetText(); } }
        public static string rNguyenLieu_CreateTime { get { return GetText(); } }
        public static string rNguyenLieu_LastUpdateTime { get { return GetText(); } }
        public static string rNhaCungCap_ID { get { return GetText(); } }
        public static string rNhaCungCap_TenNhaCungCap { get { return GetText(); } }
        public static string rNhaCungCap_TenantID { get { return GetText(); } }
        public static string rNhaCungCap_CreateTime { get { return GetText(); } }
        public static string rNhaCungCap_LastUpdateTime { get { return GetText(); } }
        public static string rNhanVien_ID { get { return GetText(); } }
        public static string rNhanVien_MaPhuongTien { get { return GetText(); } }
        public static string rNhanVien_TenNhanVien { get { return GetText(); } }
        public static string rNhanVien_TenantID { get { return GetText(); } }
        public static string rNhanVien_CreateTime { get { return GetText(); } }
        public static string rNhanVien_LastUpdateTime { get { return GetText(); } }
        public static string rPhuongTien_ID { get { return GetText(); } }
        public static string rPhuongTien_TenPhuongTien { get { return GetText(); } }
        public static string rPhuongTien_TenantID { get { return GetText(); } }
        public static string rPhuongTien_CreateTime { get { return GetText(); } }
        public static string rPhuongTien_LastUpdateTime { get { return GetText(); } }
        public static string tCongNoKhachHang_ID { get { return GetText(); } }
        public static string tCongNoKhachHang_MaKhachHang { get { return GetText(); } }
        public static string tCongNoKhachHang_Ngay { get { return GetText(); } }
        public static string tCongNoKhachHang_SoTien { get { return GetText(); } }
        public static string tCongNoKhachHang_TenantID { get { return GetText(); } }
        public static string tCongNoKhachHang_CreateTime { get { return GetText(); } }
        public static string tCongNoKhachHang_LastUpdateTime { get { return GetText(); } }
        public static string tChiPhi_ID { get { return GetText(); } }
        public static string tChiPhi_MaNhanVienGiaoHang { get { return GetText(); } }
        public static string tChiPhi_MaLoaiChiPhi { get { return GetText(); } }
        public static string tChiPhi_SoTien { get { return GetText(); } }
        public static string tChiPhi_Ngay { get { return GetText(); } }
        public static string tChiPhi_GhiChu { get { return GetText(); } }
        public static string tChiPhi_TenantID { get { return GetText(); } }
        public static string tChiPhi_CreateTime { get { return GetText(); } }
        public static string tChiPhi_LastUpdateTime { get { return GetText(); } }
        public static string tChiTietChuyenHangDonHang_ID { get { return GetText(); } }
        public static string tChiTietChuyenHangDonHang_MaChuyenHangDonHang { get { return GetText(); } }
        public static string tChiTietChuyenHangDonHang_MaChiTietDonHang { get { return GetText(); } }
        public static string tChiTietChuyenHangDonHang_SoLuong { get { return GetText(); } }
        public static string tChiTietChuyenHangDonHang_SoLuongTheoDonHang { get { return GetText(); } }
        public static string tChiTietChuyenHangDonHang_TenantID { get { return GetText(); } }
        public static string tChiTietChuyenHangDonHang_CreateTime { get { return GetText(); } }
        public static string tChiTietChuyenHangDonHang_LastUpdateTime { get { return GetText(); } }
        public static string tChiTietChuyenKho_ID { get { return GetText(); } }
        public static string tChiTietChuyenKho_MaChuyenKho { get { return GetText(); } }
        public static string tChiTietChuyenKho_MaMatHang { get { return GetText(); } }
        public static string tChiTietChuyenKho_SoLuong { get { return GetText(); } }
        public static string tChiTietChuyenKho_TenantID { get { return GetText(); } }
        public static string tChiTietChuyenKho_CreateTime { get { return GetText(); } }
        public static string tChiTietChuyenKho_LastUpdateTime { get { return GetText(); } }
        public static string tChiTietDonHang_ID { get { return GetText(); } }
        public static string tChiTietDonHang_MaDonHang { get { return GetText(); } }
        public static string tChiTietDonHang_MaMatHang { get { return GetText(); } }
        public static string tChiTietDonHang_SoLuong { get { return GetText(); } }
        public static string tChiTietDonHang_Xong { get { return GetText(); } }
        public static string tChiTietDonHang_TenantID { get { return GetText(); } }
        public static string tChiTietDonHang_CreateTime { get { return GetText(); } }
        public static string tChiTietDonHang_LastUpdateTime { get { return GetText(); } }
        public static string tChiTietNhapHang_ID { get { return GetText(); } }
        public static string tChiTietNhapHang_MaNhapHang { get { return GetText(); } }
        public static string tChiTietNhapHang_MaMatHang { get { return GetText(); } }
        public static string tChiTietNhapHang_SoLuong { get { return GetText(); } }
        public static string tChiTietNhapHang_TenantID { get { return GetText(); } }
        public static string tChiTietNhapHang_CreateTime { get { return GetText(); } }
        public static string tChiTietNhapHang_LastUpdateTime { get { return GetText(); } }
        public static string tChiTietToaHang_ID { get { return GetText(); } }
        public static string tChiTietToaHang_MaToaHang { get { return GetText(); } }
        public static string tChiTietToaHang_MaChiTietDonHang { get { return GetText(); } }
        public static string tChiTietToaHang_GiaTien { get { return GetText(); } }
        public static string tChiTietToaHang_TenantID { get { return GetText(); } }
        public static string tChiTietToaHang_CreateTime { get { return GetText(); } }
        public static string tChiTietToaHang_LastUpdateTime { get { return GetText(); } }
        public static string tChuyenHang_ID { get { return GetText(); } }
        public static string tChuyenHang_MaNhanVienGiaoHang { get { return GetText(); } }
        public static string tChuyenHang_Ngay { get { return GetText(); } }
        public static string tChuyenHang_Gio { get { return GetText(); } }
        public static string tChuyenHang_TongDonHang { get { return GetText(); } }
        public static string tChuyenHang_TongSoLuongTheoDonHang { get { return GetText(); } }
        public static string tChuyenHang_TongSoLuongThucTe { get { return GetText(); } }
        public static string tChuyenHang_TenantID { get { return GetText(); } }
        public static string tChuyenHang_CreateTime { get { return GetText(); } }
        public static string tChuyenHang_LastUpdateTime { get { return GetText(); } }
        public static string tChuyenHangDonHang_ID { get { return GetText(); } }
        public static string tChuyenHangDonHang_MaChuyenHang { get { return GetText(); } }
        public static string tChuyenHangDonHang_MaDonHang { get { return GetText(); } }
        public static string tChuyenHangDonHang_TongSoLuongTheoDonHang { get { return GetText(); } }
        public static string tChuyenHangDonHang_TongSoLuongThucTe { get { return GetText(); } }
        public static string tChuyenHangDonHang_TenantID { get { return GetText(); } }
        public static string tChuyenHangDonHang_CreateTime { get { return GetText(); } }
        public static string tChuyenHangDonHang_LastUpdateTime { get { return GetText(); } }
        public static string tChuyenKho_ID { get { return GetText(); } }
        public static string tChuyenKho_MaNhanVien { get { return GetText(); } }
        public static string tChuyenKho_MaKhoHangXuat { get { return GetText(); } }
        public static string tChuyenKho_MaKhoHangNhap { get { return GetText(); } }
        public static string tChuyenKho_Ngay { get { return GetText(); } }
        public static string tChuyenKho_TenantID { get { return GetText(); } }
        public static string tChuyenKho_CreateTime { get { return GetText(); } }
        public static string tChuyenKho_LastUpdateTime { get { return GetText(); } }
        public static string tDonHang_ID { get { return GetText(); } }
        public static string tDonHang_MaKhachHang { get { return GetText(); } }
        public static string tDonHang_MaChanh { get { return GetText(); } }
        public static string tDonHang_Ngay { get { return GetText(); } }
        public static string tDonHang_Xong { get { return GetText(); } }
        public static string tDonHang_MaKhoHang { get { return GetText(); } }
        public static string tDonHang_TongSoLuong { get { return GetText(); } }
        public static string tDonHang_TenantID { get { return GetText(); } }
        public static string tDonHang_CreateTime { get { return GetText(); } }
        public static string tDonHang_LastUpdateTime { get { return GetText(); } }
        public static string tGiamTruKhachHang_ID { get { return GetText(); } }
        public static string tGiamTruKhachHang_MaKhachHang { get { return GetText(); } }
        public static string tGiamTruKhachHang_Ngay { get { return GetText(); } }
        public static string tGiamTruKhachHang_SoTien { get { return GetText(); } }
        public static string tGiamTruKhachHang_GhiChu { get { return GetText(); } }
        public static string tGiamTruKhachHang_TenantID { get { return GetText(); } }
        public static string tGiamTruKhachHang_CreateTime { get { return GetText(); } }
        public static string tGiamTruKhachHang_LastUpdateTime { get { return GetText(); } }
        public static string tMatHang_ID { get { return GetText(); } }
        public static string tMatHang_MaLoai { get { return GetText(); } }
        public static string tMatHang_TenMatHang { get { return GetText(); } }
        public static string tMatHang_SoKy { get { return GetText(); } }
        public static string tMatHang_SoMet { get { return GetText(); } }
        public static string tMatHang_TenMatHangDayDu { get { return GetText(); } }
        public static string tMatHang_TenMatHangIn { get { return GetText(); } }
        public static string tMatHang_TenantID { get { return GetText(); } }
        public static string tMatHang_CreateTime { get { return GetText(); } }
        public static string tMatHang_LastUpdateTime { get { return GetText(); } }
        public static string tMatHang_MaHinhAnh { get { return GetText(); } }
        public static string tNhanTienKhachHang_ID { get { return GetText(); } }
        public static string tNhanTienKhachHang_MaKhachHang { get { return GetText(); } }
        public static string tNhanTienKhachHang_Ngay { get { return GetText(); } }
        public static string tNhanTienKhachHang_SoTien { get { return GetText(); } }
        public static string tNhanTienKhachHang_TenantID { get { return GetText(); } }
        public static string tNhanTienKhachHang_CreateTime { get { return GetText(); } }
        public static string tNhanTienKhachHang_LastUpdateTime { get { return GetText(); } }
        public static string tNhapHang_ID { get { return GetText(); } }
        public static string tNhapHang_MaNhanVien { get { return GetText(); } }
        public static string tNhapHang_MaKhoHang { get { return GetText(); } }
        public static string tNhapHang_MaNhaCungCap { get { return GetText(); } }
        public static string tNhapHang_Ngay { get { return GetText(); } }
        public static string tNhapHang_TenantID { get { return GetText(); } }
        public static string tNhapHang_CreateTime { get { return GetText(); } }
        public static string tNhapHang_LastUpdateTime { get { return GetText(); } }
        public static string tNhapNguyenLieu_ID { get { return GetText(); } }
        public static string tNhapNguyenLieu_Ngay { get { return GetText(); } }
        public static string tNhapNguyenLieu_MaNguyenLieu { get { return GetText(); } }
        public static string tNhapNguyenLieu_MaNhaCungCap { get { return GetText(); } }
        public static string tNhapNguyenLieu_SoLuong { get { return GetText(); } }
        public static string tNhapNguyenLieu_TenantID { get { return GetText(); } }
        public static string tNhapNguyenLieu_CreateTime { get { return GetText(); } }
        public static string tNhapNguyenLieu_LastUpdateTime { get { return GetText(); } }
        public static string tPhuThuKhachHang_ID { get { return GetText(); } }
        public static string tPhuThuKhachHang_MaKhachHang { get { return GetText(); } }
        public static string tPhuThuKhachHang_Ngay { get { return GetText(); } }
        public static string tPhuThuKhachHang_SoTien { get { return GetText(); } }
        public static string tPhuThuKhachHang_GhiChu { get { return GetText(); } }
        public static string tPhuThuKhachHang_TenantID { get { return GetText(); } }
        public static string tPhuThuKhachHang_CreateTime { get { return GetText(); } }
        public static string tPhuThuKhachHang_LastUpdateTime { get { return GetText(); } }
        public static string tToaHang_ID { get { return GetText(); } }
        public static string tToaHang_Ngay { get { return GetText(); } }
        public static string tToaHang_MaKhachHang { get { return GetText(); } }
        public static string tToaHang_TenantID { get { return GetText(); } }
        public static string tToaHang_CreateTime { get { return GetText(); } }
        public static string tToaHang_LastUpdateTime { get { return GetText(); } }
        public static string tTonKho_ID { get { return GetText(); } }
        public static string tTonKho_MaKhoHang { get { return GetText(); } }
        public static string tTonKho_MaMatHang { get { return GetText(); } }
        public static string tTonKho_Ngay { get { return GetText(); } }
        public static string tTonKho_SoLuong { get { return GetText(); } }
        public static string tTonKho_SoLuongCu { get { return GetText(); } }
        public static string tTonKho_TenantID { get { return GetText(); } }
        public static string tTonKho_CreateTime { get { return GetText(); } }
        public static string tTonKho_LastUpdateTime { get { return GetText(); } }
        public static string ThamSoNgay_ID { get { return GetText(); } }
        public static string ThamSoNgay_Ten { get { return GetText(); } }
        public static string ThamSoNgay_GiaTri { get { return GetText(); } }
        public static string ThamSoNgay_TenantID { get { return GetText(); } }
        public static string ThamSoNgay_CreateTime { get { return GetText(); } }
        public static string ThamSoNgay_LastUpdateTime { get { return GetText(); } }

        public static string GetText([CallerMemberName] string textKey = null)
        {
            string text;
            if (_dic.TryGetValue(textKey, out text) == true)
            {
                return text;
            }
            return "[no text]";
        }

        private static void InitDefaultLanguageData()
        {
            _dic.Add("rBaiXe_ID", "ID");
            _dic.Add("rBaiXe_DiaDiemBaiXe", "DiaDiemBaiXe");
            _dic.Add("rBaiXe_TenantID", "TenantID");
            _dic.Add("rBaiXe_CreateTime", "CreateTime");
            _dic.Add("rBaiXe_LastUpdateTime", "LastUpdateTime");
            _dic.Add("rCanhBaoTonKho_ID", "ID");
            _dic.Add("rCanhBaoTonKho_MaMatHang", "MaMatHang");
            _dic.Add("rCanhBaoTonKho_MaKhoHang", "MaKhoHang");
            _dic.Add("rCanhBaoTonKho_TonCaoNhat", "TonCaoNhat");
            _dic.Add("rCanhBaoTonKho_TonThapNhat", "TonThapNhat");
            _dic.Add("rCanhBaoTonKho_TenantID", "TenantID");
            _dic.Add("rCanhBaoTonKho_CreateTime", "CreateTime");
            _dic.Add("rCanhBaoTonKho_LastUpdateTime", "LastUpdateTime");
            _dic.Add("rChanh_ID", "ID");
            _dic.Add("rChanh_MaBaiXe", "MaBaiXe");
            _dic.Add("rChanh_TenChanh", "TenChanh");
            _dic.Add("rChanh_TenantID", "TenantID");
            _dic.Add("rChanh_CreateTime", "CreateTime");
            _dic.Add("rChanh_LastUpdateTime", "LastUpdateTime");
            _dic.Add("rDiaDiem_ID", "ID");
            _dic.Add("rDiaDiem_MaNuoc", "MaNuoc");
            _dic.Add("rDiaDiem_Tinh", "Tinh");
            _dic.Add("rDiaDiem_TenantID", "TenantID");
            _dic.Add("rDiaDiem_CreateTime", "CreateTime");
            _dic.Add("rDiaDiem_LastUpdateTime", "LastUpdateTime");
            _dic.Add("rKhachHang_ID", "ID");
            _dic.Add("rKhachHang_MaDiaDiem", "MaDiaDiem");
            _dic.Add("rKhachHang_TenKhachHang", "TenKhachHang");
            _dic.Add("rKhachHang_KhachRieng", "KhachRieng");
            _dic.Add("rKhachHang_TenantID", "TenantID");
            _dic.Add("rKhachHang_CreateTime", "CreateTime");
            _dic.Add("rKhachHang_LastUpdateTime", "LastUpdateTime");
            _dic.Add("rKhachHangChanh_ID", "ID");
            _dic.Add("rKhachHangChanh_MaChanh", "MaChanh");
            _dic.Add("rKhachHangChanh_MaKhachHang", "MaKhachHang");
            _dic.Add("rKhachHangChanh_LaMacDinh", "LaMacDinh");
            _dic.Add("rKhachHangChanh_TenantID", "TenantID");
            _dic.Add("rKhachHangChanh_CreateTime", "CreateTime");
            _dic.Add("rKhachHangChanh_LastUpdateTime", "LastUpdateTime");
            _dic.Add("rKhoHang_ID", "ID");
            _dic.Add("rKhoHang_TenKho", "TenKho");
            _dic.Add("rKhoHang_TrangThai", "TrangThai");
            _dic.Add("rKhoHang_TenantID", "TenantID");
            _dic.Add("rKhoHang_CreateTime", "CreateTime");
            _dic.Add("rKhoHang_LastUpdateTime", "LastUpdateTime");
            _dic.Add("rLoaiChiPhi_ID", "ID");
            _dic.Add("rLoaiChiPhi_TenLoaiChiPhi", "TenLoaiChiPhi");
            _dic.Add("rLoaiChiPhi_TenantID", "TenantID");
            _dic.Add("rLoaiChiPhi_CreateTime", "CreateTime");
            _dic.Add("rLoaiChiPhi_LastUpdateTime", "LastUpdateTime");
            _dic.Add("rLoaiHang_ID", "ID");
            _dic.Add("rLoaiHang_TenLoai", "TenLoai");
            _dic.Add("rLoaiHang_HangNhaLam", "HangNhaLam");
            _dic.Add("rLoaiHang_TenantID", "TenantID");
            _dic.Add("rLoaiHang_CreateTime", "CreateTime");
            _dic.Add("rLoaiHang_LastUpdateTime", "LastUpdateTime");
            _dic.Add("rLoaiNguyenLieu_ID", "ID");
            _dic.Add("rLoaiNguyenLieu_TenLoai", "TenLoai");
            _dic.Add("rLoaiNguyenLieu_TenantID", "TenantID");
            _dic.Add("rLoaiNguyenLieu_CreateTime", "CreateTime");
            _dic.Add("rLoaiNguyenLieu_LastUpdateTime", "LastUpdateTime");
            _dic.Add("rMatHangNguyenLieu_ID", "ID");
            _dic.Add("rMatHangNguyenLieu_MaMatHang", "MaMatHang");
            _dic.Add("rMatHangNguyenLieu_MaNguyenLieu", "MaNguyenLieu");
            _dic.Add("rMatHangNguyenLieu_TenantID", "TenantID");
            _dic.Add("rMatHangNguyenLieu_CreateTime", "CreateTime");
            _dic.Add("rMatHangNguyenLieu_LastUpdateTime", "LastUpdateTime");
            _dic.Add("rNuoc_ID", "ID");
            _dic.Add("rNuoc_TenNuoc", "TenNuoc");
            _dic.Add("rNuoc_TenantID", "TenantID");
            _dic.Add("rNuoc_CreateTime", "CreateTime");
            _dic.Add("rNuoc_LastUpdateTime", "LastUpdateTime");
            _dic.Add("rNguyenLieu_ID", "ID");
            _dic.Add("rNguyenLieu_MaLoaiNguyenLieu", "MaLoaiNguyenLieu");
            _dic.Add("rNguyenLieu_DuongKinh", "DuongKinh");
            _dic.Add("rNguyenLieu_TenantID", "TenantID");
            _dic.Add("rNguyenLieu_CreateTime", "CreateTime");
            _dic.Add("rNguyenLieu_LastUpdateTime", "LastUpdateTime");
            _dic.Add("rNhaCungCap_ID", "ID");
            _dic.Add("rNhaCungCap_TenNhaCungCap", "TenNhaCungCap");
            _dic.Add("rNhaCungCap_TenantID", "TenantID");
            _dic.Add("rNhaCungCap_CreateTime", "CreateTime");
            _dic.Add("rNhaCungCap_LastUpdateTime", "LastUpdateTime");
            _dic.Add("rNhanVien_ID", "ID");
            _dic.Add("rNhanVien_MaPhuongTien", "MaPhuongTien");
            _dic.Add("rNhanVien_TenNhanVien", "TenNhanVien");
            _dic.Add("rNhanVien_TenantID", "TenantID");
            _dic.Add("rNhanVien_CreateTime", "CreateTime");
            _dic.Add("rNhanVien_LastUpdateTime", "LastUpdateTime");
            _dic.Add("rPhuongTien_ID", "ID");
            _dic.Add("rPhuongTien_TenPhuongTien", "TenPhuongTien");
            _dic.Add("rPhuongTien_TenantID", "TenantID");
            _dic.Add("rPhuongTien_CreateTime", "CreateTime");
            _dic.Add("rPhuongTien_LastUpdateTime", "LastUpdateTime");
            _dic.Add("tCongNoKhachHang_ID", "ID");
            _dic.Add("tCongNoKhachHang_MaKhachHang", "MaKhachHang");
            _dic.Add("tCongNoKhachHang_Ngay", "Ngay");
            _dic.Add("tCongNoKhachHang_SoTien", "SoTien");
            _dic.Add("tCongNoKhachHang_TenantID", "TenantID");
            _dic.Add("tCongNoKhachHang_CreateTime", "CreateTime");
            _dic.Add("tCongNoKhachHang_LastUpdateTime", "LastUpdateTime");
            _dic.Add("tChiPhi_ID", "ID");
            _dic.Add("tChiPhi_MaNhanVienGiaoHang", "MaNhanVienGiaoHang");
            _dic.Add("tChiPhi_MaLoaiChiPhi", "MaLoaiChiPhi");
            _dic.Add("tChiPhi_SoTien", "SoTien");
            _dic.Add("tChiPhi_Ngay", "Ngay");
            _dic.Add("tChiPhi_GhiChu", "GhiChu");
            _dic.Add("tChiPhi_TenantID", "TenantID");
            _dic.Add("tChiPhi_CreateTime", "CreateTime");
            _dic.Add("tChiPhi_LastUpdateTime", "LastUpdateTime");
            _dic.Add("tChiTietChuyenHangDonHang_ID", "ID");
            _dic.Add("tChiTietChuyenHangDonHang_MaChuyenHangDonHang", "MaChuyenHangDonHang");
            _dic.Add("tChiTietChuyenHangDonHang_MaChiTietDonHang", "MaChiTietDonHang");
            _dic.Add("tChiTietChuyenHangDonHang_SoLuong", "SoLuong");
            _dic.Add("tChiTietChuyenHangDonHang_SoLuongTheoDonHang", "SoLuongTheoDonHang");
            _dic.Add("tChiTietChuyenHangDonHang_TenantID", "TenantID");
            _dic.Add("tChiTietChuyenHangDonHang_CreateTime", "CreateTime");
            _dic.Add("tChiTietChuyenHangDonHang_LastUpdateTime", "LastUpdateTime");
            _dic.Add("tChiTietChuyenKho_ID", "ID");
            _dic.Add("tChiTietChuyenKho_MaChuyenKho", "MaChuyenKho");
            _dic.Add("tChiTietChuyenKho_MaMatHang", "MaMatHang");
            _dic.Add("tChiTietChuyenKho_SoLuong", "SoLuong");
            _dic.Add("tChiTietChuyenKho_TenantID", "TenantID");
            _dic.Add("tChiTietChuyenKho_CreateTime", "CreateTime");
            _dic.Add("tChiTietChuyenKho_LastUpdateTime", "LastUpdateTime");
            _dic.Add("tChiTietDonHang_ID", "ID");
            _dic.Add("tChiTietDonHang_MaDonHang", "MaDonHang");
            _dic.Add("tChiTietDonHang_MaMatHang", "MaMatHang");
            _dic.Add("tChiTietDonHang_SoLuong", "SoLuong");
            _dic.Add("tChiTietDonHang_Xong", "Xong");
            _dic.Add("tChiTietDonHang_TenantID", "TenantID");
            _dic.Add("tChiTietDonHang_CreateTime", "CreateTime");
            _dic.Add("tChiTietDonHang_LastUpdateTime", "LastUpdateTime");
            _dic.Add("tChiTietNhapHang_ID", "ID");
            _dic.Add("tChiTietNhapHang_MaNhapHang", "MaNhapHang");
            _dic.Add("tChiTietNhapHang_MaMatHang", "MaMatHang");
            _dic.Add("tChiTietNhapHang_SoLuong", "SoLuong");
            _dic.Add("tChiTietNhapHang_TenantID", "TenantID");
            _dic.Add("tChiTietNhapHang_CreateTime", "CreateTime");
            _dic.Add("tChiTietNhapHang_LastUpdateTime", "LastUpdateTime");
            _dic.Add("tChiTietToaHang_ID", "ID");
            _dic.Add("tChiTietToaHang_MaToaHang", "MaToaHang");
            _dic.Add("tChiTietToaHang_MaChiTietDonHang", "MaChiTietDonHang");
            _dic.Add("tChiTietToaHang_GiaTien", "GiaTien");
            _dic.Add("tChiTietToaHang_TenantID", "TenantID");
            _dic.Add("tChiTietToaHang_CreateTime", "CreateTime");
            _dic.Add("tChiTietToaHang_LastUpdateTime", "LastUpdateTime");
            _dic.Add("tChuyenHang_ID", "ID");
            _dic.Add("tChuyenHang_MaNhanVienGiaoHang", "MaNhanVienGiaoHang");
            _dic.Add("tChuyenHang_Ngay", "Ngay");
            _dic.Add("tChuyenHang_Gio", "Gio");
            _dic.Add("tChuyenHang_TongDonHang", "TongDonHang");
            _dic.Add("tChuyenHang_TongSoLuongTheoDonHang", "TongSoLuongTheoDonHang");
            _dic.Add("tChuyenHang_TongSoLuongThucTe", "TongSoLuongThucTe");
            _dic.Add("tChuyenHang_TenantID", "TenantID");
            _dic.Add("tChuyenHang_CreateTime", "CreateTime");
            _dic.Add("tChuyenHang_LastUpdateTime", "LastUpdateTime");
            _dic.Add("tChuyenHangDonHang_ID", "ID");
            _dic.Add("tChuyenHangDonHang_MaChuyenHang", "MaChuyenHang");
            _dic.Add("tChuyenHangDonHang_MaDonHang", "MaDonHang");
            _dic.Add("tChuyenHangDonHang_TongSoLuongTheoDonHang", "TongSoLuongTheoDonHang");
            _dic.Add("tChuyenHangDonHang_TongSoLuongThucTe", "TongSoLuongThucTe");
            _dic.Add("tChuyenHangDonHang_TenantID", "TenantID");
            _dic.Add("tChuyenHangDonHang_CreateTime", "CreateTime");
            _dic.Add("tChuyenHangDonHang_LastUpdateTime", "LastUpdateTime");
            _dic.Add("tChuyenKho_ID", "ID");
            _dic.Add("tChuyenKho_MaNhanVien", "MaNhanVien");
            _dic.Add("tChuyenKho_MaKhoHangXuat", "MaKhoHangXuat");
            _dic.Add("tChuyenKho_MaKhoHangNhap", "MaKhoHangNhap");
            _dic.Add("tChuyenKho_Ngay", "Ngay");
            _dic.Add("tChuyenKho_TenantID", "TenantID");
            _dic.Add("tChuyenKho_CreateTime", "CreateTime");
            _dic.Add("tChuyenKho_LastUpdateTime", "LastUpdateTime");
            _dic.Add("tDonHang_ID", "ID");
            _dic.Add("tDonHang_MaKhachHang", "MaKhachHang");
            _dic.Add("tDonHang_MaChanh", "MaChanh");
            _dic.Add("tDonHang_Ngay", "Ngay");
            _dic.Add("tDonHang_Xong", "Xong");
            _dic.Add("tDonHang_MaKhoHang", "MaKhoHang");
            _dic.Add("tDonHang_TongSoLuong", "TongSoLuong");
            _dic.Add("tDonHang_TenantID", "TenantID");
            _dic.Add("tDonHang_CreateTime", "CreateTime");
            _dic.Add("tDonHang_LastUpdateTime", "LastUpdateTime");
            _dic.Add("tGiamTruKhachHang_ID", "ID");
            _dic.Add("tGiamTruKhachHang_MaKhachHang", "MaKhachHang");
            _dic.Add("tGiamTruKhachHang_Ngay", "Ngay");
            _dic.Add("tGiamTruKhachHang_SoTien", "SoTien");
            _dic.Add("tGiamTruKhachHang_GhiChu", "GhiChu");
            _dic.Add("tGiamTruKhachHang_TenantID", "TenantID");
            _dic.Add("tGiamTruKhachHang_CreateTime", "CreateTime");
            _dic.Add("tGiamTruKhachHang_LastUpdateTime", "LastUpdateTime");
            _dic.Add("tMatHang_ID", "ID");
            _dic.Add("tMatHang_MaLoai", "MaLoai");
            _dic.Add("tMatHang_TenMatHang", "TenMatHang");
            _dic.Add("tMatHang_SoKy", "SoKy");
            _dic.Add("tMatHang_SoMet", "SoMet");
            _dic.Add("tMatHang_TenMatHangDayDu", "TenMatHangDayDu");
            _dic.Add("tMatHang_TenMatHangIn", "TenMatHangIn");
            _dic.Add("tMatHang_TenantID", "TenantID");
            _dic.Add("tMatHang_CreateTime", "CreateTime");
            _dic.Add("tMatHang_LastUpdateTime", "LastUpdateTime");
            _dic.Add("tMatHang_MaHinhAnh", "MaHinhAnh");
            _dic.Add("tNhanTienKhachHang_ID", "ID");
            _dic.Add("tNhanTienKhachHang_MaKhachHang", "MaKhachHang");
            _dic.Add("tNhanTienKhachHang_Ngay", "Ngay");
            _dic.Add("tNhanTienKhachHang_SoTien", "SoTien");
            _dic.Add("tNhanTienKhachHang_TenantID", "TenantID");
            _dic.Add("tNhanTienKhachHang_CreateTime", "CreateTime");
            _dic.Add("tNhanTienKhachHang_LastUpdateTime", "LastUpdateTime");
            _dic.Add("tNhapHang_ID", "ID");
            _dic.Add("tNhapHang_MaNhanVien", "MaNhanVien");
            _dic.Add("tNhapHang_MaKhoHang", "MaKhoHang");
            _dic.Add("tNhapHang_MaNhaCungCap", "MaNhaCungCap");
            _dic.Add("tNhapHang_Ngay", "Ngay");
            _dic.Add("tNhapHang_TenantID", "TenantID");
            _dic.Add("tNhapHang_CreateTime", "CreateTime");
            _dic.Add("tNhapHang_LastUpdateTime", "LastUpdateTime");
            _dic.Add("tNhapNguyenLieu_ID", "ID");
            _dic.Add("tNhapNguyenLieu_Ngay", "Ngay");
            _dic.Add("tNhapNguyenLieu_MaNguyenLieu", "MaNguyenLieu");
            _dic.Add("tNhapNguyenLieu_MaNhaCungCap", "MaNhaCungCap");
            _dic.Add("tNhapNguyenLieu_SoLuong", "SoLuong");
            _dic.Add("tNhapNguyenLieu_TenantID", "TenantID");
            _dic.Add("tNhapNguyenLieu_CreateTime", "CreateTime");
            _dic.Add("tNhapNguyenLieu_LastUpdateTime", "LastUpdateTime");
            _dic.Add("tPhuThuKhachHang_ID", "ID");
            _dic.Add("tPhuThuKhachHang_MaKhachHang", "MaKhachHang");
            _dic.Add("tPhuThuKhachHang_Ngay", "Ngay");
            _dic.Add("tPhuThuKhachHang_SoTien", "SoTien");
            _dic.Add("tPhuThuKhachHang_GhiChu", "GhiChu");
            _dic.Add("tPhuThuKhachHang_TenantID", "TenantID");
            _dic.Add("tPhuThuKhachHang_CreateTime", "CreateTime");
            _dic.Add("tPhuThuKhachHang_LastUpdateTime", "LastUpdateTime");
            _dic.Add("tToaHang_ID", "ID");
            _dic.Add("tToaHang_Ngay", "Ngay");
            _dic.Add("tToaHang_MaKhachHang", "MaKhachHang");
            _dic.Add("tToaHang_TenantID", "TenantID");
            _dic.Add("tToaHang_CreateTime", "CreateTime");
            _dic.Add("tToaHang_LastUpdateTime", "LastUpdateTime");
            _dic.Add("tTonKho_ID", "ID");
            _dic.Add("tTonKho_MaKhoHang", "MaKhoHang");
            _dic.Add("tTonKho_MaMatHang", "MaMatHang");
            _dic.Add("tTonKho_Ngay", "Ngay");
            _dic.Add("tTonKho_SoLuong", "SoLuong");
            _dic.Add("tTonKho_SoLuongCu", "SoLuongCu");
            _dic.Add("tTonKho_TenantID", "TenantID");
            _dic.Add("tTonKho_CreateTime", "CreateTime");
            _dic.Add("tTonKho_LastUpdateTime", "LastUpdateTime");
            _dic.Add("ThamSoNgay_ID", "ID");
            _dic.Add("ThamSoNgay_Ten", "Ten");
            _dic.Add("ThamSoNgay_GiaTri", "GiaTri");
            _dic.Add("ThamSoNgay_TenantID", "TenantID");
            _dic.Add("ThamSoNgay_CreateTime", "CreateTime");
            _dic.Add("ThamSoNgay_LastUpdateTime", "LastUpdateTime");

            InitDefaultLanguageDataPartial();
        }
    }
}
