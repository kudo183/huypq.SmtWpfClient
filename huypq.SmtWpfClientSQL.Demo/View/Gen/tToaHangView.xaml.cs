using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class tToaHangView : BaseView<tToaHangDto, tToaHangDataModel>
    {
        partial void InitUIPartial();

        public tToaHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
