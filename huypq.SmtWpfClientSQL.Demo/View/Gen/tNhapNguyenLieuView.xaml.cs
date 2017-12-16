using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class tNhapNguyenLieuView : BaseView<tNhapNguyenLieuDto, tNhapNguyenLieuDataModel>
    {
        partial void InitUIPartial();

        public tNhapNguyenLieuView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
