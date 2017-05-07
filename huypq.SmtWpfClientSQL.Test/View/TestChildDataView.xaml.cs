
using huypq.SmtSharedTest;
using huypq.SmtWpfClient.Abstraction;

namespace huypq.SmtWpfClientSQL.Test.View
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
