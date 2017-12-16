using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class tChiTietDonHangView : BaseView<tChiTietDonHangDto, tChiTietDonHangDataModel>
    {
        partial void InitUIPartial();

        public tChiTietDonHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
