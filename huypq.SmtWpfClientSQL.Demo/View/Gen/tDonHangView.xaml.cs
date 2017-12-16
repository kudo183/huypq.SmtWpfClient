using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class tDonHangView : BaseView<tDonHangDto, tDonHangDataModel>
    {
        partial void InitUIPartial();

        public tDonHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
