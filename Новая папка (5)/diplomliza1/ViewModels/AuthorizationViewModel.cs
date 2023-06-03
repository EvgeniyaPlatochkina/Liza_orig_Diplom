using diplomliza1.Services;
using diplomliza1.Data;
using diplomliza1.Data.Entities;

using diplomliza1.View;
using diplomliza1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace diplomliza1.ViewModels
{
    public class AuthorizationViewModel : ViewModelBase
    {
        public AuthorizationViewModel(Window window)
        {
            _ctx = new();
            _userService = new(_ctx);
            Window = window;
        }
        #region Context
        private ApplicationDbContext _ctx;
        #endregion
        #region Services
        private UserService _userService;
        private User _user;
        #endregion
        #region Fields & Properties
        private Window Window;
        private string _login;
        private string _password;

        public string Login { get => _login; set => Set(ref _login, value, nameof(Login)); }
        public string Password { get => _password; set => Set(ref _password, value, nameof(Password)); }
        #endregion
        #region Methods
        private bool UserIsExits()
        {
            var isExist = false;
            try
            {
                isExist = _userService.GetUsers().Any(c => c.Login == Login && c.Password == Password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return isExist;
        }

        private string GetRole()
        {
            return _userService.GetUsers().FirstOrDefault(c => c.Password == Password && c.Login == Login).Role.Title;
        }

        private bool PropertiesIsNull() => (string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Login)) ? true : false;
        private void OpenWindow()
        {

            if (PropertiesIsNull())

                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (UserIsExits())
            {

                if (GetRole() == "Сотрудник")
                {
                    var DirectorWindow = new WindowEmplooe(_ctx, _userService.GetUsers().Single(c => c.Password == Password && c.Login == Login));
                    var CurrentWindow = Application.Current.MainWindow;
                    DirectorWindow.Show();
                    Application.Current.MainWindow = DirectorWindow;
                    CurrentWindow.Close();
                    Window.Close();
                }
                else
                {
                    var AccountantWindow = new WindowQ(_ctx, _userService.GetUsers().Single(c => c.Password == Password && c.Login == Login), _userService);
                    var CurrentWindow = Application.Current.MainWindow;
                    AccountantWindow.Show();
                    Application.Current.MainWindow = AccountantWindow;
                    CurrentWindow.Close();
                    Window.Close();
                }
            }
            else
                MessageBox.Show("Учётная запись не найдена!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);


        }
        private void OpenRegistrationWindow()
        {

                    var AccountantWindow = new Registration(_ctx);
                    var CurrentWindow = Application.Current.MainWindow;
                    AccountantWindow.Show();
                    Application.Current.MainWindow = AccountantWindow;
                    CurrentWindow.Close();
                    Window.Close();
        }

        #endregion
        #region Commands
        public ICommand AuthorizationButton => new Command(authorization => OpenWindow());
        public ICommand RegistrationButton => new Command(authorization => OpenRegistrationWindow());

        #endregion
    }
}
