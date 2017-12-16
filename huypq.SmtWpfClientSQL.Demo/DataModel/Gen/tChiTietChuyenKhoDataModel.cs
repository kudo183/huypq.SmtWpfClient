using huypq.SmtWpfClient.Abstraction;
using System.Collections.Generic;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.DataModel
{
    public partial class tChiTietChuyenKhoDataModel : BaseDataModel<tChiTietChuyenKhoDto>
    {
        partial void ToDtoPartial(ref tChiTietChuyenKhoDto dto);
        partial void FromDtoPartial(tChiTietChuyenKhoDto dto);
        partial void SetPropertiesDependencyPartial();
        partial void DisplayTextPartial();

        public static int DMaChuyenKho;
        public static int DMaMatHang;
        public static int DSoLuong;

        int oMaChuyenKho;
        int oMaMatHang;
        int oSoLuong;

        int _MaChuyenKho = DMaChuyenKho;
        int _MaMatHang = DMaMatHang;
        int _SoLuong = DSoLuong;

        public int MaChuyenKho { get { return _MaChuyenKho; } set { SetField(ref _MaChuyenKho, value); } }
        public int MaMatHang { get { return _MaMatHang; } set { SetField(ref _MaMatHang, value); } }
        public int SoLuong { get { return _SoLuong; } set { SetField(ref _SoLuong, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaChuyenKho = MaChuyenKho;
            oMaMatHang = MaMatHang;
            oSoLuong = SoLuong;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tChiTietChuyenKhoDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaChuyenKho = dataModel.MaChuyenKho;
            MaMatHang = dataModel.MaMatHang;
            SoLuong = dataModel.SoLuong;
        }

        public override bool HasChange()
        {
            return
            (oMaChuyenKho != MaChuyenKho) ||
            (oMaMatHang != MaMatHang) ||
            (oSoLuong != SoLuong);
        }

        public override tChiTietChuyenKhoDto ToDto()
        {
            var dto = new tChiTietChuyenKhoDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaChuyenKho = MaChuyenKho;
            dto.MaMatHang = MaMatHang;
            dto.SoLuong = SoLuong;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tChiTietChuyenKhoDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            MaChuyenKho = dto.MaChuyenKho;
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

        tChuyenKhoDataModel _MaChuyenKhoNavigation;
        tMatHangDataModel _MaMatHangNavigation;

        public tChuyenKhoDataModel MaChuyenKhoNavigation { get { return _MaChuyenKhoNavigation; } set { SetField(ref _MaChuyenKhoNavigation, value); } }
        public tMatHangDataModel MaMatHangNavigation { get { return _MaMatHangNavigation; } set { SetField(ref _MaMatHangNavigation, value); } }

        object _MaMatHangDataSource;

        public object MaMatHangDataSource { get { return _MaMatHangDataSource; } set { SetField(ref _MaMatHangDataSource, value); } }
    }
}
