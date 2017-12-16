using huypq.SmtWpfClient.Abstraction;
using System.Collections.Generic;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.DataModel
{
    public partial class tDonHangDataModel : BaseDataModel<tDonHangDto>
    {
        partial void ToDtoPartial(ref tDonHangDto dto);
        partial void FromDtoPartial(tDonHangDto dto);
        partial void SetPropertiesDependencyPartial();
        partial void DisplayTextPartial();

        public static int DMaKhachHang;
        public static int? DMaChanh;
        public static System.DateTime DNgay;
        public static bool DXong;
        public static int DMaKhoHang;
        public static int DTongSoLuong;

        int oMaKhachHang;
        int? oMaChanh;
        System.DateTime oNgay;
        bool oXong;
        int oMaKhoHang;
        int oTongSoLuong;

        int _MaKhachHang = DMaKhachHang;
        int? _MaChanh = DMaChanh;
        System.DateTime _Ngay = DNgay;
        bool _Xong = DXong;
        int _MaKhoHang = DMaKhoHang;
        int _TongSoLuong = DTongSoLuong;

        public int MaKhachHang { get { return _MaKhachHang; } set { SetField(ref _MaKhachHang, value); } }
        public int? MaChanh { get { return _MaChanh; } set { SetField(ref _MaChanh, value); } }
        public System.DateTime Ngay { get { return _Ngay; } set { SetField(ref _Ngay, value); } }
        public bool Xong { get { return _Xong; } set { SetField(ref _Xong, value); } }
        public int MaKhoHang { get { return _MaKhoHang; } set { SetField(ref _MaKhoHang, value); } }
        public int TongSoLuong { get { return _TongSoLuong; } set { SetField(ref _TongSoLuong, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaKhachHang = MaKhachHang;
            oMaChanh = MaChanh;
            oNgay = Ngay;
            oXong = Xong;
            oMaKhoHang = MaKhoHang;
            oTongSoLuong = TongSoLuong;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tDonHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaKhachHang = dataModel.MaKhachHang;
            MaChanh = dataModel.MaChanh;
            Ngay = dataModel.Ngay;
            Xong = dataModel.Xong;
            MaKhoHang = dataModel.MaKhoHang;
            TongSoLuong = dataModel.TongSoLuong;
        }

        public override bool HasChange()
        {
            return
            (oMaKhachHang != MaKhachHang) ||
            (oMaChanh != MaChanh) ||
            (oNgay != Ngay) ||
            (oXong != Xong) ||
            (oMaKhoHang != MaKhoHang) ||
            (oTongSoLuong != TongSoLuong);
        }

        public override tDonHangDto ToDto()
        {
            var dto = new tDonHangDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaKhachHang = MaKhachHang;
            dto.MaChanh = MaChanh;
            dto.Ngay = Ngay;
            dto.Xong = Xong;
            dto.MaKhoHang = MaKhoHang;
            dto.TongSoLuong = TongSoLuong;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tDonHangDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            MaKhachHang = dto.MaKhachHang;
            MaChanh = dto.MaChanh;
            Ngay = dto.Ngay;
            Xong = dto.Xong;
            MaKhoHang = dto.MaKhoHang;
            TongSoLuong = dto.TongSoLuong;
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

        rKhachHangDataModel _MaKhachHangNavigation;
        rChanhDataModel _MaChanhNavigation;
        rKhoHangDataModel _MaKhoHangNavigation;

        public rKhachHangDataModel MaKhachHangNavigation { get { return _MaKhachHangNavigation; } set { SetField(ref _MaKhachHangNavigation, value); } }
        public rChanhDataModel MaChanhNavigation { get { return _MaChanhNavigation; } set { SetField(ref _MaChanhNavigation, value); } }
        public rKhoHangDataModel MaKhoHangNavigation { get { return _MaKhoHangNavigation; } set { SetField(ref _MaKhoHangNavigation, value); } }

        object _MaKhachHangDataSource;
        object _MaChanhDataSource;
        object _MaKhoHangDataSource;

        public object MaKhachHangDataSource { get { return _MaKhachHangDataSource; } set { SetField(ref _MaKhachHangDataSource, value); } }
        public object MaChanhDataSource { get { return _MaChanhDataSource; } set { SetField(ref _MaChanhDataSource, value); } }
        public object MaKhoHangDataSource { get { return _MaKhoHangDataSource; } set { SetField(ref _MaKhoHangDataSource, value); } }
    }
}
