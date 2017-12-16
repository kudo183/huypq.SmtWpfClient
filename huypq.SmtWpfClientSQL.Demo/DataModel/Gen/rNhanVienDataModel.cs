using huypq.SmtWpfClient.Abstraction;
using System.Collections.Generic;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.DataModel
{
    public partial class rNhanVienDataModel : BaseDataModel<rNhanVienDto>
    {
        partial void ToDtoPartial(ref rNhanVienDto dto);
        partial void FromDtoPartial(rNhanVienDto dto);
        partial void SetPropertiesDependencyPartial();
        partial void DisplayTextPartial();

        public static int DMaPhuongTien;
        public static string DTenNhanVien;

        int oMaPhuongTien;
        string oTenNhanVien;

        int _MaPhuongTien = DMaPhuongTien;
        string _TenNhanVien = DTenNhanVien;

        public int MaPhuongTien { get { return _MaPhuongTien; } set { SetField(ref _MaPhuongTien, value); } }
        public string TenNhanVien { get { return _TenNhanVien; } set { SetField(ref _TenNhanVien, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaPhuongTien = MaPhuongTien;
            oTenNhanVien = TenNhanVien;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rNhanVienDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaPhuongTien = dataModel.MaPhuongTien;
            TenNhanVien = dataModel.TenNhanVien;
        }

        public override bool HasChange()
        {
            return
            (oMaPhuongTien != MaPhuongTien) ||
            (oTenNhanVien != TenNhanVien);
        }

        public override rNhanVienDto ToDto()
        {
            var dto = new rNhanVienDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaPhuongTien = MaPhuongTien;
            dto.TenNhanVien = TenNhanVien;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rNhanVienDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            MaPhuongTien = dto.MaPhuongTien;
            TenNhanVien = dto.TenNhanVien;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        protected override void SetPropertiesDependency()
        {
            SetDependentProperty(nameof(TenNhanVien), new List<string>(){nameof(DisplayText)});
            SetPropertiesDependencyPartial();
        }

        private string _displayText;
        public override string DisplayText
        {
            get
            {
                _displayText = TenNhanVien.ToString();
                DisplayTextPartial();
                return _displayText;
            }
        }

        rPhuongTienDataModel _MaPhuongTienNavigation;

        public rPhuongTienDataModel MaPhuongTienNavigation { get { return _MaPhuongTienNavigation; } set { SetField(ref _MaPhuongTienNavigation, value); } }

        object _MaPhuongTienDataSource;

        public object MaPhuongTienDataSource { get { return _MaPhuongTienDataSource; } set { SetField(ref _MaPhuongTienDataSource, value); } }
    }
}
