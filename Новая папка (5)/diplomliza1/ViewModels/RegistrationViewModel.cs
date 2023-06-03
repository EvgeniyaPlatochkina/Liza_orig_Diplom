using diplomliza1.Data;
using diplomliza1.Data.Entities;
using diplomliza1.Services;
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
    public class RegistrationViewModel : ViewModelBase
    {
        public RegistrationViewModel(ApplicationDbContext ctx)
        {
            _userService = new(ctx);
        }
        private UserService _userService;
        private string _lastName;
        private string _firstName;
        private string _phone;
        private string _login;
        private string _password;

        public string LastName { get => _lastName; set => Set(ref _lastName, value, nameof(LastName)); }
        public string FirstName { get => _firstName; set => Set(ref _firstName, value, nameof(FirstName)); }
        public string Login { get => _login; set => Set(ref _login, value, nameof(Login)); }
        public string Password { get => _password; set => Set(ref _password, value, nameof(Password)); }

        private bool ClientIsExist() => _userService.GetUsers().Any(c => c.Password == Password && c.Login == Login);
        private bool PasswordAlredyInUse() => _userService.GetUsers().Any(c => c.Password == Password);
        private bool LoginAlredyInUse() => _userService.GetUsers().Any(c => c.Login == Login);

        private bool PropertiesIsNull() => (string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(FirstName)  || string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password));
        // проверка на корректность данных
        private void Registration()
        {
            if (PropertiesIsNull())
                MessageBox.Show("Все поля должны быть заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (ClientIsExist())
                MessageBox.Show("Используйте другой логин и пароль!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (PasswordAlredyInUse())
                MessageBox.Show("Используйте другой пароль!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (LoginAlredyInUse())
                MessageBox.Show("Используйте другой логин!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                _userService.Insert(new User { Login = Login, Password = Password, FirstName = FirstName, LastName = LastName,RoleId =2});
                MessageBox.Show("Учётная запись зарегистрирована!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                OpenAuthorizationWindow();
            }
        }
        private void OpenAuthorizationWindow()
        {
            var AuthorizationWindow = new MainWindow();
            var CurrentWindow = Application.Current.MainWindow;
            AuthorizationWindow.Show();
            Application.Current.MainWindow = AuthorizationWindow;
            CurrentWindow.Close();
        }

        #region Commands
        public ICommand Registrationbutton => new Command(registration => Registration());
        public ICommand ExitButton => new Command(exit => OpenAuthorizationWindow());
        #endregion
    }
}
