using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class tChiTietToaHangView : BaseView<tChiTietToaHangDto, tChiTietToaHangDataModel>
    {
        partial void InitUIPartial();

        public tChiTietToaHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
