using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class tChiTietChuyenHangDonHangView : BaseView<tChiTietChuyenHangDonHangDto, tChiTietChuyenHangDonHangDataModel>
    {
        partial void InitUIPartial();

        public tChiTietChuyenHangDonHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
