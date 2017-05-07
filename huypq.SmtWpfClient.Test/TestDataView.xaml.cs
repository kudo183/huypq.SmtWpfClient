
using huypq.SmtShared.Test;
using huypq.SmtWpfClient.Abstraction;

namespace huypq.SmtWpfClient.Test
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
