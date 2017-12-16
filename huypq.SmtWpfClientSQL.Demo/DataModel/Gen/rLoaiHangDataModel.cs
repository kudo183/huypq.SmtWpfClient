using huypq.SmtWpfClient.Abstraction;
using System.Collections.Generic;
using huypq.SmtWpfClientSQL.Demo.Dto;

namespace huypq.SmtWpfClientSQL.Demo.DataModel
{
    public partial class rLoaiHangDataModel : BaseDataModel<rLoaiHangDto>
    {
        partial void ToDtoPartial(ref rLoaiHangDto dto);
        partial void FromDtoPartial(rLoaiHangDto dto);
        partial void SetPropertiesDependencyPartial();
        partial void DisplayTextPartial();

        public static string DTenLoai;
        public static bool DHangNhaLam;

        string oTenLoai;
        bool oHangNhaLam;

        string _TenLoai = DTenLoai;
        bool _HangNhaLam = DHangNhaLam;

        public string TenLoai { get { return _TenLoai; } set { SetField(ref _TenLoai, value); } }
        public bool HangNhaLam { get { return _HangNhaLam; } set { SetField(ref _HangNhaLam, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oTenLoai = TenLoai;
            oHangNhaLam = HangNhaLam;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rLoaiHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            TenLoai = dataModel.TenLoai;
            HangNhaLam = dataModel.HangNhaLam;
        }

        public override bool HasChange()
        {
            return
            (oTenLoai != TenLoai) ||
            (oHangNhaLam != HangNhaLam);
        }

        public override rLoaiHangDto ToDto()
        {
            var dto = new rLoaiHangDto();
            dto.State = State;
            dto.ID = ID;
            dto.TenLoai = TenLoai;
            dto.HangNhaLam = HangNhaLam;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rLoaiHangDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            TenLoai = dto.TenLoai;
            HangNhaLam = dto.HangNhaLam;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        protected override void SetPropertiesDependency()
        {
            SetDependentProperty(nameof(TenLoai), new List<string>(){nameof(DisplayText)});
            SetPropertiesDependencyPartial();
        }

        private string _displayText;
        public override string DisplayText
        {
            get
            {
                _displayText = TenLoai.ToString();
                DisplayTextPartial();
                return _displayText;
            }
        }



    }
}
