using huypq.SmtWpfClient.Abstraction;
using System.Collections.Generic;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.DataModel
{
    public partial class tNhapNguyenLieuDataModel : BaseDataModel<tNhapNguyenLieuDto>
    {
        partial void ToDtoPartial(ref tNhapNguyenLieuDto dto);
        partial void FromDtoPartial(tNhapNguyenLieuDto dto);
        partial void SetPropertiesDependencyPartial();
        partial void DisplayTextPartial();

        public static System.DateTime DNgay;
        public static int DMaNguyenLieu;
        public static int DMaNhaCungCap;
        public static int DSoLuong;

        System.DateTime oNgay;
        int oMaNguyenLieu;
        int oMaNhaCungCap;
        int oSoLuong;

        System.DateTime _Ngay = DNgay;
        int _MaNguyenLieu = DMaNguyenLieu;
        int _MaNhaCungCap = DMaNhaCungCap;
        int _SoLuong = DSoLuong;

        public System.DateTime Ngay { get { return _Ngay; } set { SetField(ref _Ngay, value); } }
        public int MaNguyenLieu { get { return _MaNguyenLieu; } set { SetField(ref _MaNguyenLieu, value); } }
        public int MaNhaCungCap { get { return _MaNhaCungCap; } set { SetField(ref _MaNhaCungCap, value); } }
        public int SoLuong { get { return _SoLuong; } set { SetField(ref _SoLuong, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oNgay = Ngay;
            oMaNguyenLieu = MaNguyenLieu;
            oMaNhaCungCap = MaNhaCungCap;
            oSoLuong = SoLuong;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tNhapNguyenLieuDataModel;
            if (dataModel == null)
            {
                return;
            }

            Ngay = dataModel.Ngay;
            MaNguyenLieu = dataModel.MaNguyenLieu;
            MaNhaCungCap = dataModel.MaNhaCungCap;
            SoLuong = dataModel.SoLuong;
        }

        public override bool HasChange()
        {
            return
            (oNgay != Ngay) ||
            (oMaNguyenLieu != MaNguyenLieu) ||
            (oMaNhaCungCap != MaNhaCungCap) ||
            (oSoLuong != SoLuong);
        }

        public override tNhapNguyenLieuDto ToDto()
        {
            var dto = new tNhapNguyenLieuDto();
            dto.State = State;
            dto.ID = ID;
            dto.Ngay = Ngay;
            dto.MaNguyenLieu = MaNguyenLieu;
            dto.MaNhaCungCap = MaNhaCungCap;
            dto.SoLuong = SoLuong;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tNhapNguyenLieuDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            Ngay = dto.Ngay;
            MaNguyenLieu = dto.MaNguyenLieu;
            MaNhaCungCap = dto.MaNhaCungCap;
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

        rNguyenLieuDataModel _MaNguyenLieuNavigation;
        rNhaCungCapDataModel _MaNhaCungCapNavigation;

        public rNguyenLieuDataModel MaNguyenLieuNavigation { get { return _MaNguyenLieuNavigation; } set { SetField(ref _MaNguyenLieuNavigation, value); } }
        public rNhaCungCapDataModel MaNhaCungCapNavigation { get { return _MaNhaCungCapNavigation; } set { SetField(ref _MaNhaCungCapNavigation, value); } }

        object _MaNguyenLieuDataSource;
        object _MaNhaCungCapDataSource;

        public object MaNguyenLieuDataSource { get { return _MaNguyenLieuDataSource; } set { SetField(ref _MaNguyenLieuDataSource, value); } }
        public object MaNhaCungCapDataSource { get { return _MaNhaCungCapDataSource; } set { SetField(ref _MaNhaCungCapDataSource, value); } }
    }
}
