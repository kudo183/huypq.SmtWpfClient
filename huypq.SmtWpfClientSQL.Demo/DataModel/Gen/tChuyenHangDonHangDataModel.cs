using huypq.SmtWpfClient.Abstraction;
using System.Collections.Generic;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.DataModel
{
    public partial class tChuyenHangDonHangDataModel : BaseDataModel<tChuyenHangDonHangDto>
    {
        partial void ToDtoPartial(ref tChuyenHangDonHangDto dto);
        partial void FromDtoPartial(tChuyenHangDonHangDto dto);
        partial void SetPropertiesDependencyPartial();
        partial void DisplayTextPartial();

        public static int DMaChuyenHang;
        public static int DMaDonHang;
        public static int DTongSoLuongTheoDonHang;
        public static int DTongSoLuongThucTe;

        int oMaChuyenHang;
        int oMaDonHang;
        int oTongSoLuongTheoDonHang;
        int oTongSoLuongThucTe;

        int _MaChuyenHang = DMaChuyenHang;
        int _MaDonHang = DMaDonHang;
        int _TongSoLuongTheoDonHang = DTongSoLuongTheoDonHang;
        int _TongSoLuongThucTe = DTongSoLuongThucTe;

        public int MaChuyenHang { get { return _MaChuyenHang; } set { SetField(ref _MaChuyenHang, value); } }
        public int MaDonHang { get { return _MaDonHang; } set { SetField(ref _MaDonHang, value); } }
        public int TongSoLuongTheoDonHang { get { return _TongSoLuongTheoDonHang; } set { SetField(ref _TongSoLuongTheoDonHang, value); } }
        public int TongSoLuongThucTe { get { return _TongSoLuongThucTe; } set { SetField(ref _TongSoLuongThucTe, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaChuyenHang = MaChuyenHang;
            oMaDonHang = MaDonHang;
            oTongSoLuongTheoDonHang = TongSoLuongTheoDonHang;
            oTongSoLuongThucTe = TongSoLuongThucTe;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tChuyenHangDonHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaChuyenHang = dataModel.MaChuyenHang;
            MaDonHang = dataModel.MaDonHang;
            TongSoLuongTheoDonHang = dataModel.TongSoLuongTheoDonHang;
            TongSoLuongThucTe = dataModel.TongSoLuongThucTe;
        }

        public override bool HasChange()
        {
            return
            (oMaChuyenHang != MaChuyenHang) ||
            (oMaDonHang != MaDonHang) ||
            (oTongSoLuongTheoDonHang != TongSoLuongTheoDonHang) ||
            (oTongSoLuongThucTe != TongSoLuongThucTe);
        }

        public override tChuyenHangDonHangDto ToDto()
        {
            var dto = new tChuyenHangDonHangDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaChuyenHang = MaChuyenHang;
            dto.MaDonHang = MaDonHang;
            dto.TongSoLuongTheoDonHang = TongSoLuongTheoDonHang;
            dto.TongSoLuongThucTe = TongSoLuongThucTe;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tChuyenHangDonHangDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            MaChuyenHang = dto.MaChuyenHang;
            MaDonHang = dto.MaDonHang;
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

        tChuyenHangDataModel _MaChuyenHangNavigation;
        tDonHangDataModel _MaDonHangNavigation;

        public tChuyenHangDataModel MaChuyenHangNavigation { get { return _MaChuyenHangNavigation; } set { SetField(ref _MaChuyenHangNavigation, value); } }
        public tDonHangDataModel MaDonHangNavigation { get { return _MaDonHangNavigation; } set { SetField(ref _MaDonHangNavigation, value); } }


    }
}
