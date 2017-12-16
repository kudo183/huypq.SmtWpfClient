using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class rNhaCungCapView : BaseView<rNhaCungCapDto, rNhaCungCapDataModel>
    {
        partial void InitUIPartial();

        public rNhaCungCapView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
