using huypq.SmtWpfClient.Abstraction;
using System.Collections.Generic;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.DataModel
{
    public partial class rNuocDataModel : BaseDataModel<rNuocDto>
    {
        partial void ToDtoPartial(ref rNuocDto dto);
        partial void FromDtoPartial(rNuocDto dto);
        partial void SetPropertiesDependencyPartial();
        partial void DisplayTextPartial();

        public static string DTenNuoc;

        string oTenNuoc;

        string _TenNuoc = DTenNuoc;

        public string TenNuoc { get { return _TenNuoc; } set { SetField(ref _TenNuoc, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oTenNuoc = TenNuoc;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rNuocDataModel;
            if (dataModel == null)
            {
                return;
            }

            TenNuoc = dataModel.TenNuoc;
        }

        public override bool HasChange()
        {
            return
            (oTenNuoc != TenNuoc);
        }

        public override rNuocDto ToDto()
        {
            var dto = new rNuocDto();
            dto.State = State;
            dto.ID = ID;
            dto.TenNuoc = TenNuoc;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rNuocDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            TenNuoc = dto.TenNuoc;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        protected override void SetPropertiesDependency()
        {
            SetDependentProperty(nameof(TenNuoc), new List<string>(){nameof(DisplayText)});
            SetPropertiesDependencyPartial();
        }

        private string _displayText;
        public override string DisplayText
        {
            get
            {
                _displayText = TenNuoc.ToString();
                DisplayTextPartial();
                return _displayText;
            }
        }



    }
}
