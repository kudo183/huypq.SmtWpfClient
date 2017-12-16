using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class tPhuThuKhachHangView : BaseView<tPhuThuKhachHangDto, tPhuThuKhachHangDataModel>
    {
        partial void InitUIPartial();

        public tPhuThuKhachHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
