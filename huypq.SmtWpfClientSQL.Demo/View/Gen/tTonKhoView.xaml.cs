using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class tTonKhoView : BaseView<tTonKhoDto, tTonKhoDataModel>
    {
        partial void InitUIPartial();

        public tTonKhoView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
