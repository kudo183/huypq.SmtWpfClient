using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class rKhachHangView : BaseView<rKhachHangDto, rKhachHangDataModel>
    {
        partial void InitUIPartial();

        public rKhachHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
