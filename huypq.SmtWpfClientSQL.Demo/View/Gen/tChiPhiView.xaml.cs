using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class tChiPhiView : BaseView<tChiPhiDto, tChiPhiDataModel>
    {
        partial void InitUIPartial();

        public tChiPhiView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
