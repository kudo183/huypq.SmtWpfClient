using huypq.SmtWpfClient.Abstraction;
using System.Collections.Generic;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.DataModel
{
    public partial class tPhuThuKhachHangDataModel : BaseDataModel<tPhuThuKhachHangDto>
    {
        partial void ToDtoPartial(ref tPhuThuKhachHangDto dto);
        partial void FromDtoPartial(tPhuThuKhachHangDto dto);
        partial void SetPropertiesDependencyPartial();
        partial void DisplayTextPartial();

        public static int DMaKhachHang;
        public static System.DateTime DNgay;
        public static int DSoTien;
        public static string DGhiChu;

        int oMaKhachHang;
        System.DateTime oNgay;
        int oSoTien;
        string oGhiChu;

        int _MaKhachHang = DMaKhachHang;
        System.DateTime _Ngay = DNgay;
        int _SoTien = DSoTien;
        string _GhiChu = DGhiChu;

        public int MaKhachHang { get { return _MaKhachHang; } set { SetField(ref _MaKhachHang, value); } }
        public System.DateTime Ngay { get { return _Ngay; } set { SetField(ref _Ngay, value); } }
        public int SoTien { get { return _SoTien; } set { SetField(ref _SoTien, value); } }
        public string GhiChu { get { return _GhiChu; } set { SetField(ref _GhiChu, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaKhachHang = MaKhachHang;
            oNgay = Ngay;
            oSoTien = SoTien;
            oGhiChu = GhiChu;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tPhuThuKhachHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaKhachHang = dataModel.MaKhachHang;
            Ngay = dataModel.Ngay;
            SoTien = dataModel.SoTien;
            GhiChu = dataModel.GhiChu;
        }

        public override bool HasChange()
        {
            return
            (oMaKhachHang != MaKhachHang) ||
            (oNgay != Ngay) ||
            (oSoTien != SoTien) ||
            (oGhiChu != GhiChu);
        }

        public override tPhuThuKhachHangDto ToDto()
        {
            var dto = new tPhuThuKhachHangDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaKhachHang = MaKhachHang;
            dto.Ngay = Ngay;
            dto.SoTien = SoTien;
            dto.GhiChu = GhiChu;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tPhuThuKhachHangDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            MaKhachHang = dto.MaKhachHang;
            Ngay = dto.Ngay;
            SoTien = dto.SoTien;
            GhiChu = dto.GhiChu;
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

        public rKhachHangDataModel MaKhachHangNavigation { get { return _MaKhachHangNavigation; } set { SetField(ref _MaKhachHangNavigation, value); } }

        object _MaKhachHangDataSource;

        public object MaKhachHangDataSource { get { return _MaKhachHangDataSource; } set { SetField(ref _MaKhachHangDataSource, value); } }
    }
}
