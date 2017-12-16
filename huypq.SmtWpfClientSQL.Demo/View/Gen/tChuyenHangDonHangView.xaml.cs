using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class tChuyenHangDonHangView : BaseView<tChuyenHangDonHangDto, tChuyenHangDonHangDataModel>
    {
        partial void InitUIPartial();

        public tChuyenHangDonHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
