using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class rBaiXeView : BaseView<rBaiXeDto, rBaiXeDataModel>
    {
        partial void InitUIPartial();

        public rBaiXeView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
