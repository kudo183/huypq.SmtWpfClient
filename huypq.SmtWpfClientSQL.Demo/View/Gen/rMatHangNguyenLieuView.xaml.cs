using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class rMatHangNguyenLieuView : BaseView<rMatHangNguyenLieuDto, rMatHangNguyenLieuDataModel>
    {
        partial void InitUIPartial();

        public rMatHangNguyenLieuView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
