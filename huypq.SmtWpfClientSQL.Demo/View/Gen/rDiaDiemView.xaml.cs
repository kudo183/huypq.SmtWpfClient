using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class rDiaDiemView : BaseView<rDiaDiemDto, rDiaDiemDataModel>
    {
        partial void InitUIPartial();

        public rDiaDiemView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
