using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class rLoaiChiPhiView : BaseView<rLoaiChiPhiDto, rLoaiChiPhiDataModel>
    {
        partial void InitUIPartial();

        public rLoaiChiPhiView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
