
using huypq.SmtSharedTest;
using huypq.SmtWpfClient.Abstraction;

namespace huypq.SmtWpfClientTest
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
