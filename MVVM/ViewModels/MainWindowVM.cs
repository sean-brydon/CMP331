using System.Windows;
using CMP332.Core;

namespace CMP332.MVVM.ViewModels
{
    public class MainWindowVM : ObservableObject
    {
        public HomeWindowVM HomeVM { get; set; }

        private Visibility _isVisible;
        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public Visibility IsVisible
        {
            get => _isVisible;
            set
            {      
                _isVisible = value;
                OnPropertyChanged();
            }
        }

        public MainWindowVM()
        {
            IsVisible = Visibility.Visible;
            HomeVM = new HomeWindowVM();
            CurrentView = HomeVM;
        }
    }
}