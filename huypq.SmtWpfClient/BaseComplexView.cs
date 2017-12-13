using huypq.wpf.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace huypq.SmtWpfClient.Abstraction
{
    public abstract class BaseComplexView : UserControl
    {
        ILogger _logger = ServiceLocator.Get<ILoggerProvider>().CreateLogger<BaseComplexView>();

        public static int GetViewLevel(DependencyObject obj)
        {
            return (int)obj.GetValue(ViewLevelProperty);
        }

        public static void SetViewLevel(DependencyObject obj, int value)
        {
            obj.SetValue(ViewLevelProperty, value);
        }

        // Using a DependencyProperty as the backing store for ViewLevel. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewLevelProperty =
            DependencyProperty.RegisterAttached("ViewLevel", typeof(int), typeof(BaseComplexView), new PropertyMetadata(0));

        public static string GetFilterProperty(DependencyObject obj)
        {
            return (string)obj.GetValue(FilterPropertyProperty);
        }

        public static void SetFilterProperty(DependencyObject obj, string value)
        {
            obj.SetValue(FilterPropertyProperty, value);
        }

        // Using a DependencyProperty as the backing store for FilterProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilterPropertyProperty =
            DependencyProperty.RegisterAttached("FilterProperty", typeof(string), typeof(BaseComplexView), new PropertyMetadata(string.Empty));

        private bool _isDesignTime = true;

        public Action AllViewLoadedAction;

        List<IBaseView> _views;
        public List<IBaseView> Views
        {
            get
            {
                return _views;
            }
        }

        public BaseComplexView()
        {
            _isDesignTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject());
        }

        protected override void OnInitialized(EventArgs e)
        {
            _logger.LogDebug("BaseComplexView OnInitialized");
            InitView();
            base.OnInitialized(e);
        }

        private void InitView()
        {
            if (_isDesignTime == true)
            {
                return;
            }

            var panel = Content as Panel;

            _views = new List<IBaseView>();
            var _viewsDic = new Dictionary<int, IBaseView>();
            foreach (UIElement item in panel.Children)
            {
                if (item is IBaseView iBaseView)
                {
                    _views.Add(iBaseView);
                    var level = BaseComplexView.GetViewLevel(item);
                    if (_viewsDic.ContainsKey(level) == false)
                    {
                        _viewsDic.Add(level, iBaseView);
                    }
                    (item as UserControl).Loaded += Item_Loaded;
                }
            }

            if (_viewsDic.Count == 0)
                return;

            var viewList = new List<IBaseView>(_viewsDic.Count + 2);
            viewList.Add(_viewsDic[_viewsDic.Count - 1]);
            for (int i = 0; i < _viewsDic.Count; i++)
            {
                viewList.Add(_viewsDic[i]);
            }
            viewList.Add(_viewsDic[0]);

            for (int i = 1; i < viewList.Count - 1; i++)
            {
                var previousView = viewList[i - 1];
                var currentView = viewList[i];
                var nextView = viewList[i + 1];

                if (i < viewList.Count - 2)
                {
                    InitSelectedIndexChangedAction(currentView, nextView);
                }
                InitMoveFocusAction(currentView, nextView);
                InitAfterSave(previousView, currentView, nextView);
                InitAfterLoad(previousView, currentView, nextView);
            }
        }

        private void Item_Loaded(object sender, RoutedEventArgs e)
        {
            if (_views.Any(p => p.IsLoadedViewModel == false) == false)
            {
                AllViewLoadedAction?.Invoke();
            }
        }

        void InitAfterSave(IBaseView previousView, IBaseView currentView, IBaseView nextView)
        {
            currentView.ActionAfterSave = () =>
            {
                OnAfterSave(previousView, currentView, nextView);
            };
        }

        protected virtual void OnAfterSave(IBaseView previousView, IBaseView currentView, IBaseView nextView)
        {
            _logger.LogDebug("BaseComplexView OnAfterSave {0}", currentView.GetType().Name);
        }

        void InitAfterLoad(IBaseView previousView, IBaseView currentView, IBaseView nextView)
        {
            currentView.ActionAfterLoad = () =>
            {
                OnAfterLoad(previousView, currentView, nextView);
            };
        }

        protected virtual void OnAfterLoad(IBaseView previousView, IBaseView currentView, IBaseView nextView)
        {
            _logger.LogDebug("BaseComplexView OnAfterLoad {0}", currentView.GetType().Name);
        }

        private void InitSelectedIndexChangedAction(IBaseView currentView, IBaseView nextView)
        {
            var filterProperty = BaseComplexView.GetFilterProperty(nextView as UIElement);
            var childViewModel = nextView.ViewModel;
            var headerFilter = childViewModel.HeaderFilters.First(p => p.PropertyName == filterProperty);
            headerFilter.DisableChangedAction(p => { p.IsUsed = true; p.FilterValue = 0; });

            currentView.ViewModel.PropertyChanged += (sender, e) =>
            {
                OnSelectedIndexChanged(currentView, nextView, currentView.ViewModel.SelectedValue);
            };
        }

        protected virtual void OnSelectedIndexChanged(IBaseView currentView, IBaseView nextView, object selectedValue)
        {
            _logger.LogDebug("BaseComplexView OnSelectedIndexChanged {0}", currentView.GetType().Name);
            var viewModel = currentView.ViewModel;
            var childViewModel = nextView.ViewModel;
            var filterProperty = BaseComplexView.GetFilterProperty(nextView as UIElement);
            var headerFilter = childViewModel.HeaderFilters.First(p => p.PropertyName == filterProperty);

            childViewModel.ParentItem = viewModel.GetSelectedItem();
            if (selectedValue == null)
            {
                headerFilter.FilterValue = 0;
            }
            else
            {
                headerFilter.FilterValue = selectedValue;
            }
        }

        private void InitMoveFocusAction(IBaseView currentView, IBaseView nextView)
        {
            currentView.ActionMoveFocusToNextView = () =>
            {
                OnMoveFocus(currentView, nextView);
            };
        }

        protected virtual void OnMoveFocus(IBaseView currentView, IBaseView nextView)
        {
            _logger.LogDebug("BaseComplexView OnMoveFocus {0}", currentView.GetType().Name);
            var nextDataGrid = nextView.GridView.dataGrid;

            nextDataGrid.FocusCell(
                    nextDataGrid.Items.Count - 1,
                    nextDataGrid.FindFirstEditableColumn());
        }

    }
}
