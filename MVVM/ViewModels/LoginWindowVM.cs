using System.Data.Entity.Core.Common.EntitySql;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using CMP332.Core;
using CMP332.Core.Data;
using CMP332.Core.Utils;
using CMP332.MVVM.Models.User;
using Unity;

namespace CMP332.MVVM.ViewModels
{
    public class LoginWindowVM : ObservableObject
    {

        public RelayCommand LoginCommand { get; set; }

        private string _username;
        private string _password;
        private string _validationError { get; set; }
        private Visibility _isVisible { get; set; }
        private IRepository<User> userContext;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                this.OnPropertyChanged();
            }
        }
        
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                this.OnPropertyChanged();
            }
        }
        
        public string ValidationError
        {
            get => _validationError;
            set
            {
                _validationError = value;
                this.OnPropertyChanged();
            }
        }

        public Visibility IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                this.OnPropertyChanged();
            }
        }

        public LoginWindowVM()
        {
            this.userContext = ContainerHelper.Container.Resolve<IRepository<User>>();
            Username = "Username";
            Password = "Password";
            
            LoginCommand = new RelayCommand(o =>
            {
                this.handleLogin();
            });
        }

        private void handleLogin()
        {
            if (!Validator.isValidPassword(Password))
            {
                ValidationError = "Minimum eight characters, at least one letter and one number";
                return;
            }
            
            // Handle login here
            //// We access dbset as typing single to be apart of the context is quite compliacted
            //User user = this.userContext.dbSet.Single(t => t.Username.Equals(this.Username));

            //if (user.Password.Equals(this.Password))
            //{
            //    this.IsVisible = Visibility.Hidden;
            //}

        }
        
    }
}