using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class rPhuongTienView : BaseView<rPhuongTienDto, rPhuongTienDataModel>
    {
        partial void InitUIPartial();

        public rPhuongTienView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
