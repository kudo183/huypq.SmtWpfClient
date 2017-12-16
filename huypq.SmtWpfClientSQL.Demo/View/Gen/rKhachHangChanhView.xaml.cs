using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class rKhachHangChanhView : BaseView<rKhachHangChanhDto, rKhachHangChanhDataModel>
    {
        partial void InitUIPartial();

        public rKhachHangChanhView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
