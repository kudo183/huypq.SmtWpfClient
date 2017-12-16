using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class rLoaiNguyenLieuView : BaseView<rLoaiNguyenLieuDto, rLoaiNguyenLieuDataModel>
    {
        partial void InitUIPartial();

        public rLoaiNguyenLieuView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
