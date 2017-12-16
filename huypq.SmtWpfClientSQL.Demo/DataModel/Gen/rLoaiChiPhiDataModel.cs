using huypq.SmtWpfClient.Abstraction;
using System.Collections.Generic;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.DataModel
{
    public partial class rLoaiChiPhiDataModel : BaseDataModel<rLoaiChiPhiDto>
    {
        partial void ToDtoPartial(ref rLoaiChiPhiDto dto);
        partial void FromDtoPartial(rLoaiChiPhiDto dto);
        partial void SetPropertiesDependencyPartial();
        partial void DisplayTextPartial();

        public static string DTenLoaiChiPhi;

        string oTenLoaiChiPhi;

        string _TenLoaiChiPhi = DTenLoaiChiPhi;

        public string TenLoaiChiPhi { get { return _TenLoaiChiPhi; } set { SetField(ref _TenLoaiChiPhi, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oTenLoaiChiPhi = TenLoaiChiPhi;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rLoaiChiPhiDataModel;
            if (dataModel == null)
            {
                return;
            }

            TenLoaiChiPhi = dataModel.TenLoaiChiPhi;
        }

        public override bool HasChange()
        {
            return
            (oTenLoaiChiPhi != TenLoaiChiPhi);
        }

        public override rLoaiChiPhiDto ToDto()
        {
            var dto = new rLoaiChiPhiDto();
            dto.State = State;
            dto.ID = ID;
            dto.TenLoaiChiPhi = TenLoaiChiPhi;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rLoaiChiPhiDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            TenLoaiChiPhi = dto.TenLoaiChiPhi;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        protected override void SetPropertiesDependency()
        {
            SetDependentProperty(nameof(TenLoaiChiPhi), new List<string>(){nameof(DisplayText)});
            SetPropertiesDependencyPartial();
        }

        private string _displayText;
        public override string DisplayText
        {
            get
            {
                _displayText = TenLoaiChiPhi.ToString();
                DisplayTextPartial();
                return _displayText;
            }
        }



    }
}
