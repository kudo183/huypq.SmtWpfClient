using huypq.SmtWpfClient.Abstraction;
using System.Collections.Generic;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.DataModel
{
    public partial class tChiTietChuyenHangDonHangDataModel : BaseDataModel<tChiTietChuyenHangDonHangDto>
    {
        partial void ToDtoPartial(ref tChiTietChuyenHangDonHangDto dto);
        partial void FromDtoPartial(tChiTietChuyenHangDonHangDto dto);
        partial void SetPropertiesDependencyPartial();
        partial void DisplayTextPartial();

        public static int DMaChuyenHangDonHang;
        public static int DMaChiTietDonHang;
        public static int DSoLuong;
        public static int DSoLuongTheoDonHang;

        int oMaChuyenHangDonHang;
        int oMaChiTietDonHang;
        int oSoLuong;
        int oSoLuongTheoDonHang;

        int _MaChuyenHangDonHang = DMaChuyenHangDonHang;
        int _MaChiTietDonHang = DMaChiTietDonHang;
        int _SoLuong = DSoLuong;
        int _SoLuongTheoDonHang = DSoLuongTheoDonHang;

        public int MaChuyenHangDonHang { get { return _MaChuyenHangDonHang; } set { SetField(ref _MaChuyenHangDonHang, value); } }
        public int MaChiTietDonHang { get { return _MaChiTietDonHang; } set { SetField(ref _MaChiTietDonHang, value); } }
        public int SoLuong { get { return _SoLuong; } set { SetField(ref _SoLuong, value); } }
        public int SoLuongTheoDonHang { get { return _SoLuongTheoDonHang; } set { SetField(ref _SoLuongTheoDonHang, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaChuyenHangDonHang = MaChuyenHangDonHang;
            oMaChiTietDonHang = MaChiTietDonHang;
            oSoLuong = SoLuong;
            oSoLuongTheoDonHang = SoLuongTheoDonHang;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tChiTietChuyenHangDonHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaChuyenHangDonHang = dataModel.MaChuyenHangDonHang;
            MaChiTietDonHang = dataModel.MaChiTietDonHang;
            SoLuong = dataModel.SoLuong;
            SoLuongTheoDonHang = dataModel.SoLuongTheoDonHang;
        }

        public override bool HasChange()
        {
            return
            (oMaChuyenHangDonHang != MaChuyenHangDonHang) ||
            (oMaChiTietDonHang != MaChiTietDonHang) ||
            (oSoLuong != SoLuong) ||
            (oSoLuongTheoDonHang != SoLuongTheoDonHang);
        }

        public override tChiTietChuyenHangDonHangDto ToDto()
        {
            var dto = new tChiTietChuyenHangDonHangDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaChuyenHangDonHang = MaChuyenHangDonHang;
            dto.MaChiTietDonHang = MaChiTietDonHang;
            dto.SoLuong = SoLuong;
            dto.SoLuongTheoDonHang = SoLuongTheoDonHang;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tChiTietChuyenHangDonHangDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            MaChuyenHangDonHang = dto.MaChuyenHangDonHang;
            MaChiTietDonHang = dto.MaChiTietDonHang;
            SoLuong = dto.SoLuong;
            SoLuongTheoDonHang = dto.SoLuongTheoDonHang;
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

        tChuyenHangDonHangDataModel _MaChuyenHangDonHangNavigation;
        tChiTietDonHangDataModel _MaChiTietDonHangNavigation;

        public tChuyenHangDonHangDataModel MaChuyenHangDonHangNavigation { get { return _MaChuyenHangDonHangNavigation; } set { SetField(ref _MaChuyenHangDonHangNavigation, value); } }
        public tChiTietDonHangDataModel MaChiTietDonHangNavigation { get { return _MaChiTietDonHangNavigation; } set { SetField(ref _MaChiTietDonHangNavigation, value); } }


    }
}
