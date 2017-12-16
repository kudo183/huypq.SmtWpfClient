using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class rNhanVienView : BaseView<rNhanVienDto, rNhanVienDataModel>
    {
        partial void InitUIPartial();

        public rNhanVienView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
