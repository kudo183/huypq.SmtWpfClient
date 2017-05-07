
using huypq.SmtShared.Test;
using huypq.SmtWpfClient.Abstraction;

namespace huypq.SmtWpfClient.Test
{
    public partial class TestChildDataView : BaseView<TestChildDataDto>
    {
        partial void InitUIPartial();

        public TestChildDataView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
