using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class rChanhView : BaseView<rChanhDto, rChanhDataModel>
    {
        partial void InitUIPartial();

        public rChanhView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
