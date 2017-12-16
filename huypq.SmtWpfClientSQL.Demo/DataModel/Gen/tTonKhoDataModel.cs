using huypq.SmtWpfClient.Abstraction;
using System.Collections.Generic;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.DataModel
{
    public partial class tTonKhoDataModel : BaseDataModel<tTonKhoDto>
    {
        partial void ToDtoPartial(ref tTonKhoDto dto);
        partial void FromDtoPartial(tTonKhoDto dto);
        partial void SetPropertiesDependencyPartial();
        partial void DisplayTextPartial();

        public static int DMaKhoHang;
        public static int DMaMatHang;
        public static System.DateTime DNgay;
        public static int DSoLuong;
        public static int DSoLuongCu;

        int oMaKhoHang;
        int oMaMatHang;
        System.DateTime oNgay;
        int oSoLuong;
        int oSoLuongCu;

        int _MaKhoHang = DMaKhoHang;
        int _MaMatHang = DMaMatHang;
        System.DateTime _Ngay = DNgay;
        int _SoLuong = DSoLuong;
        int _SoLuongCu = DSoLuongCu;

        public int MaKhoHang { get { return _MaKhoHang; } set { SetField(ref _MaKhoHang, value); } }
        public int MaMatHang { get { return _MaMatHang; } set { SetField(ref _MaMatHang, value); } }
        public System.DateTime Ngay { get { return _Ngay; } set { SetField(ref _Ngay, value); } }
        public int SoLuong { get { return _SoLuong; } set { SetField(ref _SoLuong, value); } }
        public int SoLuongCu { get { return _SoLuongCu; } set { SetField(ref _SoLuongCu, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaKhoHang = MaKhoHang;
            oMaMatHang = MaMatHang;
            oNgay = Ngay;
            oSoLuong = SoLuong;
            oSoLuongCu = SoLuongCu;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tTonKhoDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaKhoHang = dataModel.MaKhoHang;
            MaMatHang = dataModel.MaMatHang;
            Ngay = dataModel.Ngay;
            SoLuong = dataModel.SoLuong;
            SoLuongCu = dataModel.SoLuongCu;
        }

        public override bool HasChange()
        {
            return
            (oMaKhoHang != MaKhoHang) ||
            (oMaMatHang != MaMatHang) ||
            (oNgay != Ngay) ||
            (oSoLuong != SoLuong) ||
            (oSoLuongCu != SoLuongCu);
        }

        public override tTonKhoDto ToDto()
        {
            var dto = new tTonKhoDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaKhoHang = MaKhoHang;
            dto.MaMatHang = MaMatHang;
            dto.Ngay = Ngay;
            dto.SoLuong = SoLuong;
            dto.SoLuongCu = SoLuongCu;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tTonKhoDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            MaKhoHang = dto.MaKhoHang;
            MaMatHang = dto.MaMatHang;
            Ngay = dto.Ngay;
            SoLuong = dto.SoLuong;
            SoLuongCu = dto.SoLuongCu;
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

        rKhoHangDataModel _MaKhoHangNavigation;
        tMatHangDataModel _MaMatHangNavigation;

        public rKhoHangDataModel MaKhoHangNavigation { get { return _MaKhoHangNavigation; } set { SetField(ref _MaKhoHangNavigation, value); } }
        public tMatHangDataModel MaMatHangNavigation { get { return _MaMatHangNavigation; } set { SetField(ref _MaMatHangNavigation, value); } }

        object _MaKhoHangDataSource;
        object _MaMatHangDataSource;

        public object MaKhoHangDataSource { get { return _MaKhoHangDataSource; } set { SetField(ref _MaKhoHangDataSource, value); } }
        public object MaMatHangDataSource { get { return _MaMatHangDataSource; } set { SetField(ref _MaMatHangDataSource, value); } }
    }
}
