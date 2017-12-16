using huypq.SmtWpfClient.Abstraction;
using System.Collections.Generic;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.DataModel
{
    public partial class rChanhDataModel : BaseDataModel<rChanhDto>
    {
        partial void ToDtoPartial(ref rChanhDto dto);
        partial void FromDtoPartial(rChanhDto dto);
        partial void SetPropertiesDependencyPartial();
        partial void DisplayTextPartial();

        public static int DMaBaiXe;
        public static string DTenChanh;

        int oMaBaiXe;
        string oTenChanh;

        int _MaBaiXe = DMaBaiXe;
        string _TenChanh = DTenChanh;

        public int MaBaiXe { get { return _MaBaiXe; } set { SetField(ref _MaBaiXe, value); } }
        public string TenChanh { get { return _TenChanh; } set { SetField(ref _TenChanh, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaBaiXe = MaBaiXe;
            oTenChanh = TenChanh;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rChanhDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaBaiXe = dataModel.MaBaiXe;
            TenChanh = dataModel.TenChanh;
        }

        public override bool HasChange()
        {
            return
            (oMaBaiXe != MaBaiXe) ||
            (oTenChanh != TenChanh);
        }

        public override rChanhDto ToDto()
        {
            var dto = new rChanhDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaBaiXe = MaBaiXe;
            dto.TenChanh = TenChanh;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rChanhDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            MaBaiXe = dto.MaBaiXe;
            TenChanh = dto.TenChanh;
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

        rBaiXeDataModel _MaBaiXeNavigation;

        public rBaiXeDataModel MaBaiXeNavigation { get { return _MaBaiXeNavigation; } set { SetField(ref _MaBaiXeNavigation, value); } }

        object _MaBaiXeDataSource;

        public object MaBaiXeDataSource { get { return _MaBaiXeDataSource; } set { SetField(ref _MaBaiXeDataSource, value); } }
    }
}
