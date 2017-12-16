using huypq.SmtWpfClient.Abstraction;
using System.Collections.Generic;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.DataModel
{
    public partial class rMatHangNguyenLieuDataModel : BaseDataModel<rMatHangNguyenLieuDto>
    {
        partial void ToDtoPartial(ref rMatHangNguyenLieuDto dto);
        partial void FromDtoPartial(rMatHangNguyenLieuDto dto);
        partial void SetPropertiesDependencyPartial();
        partial void DisplayTextPartial();

        public static int DMaMatHang;
        public static int DMaNguyenLieu;

        int oMaMatHang;
        int oMaNguyenLieu;

        int _MaMatHang = DMaMatHang;
        int _MaNguyenLieu = DMaNguyenLieu;

        public int MaMatHang { get { return _MaMatHang; } set { SetField(ref _MaMatHang, value); } }
        public int MaNguyenLieu { get { return _MaNguyenLieu; } set { SetField(ref _MaNguyenLieu, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaMatHang = MaMatHang;
            oMaNguyenLieu = MaNguyenLieu;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rMatHangNguyenLieuDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaMatHang = dataModel.MaMatHang;
            MaNguyenLieu = dataModel.MaNguyenLieu;
        }

        public override bool HasChange()
        {
            return
            (oMaMatHang != MaMatHang) ||
            (oMaNguyenLieu != MaNguyenLieu);
        }

        public override rMatHangNguyenLieuDto ToDto()
        {
            var dto = new rMatHangNguyenLieuDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaMatHang = MaMatHang;
            dto.MaNguyenLieu = MaNguyenLieu;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rMatHangNguyenLieuDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            MaMatHang = dto.MaMatHang;
            MaNguyenLieu = dto.MaNguyenLieu;
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

        tMatHangDataModel _MaMatHangNavigation;
        rNguyenLieuDataModel _MaNguyenLieuNavigation;

        public tMatHangDataModel MaMatHangNavigation { get { return _MaMatHangNavigation; } set { SetField(ref _MaMatHangNavigation, value); } }
        public rNguyenLieuDataModel MaNguyenLieuNavigation { get { return _MaNguyenLieuNavigation; } set { SetField(ref _MaNguyenLieuNavigation, value); } }

        object _MaMatHangDataSource;
        object _MaNguyenLieuDataSource;

        public object MaMatHangDataSource { get { return _MaMatHangDataSource; } set { SetField(ref _MaMatHangDataSource, value); } }
        public object MaNguyenLieuDataSource { get { return _MaNguyenLieuDataSource; } set { SetField(ref _MaNguyenLieuDataSource, value); } }
    }
}
