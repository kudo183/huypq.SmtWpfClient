using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class tChuyenKhoView : BaseView<tChuyenKhoDto, tChuyenKhoDataModel>
    {
        partial void InitUIPartial();

        public tChuyenKhoView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
