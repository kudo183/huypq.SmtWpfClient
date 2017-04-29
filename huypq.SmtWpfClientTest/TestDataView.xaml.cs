
using huypq.SmtSharedTest;
using huypq.SmtWpfClient.Abstraction;

namespace huypq.SmtWpfClientTest
{
    public partial class TestDataView : BaseView<TestDataDto>
    {
        partial void InitUIPartial();

        public TestDataView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
