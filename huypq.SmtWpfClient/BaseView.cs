using huypq.SmtShared;
using huypq.wpf.Utils;
using Microsoft.Extensions.Logging;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace huypq.SmtWpfClient.Abstraction
{
    public class BaseView<T, T1> : UserControl, IBaseView where T : class, IDto, new() where T1 : class, IDataModel<T>, new()
    {
        ILogger _logger;

        string _viewName;
        public string ViewName { get { return _viewName; } }

        protected bool _isLoaded = false;
        public bool IsLoadedViewModel { get { return _isLoaded; } }
        public Action ActionAfterSave { get; set; }
        public Action ActionAfterLoad { get; set; }
        public Action ActionMoveFocusToNextView { get; set; }

        public DataGridExt.KeepSelection KeepSelectionType
        {
            get
            {
                if (GridView != null && GridView.dataGrid != null)
                    return GridView.dataGrid.KeepSelectionType;

                return DataGridExt.KeepSelection.KeepSelectedIndex;
            }
            set
            {
                if (GridView != null && GridView.dataGrid != null)
                    GridView.dataGrid.KeepSelectionType = value;
            }
        }

        public EditableGridView GridView { get; set; }

        private IViewModelFactory _viewModelFactory;
        public IViewModelFactory ViewModelFactory
        {
            get
            {
                if (_viewModelFactory == null)
                {
                    _viewModelFactory = ServiceLocator.Get<IViewModelFactory>();
                }
                return _viewModelFactory;
            }
            private set { }
        }

        public IEditableGridViewModel ViewModel { get; set; }

        private bool _isDesignTime;
        public BaseView()
        {
            _isDesignTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject());
            if (_isDesignTime == true)
            {
                return;
            }

            _viewName = NameManager.Instance.GetViewName<T, T1>();
            _logger = ServiceLocator.Get<ILoggerProvider>().CreateLogger<BaseView<T, T1>>();
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }

        public void InitView()
        {
            if (_isDesignTime == true)
            {
                return;
            }

            _logger.LogDebug("InitView {0}", ViewName);

            GridView = Content as EditableGridView;
            if (ViewModel == null)
            {
                var viewModelObject = ViewModelFactory.CreateViewModel<T, T1>();
                ViewModel = viewModelObject as IEditableGridViewModel<T1>;
            }

            ViewModel.ShowDialogAction = (content, title) =>
            {
                var w = new Window()
                {
                    Title = title,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen,
                    Content = content,
                    Owner = Window.GetWindow(this)
                };
                w.ShowDialog();
            };

            ViewModel.SaveCommand = new SimpleCommand("SaveCommand", () =>
            {
                _logger.LogInformation("Save {0}", ViewName);
                GridView.dataGrid.CommitEdit(DataGridEditingUnit.Row, true);
                ViewModel.Save();
                ActionAfterSave?.Invoke();
            });

            ViewModel.LoadCommand = new SimpleCommand("LoadCommand", () =>
            {
                _logger.LogInformation("Load {0}", ViewName);
                GridView.dataGrid.CommitEdit(DataGridEditingUnit.Row, true);
                ViewModel.Load();
                ActionAfterLoad?.Invoke();
            });

            DataContext = ViewModel;

            for (int i = 0; i < ViewModel.HeaderFilters.Count; i++)
            {
                var filter = ViewModel.HeaderFilters[i];
                if (filter.IsShowInUI == false)
                {
                    continue;
                }
                foreach (var column in GridView.Columns)
                {
                    if (column.Header.ToString() == filter.PropertyName)
                    {
                        column.Header = filter;
                        break;
                    }
                }
            }
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F3:
                    ViewModel.SaveCommand.Execute(null);
                    break;
                case Key.F4:
                    ViewModel.SaveCommand.Execute(null);
                    ActionMoveFocusToNextView?.Invoke();
                    break;
                case Key.F5:
                    ViewModel.LoadCommand.Execute(null);
                    break;
                default:
                    base.OnPreviewKeyDown(e);
                    break;
            }
        }

        protected override void OnInitialized(EventArgs e)
        {
            InitView();
            base.OnInitialized(e);
        }

        public virtual void OnUnloaded(object sender, RoutedEventArgs e)
        {
            _logger.LogDebug("Unloaded {0}", ViewName);

            _isLoaded = false;
        }

        public virtual void OnLoaded(object sender, RoutedEventArgs e)
        {
            _logger.LogDebug("Loaded {0}", ViewName);

            if (_isLoaded == false)
            {
                try
                {
                    ViewModel.LoadReferenceData();
                }
                catch (System.Net.WebException ex)
                {
                    if (ex.Response != null)
                    {
                        var statusCode = ((System.Net.HttpWebResponse)ex.Response).StatusCode;
                        ViewModel.SysMsg = string.Format("[{0}] {1}", statusCode, new System.IO.StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
                    }
                    else
                    {
                        ViewModel.SysMsg = ex.Message;
                    }
                }
                catch (Exception ex)
                {
                    ViewModel.SysMsg = ex.Message;
                }
                ViewModel.Load();
                _isLoaded = true;
            }
        }
    }
}
