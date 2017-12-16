using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class rNguyenLieuView : BaseView<rNguyenLieuDto, rNguyenLieuDataModel>
    {
        partial void InitUIPartial();

        public rNguyenLieuView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
