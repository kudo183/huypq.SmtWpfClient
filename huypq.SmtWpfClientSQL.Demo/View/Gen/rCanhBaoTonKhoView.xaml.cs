using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class rCanhBaoTonKhoView : BaseView<rCanhBaoTonKhoDto, rCanhBaoTonKhoDataModel>
    {
        partial void InitUIPartial();

        public rCanhBaoTonKhoView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
