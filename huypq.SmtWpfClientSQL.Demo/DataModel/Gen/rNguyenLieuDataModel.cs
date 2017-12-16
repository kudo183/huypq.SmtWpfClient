using huypq.SmtWpfClient.Abstraction;
using System.Collections.Generic;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.DataModel
{
    public partial class rNguyenLieuDataModel : BaseDataModel<rNguyenLieuDto>
    {
        partial void ToDtoPartial(ref rNguyenLieuDto dto);
        partial void FromDtoPartial(rNguyenLieuDto dto);
        partial void SetPropertiesDependencyPartial();
        partial void DisplayTextPartial();

        public static int DMaLoaiNguyenLieu;
        public static int DDuongKinh;

        int oMaLoaiNguyenLieu;
        int oDuongKinh;

        int _MaLoaiNguyenLieu = DMaLoaiNguyenLieu;
        int _DuongKinh = DDuongKinh;

        public int MaLoaiNguyenLieu { get { return _MaLoaiNguyenLieu; } set { SetField(ref _MaLoaiNguyenLieu, value); } }
        public int DuongKinh { get { return _DuongKinh; } set { SetField(ref _DuongKinh, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaLoaiNguyenLieu = MaLoaiNguyenLieu;
            oDuongKinh = DuongKinh;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rNguyenLieuDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaLoaiNguyenLieu = dataModel.MaLoaiNguyenLieu;
            DuongKinh = dataModel.DuongKinh;
        }

        public override bool HasChange()
        {
            return
            (oMaLoaiNguyenLieu != MaLoaiNguyenLieu) ||
            (oDuongKinh != DuongKinh);
        }

        public override rNguyenLieuDto ToDto()
        {
            var dto = new rNguyenLieuDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaLoaiNguyenLieu = MaLoaiNguyenLieu;
            dto.DuongKinh = DuongKinh;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rNguyenLieuDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            MaLoaiNguyenLieu = dto.MaLoaiNguyenLieu;
            DuongKinh = dto.DuongKinh;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        protected override void SetPropertiesDependency()
        {
            SetDependentProperty(nameof(DuongKinh), new List<string>(){nameof(DisplayText)});
            SetPropertiesDependencyPartial();
        }

        private string _displayText;
        public override string DisplayText
        {
            get
            {
                _displayText = DuongKinh.ToString();
                DisplayTextPartial();
                return _displayText;
            }
        }

        rLoaiNguyenLieuDataModel _MaLoaiNguyenLieuNavigation;

        public rLoaiNguyenLieuDataModel MaLoaiNguyenLieuNavigation { get { return _MaLoaiNguyenLieuNavigation; } set { SetField(ref _MaLoaiNguyenLieuNavigation, value); } }

        object _MaLoaiNguyenLieuDataSource;

        public object MaLoaiNguyenLieuDataSource { get { return _MaLoaiNguyenLieuDataSource; } set { SetField(ref _MaLoaiNguyenLieuDataSource, value); } }
    }
}
