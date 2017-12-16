using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class tMatHangView : BaseView<tMatHangDto, tMatHangDataModel>
    {
        partial void InitUIPartial();

        public tMatHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
