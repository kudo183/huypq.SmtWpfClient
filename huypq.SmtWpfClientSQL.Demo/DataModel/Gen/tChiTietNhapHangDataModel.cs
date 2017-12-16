using huypq.SmtWpfClient.Abstraction;
using System.Collections.Generic;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.DataModel
{
    public partial class tChiTietNhapHangDataModel : BaseDataModel<tChiTietNhapHangDto>
    {
        partial void ToDtoPartial(ref tChiTietNhapHangDto dto);
        partial void FromDtoPartial(tChiTietNhapHangDto dto);
        partial void SetPropertiesDependencyPartial();
        partial void DisplayTextPartial();

        public static int DMaNhapHang;
        public static int DMaMatHang;
        public static int DSoLuong;

        int oMaNhapHang;
        int oMaMatHang;
        int oSoLuong;

        int _MaNhapHang = DMaNhapHang;
        int _MaMatHang = DMaMatHang;
        int _SoLuong = DSoLuong;

        public int MaNhapHang { get { return _MaNhapHang; } set { SetField(ref _MaNhapHang, value); } }
        public int MaMatHang { get { return _MaMatHang; } set { SetField(ref _MaMatHang, value); } }
        public int SoLuong { get { return _SoLuong; } set { SetField(ref _SoLuong, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaNhapHang = MaNhapHang;
            oMaMatHang = MaMatHang;
            oSoLuong = SoLuong;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tChiTietNhapHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaNhapHang = dataModel.MaNhapHang;
            MaMatHang = dataModel.MaMatHang;
            SoLuong = dataModel.SoLuong;
        }

        public override bool HasChange()
        {
            return
            (oMaNhapHang != MaNhapHang) ||
            (oMaMatHang != MaMatHang) ||
            (oSoLuong != SoLuong);
        }

        public override tChiTietNhapHangDto ToDto()
        {
            var dto = new tChiTietNhapHangDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaNhapHang = MaNhapHang;
            dto.MaMatHang = MaMatHang;
            dto.SoLuong = SoLuong;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tChiTietNhapHangDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            MaNhapHang = dto.MaNhapHang;
            MaMatHang = dto.MaMatHang;
            SoLuong = dto.SoLuong;
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

        tNhapHangDataModel _MaNhapHangNavigation;
        tMatHangDataModel _MaMatHangNavigation;

        public tNhapHangDataModel MaNhapHangNavigation { get { return _MaNhapHangNavigation; } set { SetField(ref _MaNhapHangNavigation, value); } }
        public tMatHangDataModel MaMatHangNavigation { get { return _MaMatHangNavigation; } set { SetField(ref _MaMatHangNavigation, value); } }

        object _MaMatHangDataSource;

        public object MaMatHangDataSource { get { return _MaMatHangDataSource; } set { SetField(ref _MaMatHangDataSource, value); } }
    }
}
