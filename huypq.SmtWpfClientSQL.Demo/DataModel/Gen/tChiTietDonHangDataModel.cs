using huypq.SmtWpfClient.Abstraction;
using System.Collections.Generic;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.DataModel
{
    public partial class tChiTietDonHangDataModel : BaseDataModel<tChiTietDonHangDto>
    {
        partial void ToDtoPartial(ref tChiTietDonHangDto dto);
        partial void FromDtoPartial(tChiTietDonHangDto dto);
        partial void SetPropertiesDependencyPartial();
        partial void DisplayTextPartial();

        public static int DMaDonHang;
        public static int DMaMatHang;
        public static int DSoLuong;
        public static bool DXong;

        int oMaDonHang;
        int oMaMatHang;
        int oSoLuong;
        bool oXong;

        int _MaDonHang = DMaDonHang;
        int _MaMatHang = DMaMatHang;
        int _SoLuong = DSoLuong;
        bool _Xong = DXong;

        public int MaDonHang { get { return _MaDonHang; } set { SetField(ref _MaDonHang, value); } }
        public int MaMatHang { get { return _MaMatHang; } set { SetField(ref _MaMatHang, value); } }
        public int SoLuong { get { return _SoLuong; } set { SetField(ref _SoLuong, value); } }
        public bool Xong { get { return _Xong; } set { SetField(ref _Xong, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaDonHang = MaDonHang;
            oMaMatHang = MaMatHang;
            oSoLuong = SoLuong;
            oXong = Xong;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tChiTietDonHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaDonHang = dataModel.MaDonHang;
            MaMatHang = dataModel.MaMatHang;
            SoLuong = dataModel.SoLuong;
            Xong = dataModel.Xong;
        }

        public override bool HasChange()
        {
            return
            (oMaDonHang != MaDonHang) ||
            (oMaMatHang != MaMatHang) ||
            (oSoLuong != SoLuong) ||
            (oXong != Xong);
        }

        public override tChiTietDonHangDto ToDto()
        {
            var dto = new tChiTietDonHangDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaDonHang = MaDonHang;
            dto.MaMatHang = MaMatHang;
            dto.SoLuong = SoLuong;
            dto.Xong = Xong;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tChiTietDonHangDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            MaDonHang = dto.MaDonHang;
            MaMatHang = dto.MaMatHang;
            SoLuong = dto.SoLuong;
            Xong = dto.Xong;
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

        tDonHangDataModel _MaDonHangNavigation;
        tMatHangDataModel _MaMatHangNavigation;

        public tDonHangDataModel MaDonHangNavigation { get { return _MaDonHangNavigation; } set { SetField(ref _MaDonHangNavigation, value); } }
        public tMatHangDataModel MaMatHangNavigation { get { return _MaMatHangNavigation; } set { SetField(ref _MaMatHangNavigation, value); } }

        object _MaMatHangDataSource;

        public object MaMatHangDataSource { get { return _MaMatHangDataSource; } set { SetField(ref _MaMatHangDataSource, value); } }
    }
}
