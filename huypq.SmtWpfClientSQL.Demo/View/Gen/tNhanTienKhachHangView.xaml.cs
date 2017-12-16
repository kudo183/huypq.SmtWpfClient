using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class tNhanTienKhachHangView : BaseView<tNhanTienKhachHangDto, tNhanTienKhachHangDataModel>
    {
        partial void InitUIPartial();

        public tNhanTienKhachHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
