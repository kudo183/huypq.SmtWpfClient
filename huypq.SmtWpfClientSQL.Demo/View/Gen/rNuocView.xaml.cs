using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class rNuocView : BaseView<rNuocDto, rNuocDataModel>
    {
        partial void InitUIPartial();

        public rNuocView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
