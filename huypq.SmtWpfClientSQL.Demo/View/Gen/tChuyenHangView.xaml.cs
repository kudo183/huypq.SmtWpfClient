using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class tChuyenHangView : BaseView<tChuyenHangDto, tChuyenHangDataModel>
    {
        partial void InitUIPartial();

        public tChuyenHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
