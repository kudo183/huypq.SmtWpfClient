using huypq.SmtWpfClient.Abstraction;
using System.Collections.Generic;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.DataModel
{
    public partial class rBaiXeDataModel : BaseDataModel<rBaiXeDto>
    {
        partial void ToDtoPartial(ref rBaiXeDto dto);
        partial void FromDtoPartial(rBaiXeDto dto);
        partial void SetPropertiesDependencyPartial();
        partial void DisplayTextPartial();

        public static string DDiaDiemBaiXe;

        string oDiaDiemBaiXe;

        string _DiaDiemBaiXe = DDiaDiemBaiXe;

        public string DiaDiemBaiXe { get { return _DiaDiemBaiXe; } set { SetField(ref _DiaDiemBaiXe, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oDiaDiemBaiXe = DiaDiemBaiXe;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rBaiXeDataModel;
            if (dataModel == null)
            {
                return;
            }

            DiaDiemBaiXe = dataModel.DiaDiemBaiXe;
        }

        public override bool HasChange()
        {
            return
            (oDiaDiemBaiXe != DiaDiemBaiXe);
        }

        public override rBaiXeDto ToDto()
        {
            var dto = new rBaiXeDto();
            dto.State = State;
            dto.ID = ID;
            dto.DiaDiemBaiXe = DiaDiemBaiXe;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rBaiXeDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            DiaDiemBaiXe = dto.DiaDiemBaiXe;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        protected override void SetPropertiesDependency()
        {
            SetDependentProperty(nameof(DiaDiemBaiXe), new List<string>(){nameof(DisplayText)});
            SetPropertiesDependencyPartial();
        }

        private string _displayText;
        public override string DisplayText
        {
            get
            {
                _displayText = DiaDiemBaiXe.ToString();
                DisplayTextPartial();
                return _displayText;
            }
        }



    }
}
