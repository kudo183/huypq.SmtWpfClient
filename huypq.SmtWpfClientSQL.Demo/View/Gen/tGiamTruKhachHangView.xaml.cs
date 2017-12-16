using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class tGiamTruKhachHangView : BaseView<tGiamTruKhachHangDto, tGiamTruKhachHangDataModel>
    {
        partial void InitUIPartial();

        public tGiamTruKhachHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
