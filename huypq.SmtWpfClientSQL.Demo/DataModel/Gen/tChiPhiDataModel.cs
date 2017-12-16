using huypq.SmtWpfClient.Abstraction;
using System.Collections.Generic;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.DataModel
{
    public partial class tChiPhiDataModel : BaseDataModel<tChiPhiDto>
    {
        partial void ToDtoPartial(ref tChiPhiDto dto);
        partial void FromDtoPartial(tChiPhiDto dto);
        partial void SetPropertiesDependencyPartial();
        partial void DisplayTextPartial();

        public static int DMaNhanVienGiaoHang;
        public static int DMaLoaiChiPhi;
        public static int DSoTien;
        public static System.DateTime DNgay;
        public static string DGhiChu;

        int oMaNhanVienGiaoHang;
        int oMaLoaiChiPhi;
        int oSoTien;
        System.DateTime oNgay;
        string oGhiChu;

        int _MaNhanVienGiaoHang = DMaNhanVienGiaoHang;
        int _MaLoaiChiPhi = DMaLoaiChiPhi;
        int _SoTien = DSoTien;
        System.DateTime _Ngay = DNgay;
        string _GhiChu = DGhiChu;

        public int MaNhanVienGiaoHang { get { return _MaNhanVienGiaoHang; } set { SetField(ref _MaNhanVienGiaoHang, value); } }
        public int MaLoaiChiPhi { get { return _MaLoaiChiPhi; } set { SetField(ref _MaLoaiChiPhi, value); } }
        public int SoTien { get { return _SoTien; } set { SetField(ref _SoTien, value); } }
        public System.DateTime Ngay { get { return _Ngay; } set { SetField(ref _Ngay, value); } }
        public string GhiChu { get { return _GhiChu; } set { SetField(ref _GhiChu, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaNhanVienGiaoHang = MaNhanVienGiaoHang;
            oMaLoaiChiPhi = MaLoaiChiPhi;
            oSoTien = SoTien;
            oNgay = Ngay;
            oGhiChu = GhiChu;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tChiPhiDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaNhanVienGiaoHang = dataModel.MaNhanVienGiaoHang;
            MaLoaiChiPhi = dataModel.MaLoaiChiPhi;
            SoTien = dataModel.SoTien;
            Ngay = dataModel.Ngay;
            GhiChu = dataModel.GhiChu;
        }

        public override bool HasChange()
        {
            return
            (oMaNhanVienGiaoHang != MaNhanVienGiaoHang) ||
            (oMaLoaiChiPhi != MaLoaiChiPhi) ||
            (oSoTien != SoTien) ||
            (oNgay != Ngay) ||
            (oGhiChu != GhiChu);
        }

        public override tChiPhiDto ToDto()
        {
            var dto = new tChiPhiDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaNhanVienGiaoHang = MaNhanVienGiaoHang;
            dto.MaLoaiChiPhi = MaLoaiChiPhi;
            dto.SoTien = SoTien;
            dto.Ngay = Ngay;
            dto.GhiChu = GhiChu;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tChiPhiDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            MaNhanVienGiaoHang = dto.MaNhanVienGiaoHang;
            MaLoaiChiPhi = dto.MaLoaiChiPhi;
            SoTien = dto.SoTien;
            Ngay = dto.Ngay;
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

        rNhanVienDataModel _MaNhanVienGiaoHangNavigation;
        rLoaiChiPhiDataModel _MaLoaiChiPhiNavigation;

        public rNhanVienDataModel MaNhanVienGiaoHangNavigation { get { return _MaNhanVienGiaoHangNavigation; } set { SetField(ref _MaNhanVienGiaoHangNavigation, value); } }
        public rLoaiChiPhiDataModel MaLoaiChiPhiNavigation { get { return _MaLoaiChiPhiNavigation; } set { SetField(ref _MaLoaiChiPhiNavigation, value); } }

        object _MaNhanVienGiaoHangDataSource;
        object _MaLoaiChiPhiDataSource;

        public object MaNhanVienGiaoHangDataSource { get { return _MaNhanVienGiaoHangDataSource; } set { SetField(ref _MaNhanVienGiaoHangDataSource, value); } }
        public object MaLoaiChiPhiDataSource { get { return _MaLoaiChiPhiDataSource; } set { SetField(ref _MaLoaiChiPhiDataSource, value); } }
    }
}
