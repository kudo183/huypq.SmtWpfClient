using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class rLoaiHangView : BaseView<rLoaiHangDto, rLoaiHangDataModel>
    {
        partial void InitUIPartial();

        public rLoaiHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
