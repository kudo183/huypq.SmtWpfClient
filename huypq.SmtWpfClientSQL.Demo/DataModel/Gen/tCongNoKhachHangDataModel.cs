using huypq.SmtWpfClient.Abstraction;
using System.Collections.Generic;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.DataModel
{
    public partial class tCongNoKhachHangDataModel : BaseDataModel<tCongNoKhachHangDto>
    {
        partial void ToDtoPartial(ref tCongNoKhachHangDto dto);
        partial void FromDtoPartial(tCongNoKhachHangDto dto);
        partial void SetPropertiesDependencyPartial();
        partial void DisplayTextPartial();

        public static int DMaKhachHang;
        public static System.DateTime DNgay;
        public static int DSoTien;

        int oMaKhachHang;
        System.DateTime oNgay;
        int oSoTien;

        int _MaKhachHang = DMaKhachHang;
        System.DateTime _Ngay = DNgay;
        int _SoTien = DSoTien;

        public int MaKhachHang { get { return _MaKhachHang; } set { SetField(ref _MaKhachHang, value); } }
        public System.DateTime Ngay { get { return _Ngay; } set { SetField(ref _Ngay, value); } }
        public int SoTien { get { return _SoTien; } set { SetField(ref _SoTien, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaKhachHang = MaKhachHang;
            oNgay = Ngay;
            oSoTien = SoTien;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tCongNoKhachHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaKhachHang = dataModel.MaKhachHang;
            Ngay = dataModel.Ngay;
            SoTien = dataModel.SoTien;
        }

        public override bool HasChange()
        {
            return
            (oMaKhachHang != MaKhachHang) ||
            (oNgay != Ngay) ||
            (oSoTien != SoTien);
        }

        public override tCongNoKhachHangDto ToDto()
        {
            var dto = new tCongNoKhachHangDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaKhachHang = MaKhachHang;
            dto.Ngay = Ngay;
            dto.SoTien = SoTien;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tCongNoKhachHangDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            MaKhachHang = dto.MaKhachHang;
            Ngay = dto.Ngay;
            SoTien = dto.SoTien;
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
