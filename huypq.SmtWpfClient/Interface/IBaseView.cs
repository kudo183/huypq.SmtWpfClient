using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using System;

namespace huypq.SmtWpfClient.Abstraction
{
    public interface IBaseView
    {
        IEditableGridViewModel ViewModel { get; set; }
        EditableGridView GridView { get; set; }
        Action ActionAfterSave { get; set; }
        Action ActionAfterLoad { get; set; }
        Action ActionMoveFocusToNextView { get; set; }
    }
}
