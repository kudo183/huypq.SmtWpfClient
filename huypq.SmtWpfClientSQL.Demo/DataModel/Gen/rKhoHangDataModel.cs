using huypq.SmtWpfClient.Abstraction;
using System.Collections.Generic;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.DataModel
{
    public partial class rKhoHangDataModel : BaseDataModel<rKhoHangDto>
    {
        partial void ToDtoPartial(ref rKhoHangDto dto);
        partial void FromDtoPartial(rKhoHangDto dto);
        partial void SetPropertiesDependencyPartial();
        partial void DisplayTextPartial();

        public static string DTenKho;
        public static bool DTrangThai;

        string oTenKho;
        bool oTrangThai;

        string _TenKho = DTenKho;
        bool _TrangThai = DTrangThai;

        public string TenKho { get { return _TenKho; } set { SetField(ref _TenKho, value); } }
        public bool TrangThai { get { return _TrangThai; } set { SetField(ref _TrangThai, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oTenKho = TenKho;
            oTrangThai = TrangThai;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rKhoHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            TenKho = dataModel.TenKho;
            TrangThai = dataModel.TrangThai;
        }

        public override bool HasChange()
        {
            return
            (oTenKho != TenKho) ||
            (oTrangThai != TrangThai);
        }

        public override rKhoHangDto ToDto()
        {
            var dto = new rKhoHangDto();
            dto.State = State;
            dto.ID = ID;
            dto.TenKho = TenKho;
            dto.TrangThai = TrangThai;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rKhoHangDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            TenKho = dto.TenKho;
            TrangThai = dto.TrangThai;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        protected override void SetPropertiesDependency()
        {
            SetDependentProperty(nameof(TenKho), new List<string>(){nameof(DisplayText)});
            SetPropertiesDependencyPartial();
        }

        private string _displayText;
        public override string DisplayText
        {
            get
            {
                _displayText = TenKho.ToString();
                DisplayTextPartial();
                return _displayText;
            }
        }



    }
}
