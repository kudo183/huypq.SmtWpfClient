using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class tChiTietChuyenKhoView : BaseView<tChiTietChuyenKhoDto, tChiTietChuyenKhoDataModel>
    {
        partial void InitUIPartial();

        public tChiTietChuyenKhoView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
