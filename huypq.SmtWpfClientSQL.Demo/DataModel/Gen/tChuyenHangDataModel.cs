using huypq.SmtWpfClient.Abstraction;
using System.Collections.Generic;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.DataModel
{
    public partial class tChuyenHangDataModel : BaseDataModel<tChuyenHangDto>
    {
        partial void ToDtoPartial(ref tChuyenHangDto dto);
        partial void FromDtoPartial(tChuyenHangDto dto);
        partial void SetPropertiesDependencyPartial();
        partial void DisplayTextPartial();

        public static int DMaNhanVienGiaoHang;
        public static System.DateTime DNgay;
        public static System.TimeSpan? DGio;
        public static int DTongDonHang;
        public static int DTongSoLuongTheoDonHang;
        public static int DTongSoLuongThucTe;

        int oMaNhanVienGiaoHang;
        System.DateTime oNgay;
        System.TimeSpan? oGio;
        int oTongDonHang;
        int oTongSoLuongTheoDonHang;
        int oTongSoLuongThucTe;

        int _MaNhanVienGiaoHang = DMaNhanVienGiaoHang;
        System.DateTime _Ngay = DNgay;
        System.TimeSpan? _Gio = DGio;
        int _TongDonHang = DTongDonHang;
        int _TongSoLuongTheoDonHang = DTongSoLuongTheoDonHang;
        int _TongSoLuongThucTe = DTongSoLuongThucTe;

        public int MaNhanVienGiaoHang { get { return _MaNhanVienGiaoHang; } set { SetField(ref _MaNhanVienGiaoHang, value); } }
        public System.DateTime Ngay { get { return _Ngay; } set { SetField(ref _Ngay, value); } }
        public System.TimeSpan? Gio { get { return _Gio; } set { SetField(ref _Gio, value); } }
        public int TongDonHang { get { return _TongDonHang; } set { SetField(ref _TongDonHang, value); } }
        public int TongSoLuongTheoDonHang { get { return _TongSoLuongTheoDonHang; } set { SetField(ref _TongSoLuongTheoDonHang, value); } }
        public int TongSoLuongThucTe { get { return _TongSoLuongThucTe; } set { SetField(ref _TongSoLuongThucTe, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaNhanVienGiaoHang = MaNhanVienGiaoHang;
            oNgay = Ngay;
            oGio = Gio;
            oTongDonHang = TongDonHang;
            oTongSoLuongTheoDonHang = TongSoLuongTheoDonHang;
            oTongSoLuongThucTe = TongSoLuongThucTe;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tChuyenHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaNhanVienGiaoHang = dataModel.MaNhanVienGiaoHang;
            Ngay = dataModel.Ngay;
            Gio = dataModel.Gio;
            TongDonHang = dataModel.TongDonHang;
            TongSoLuongTheoDonHang = dataModel.TongSoLuongTheoDonHang;
            TongSoLuongThucTe = dataModel.TongSoLuongThucTe;
        }

        public override bool HasChange()
        {
            return
            (oMaNhanVienGiaoHang != MaNhanVienGiaoHang) ||
            (oNgay != Ngay) ||
            (oGio != Gio) ||
            (oTongDonHang != TongDonHang) ||
            (oTongSoLuongTheoDonHang != TongSoLuongTheoDonHang) ||
            (oTongSoLuongThucTe != TongSoLuongThucTe);
        }

        public override tChuyenHangDto ToDto()
        {
            var dto = new tChuyenHangDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaNhanVienGiaoHang = MaNhanVienGiaoHang;
            dto.Ngay = Ngay;
            dto.Gio = Gio;
            dto.TongDonHang = TongDonHang;
            dto.TongSoLuongTheoDonHang = TongSoLuongTheoDonHang;
            dto.TongSoLuongThucTe = TongSoLuongThucTe;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tChuyenHangDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            MaNhanVienGiaoHang = dto.MaNhanVienGiaoHang;
            Ngay = dto.Ngay;
            Gio = dto.Gio;
            TongDonHang = dto.TongDonHang;
            TongSoLuongTheoDonHang = dto.TongSoLuongTheoDonHang;
            TongSoLuongThucTe = dto.TongSoLuongThucTe;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        protected override void SetPropertiesDependency()
        {
            SetPropertiesDependencyPartial();
        }

        private string _displayText;
        public override string DisplayText
        {
            get
            {
                _displayText = base.DisplayText;
                DisplayTextPartial();
                return _displayText;
            }
        }

        rNhanVienDataModel _MaNhanVienGiaoHangNavigation;

        public rNhanVienDataModel MaNhanVienGiaoHangNavigation { get { return _MaNhanVienGiaoHangNavigation; } set { SetField(ref _MaNhanVienGiaoHangNavigation, value); } }

        object _MaNhanVienGiaoHangDataSource;

        public object MaNhanVienGiaoHangDataSource { get { return _MaNhanVienGiaoHangDataSource; } set { SetField(ref _MaNhanVienGiaoHangDataSource, value); } }
    }
}
