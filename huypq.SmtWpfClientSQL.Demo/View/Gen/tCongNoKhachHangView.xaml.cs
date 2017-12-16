using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class tCongNoKhachHangView : BaseView<tCongNoKhachHangDto, tCongNoKhachHangDataModel>
    {
        partial void InitUIPartial();

        public tCongNoKhachHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
