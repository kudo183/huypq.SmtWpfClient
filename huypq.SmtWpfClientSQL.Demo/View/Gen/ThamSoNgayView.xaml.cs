using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class ThamSoNgayView : BaseView<ThamSoNgayDto, ThamSoNgayDataModel>
    {
        partial void InitUIPartial();

        public ThamSoNgayView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
