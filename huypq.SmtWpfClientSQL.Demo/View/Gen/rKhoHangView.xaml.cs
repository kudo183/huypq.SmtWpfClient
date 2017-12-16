using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class rKhoHangView : BaseView<rKhoHangDto, rKhoHangDataModel>
    {
        partial void InitUIPartial();

        public rKhoHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
