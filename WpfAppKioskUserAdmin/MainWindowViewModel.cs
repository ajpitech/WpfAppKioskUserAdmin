using ClassLibraryEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppKioskUserAdmin
{
    public class MainWindowViewModel : BaseViewModel
    {
        public string LoginVisibility { get; set; }
        public string LogoutVisibility { get; set; }
        public ICommand CancelLoginCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        private string username { get; set; }
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                if (username == "")
                {
                    UserNameChecker = "Visible";
                }
                else
                {
                    UserNameChecker = "Collapsed";

                }
                OnPropertyChanged(nameof(UserNameChecker));
            }
        }
        private string password { get; set; }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                if (password == "")
                {
                    PasswordChecker = "Visible";
                }
                else
                {
                    PasswordChecker = "Collapsed";

                }
                OnPropertyChanged(nameof(PasswordChecker));
            }

        }


       // Admin a { get; set; } = new Admin();
        public BaseViewModel ActiveView { get; set; }

        public MainWindowViewModel()
        {
            Logout();
            LoginCommand = new RelayCommand(LoginCommandClick);
            CancelLoginCommand = new RelayCommand(CancelLoginCommandClick);
            LogoutCommand = new RelayCommand(LogoutCommandClick);


        }

        private void LogoutCommandClick(object obj)
        {
            Logout();
        }
        public void Logout()
        { 
            LoginVisibility = "Visible";
            LogoutVisibility = "Collapsed";

            OnPropertyChanged(nameof(LoginVisibility));
            OnPropertyChanged(nameof(LogoutVisibility));
        }

        private void CancelLoginCommandClick(object obj)
        {
            Username = string.Empty;
            Password = string.Empty;
            OnPropertyChanged(nameof(Username));
            OnPropertyChanged(nameof(Password));

        }

        private void LoginCommandClick(object obj)
        {
            AdminOperation ao = new AdminOperation();
        
        
            AgentAdminLogin objlog= ao.Admin_Agent_Login(Username,Password);
            Username=string.Empty;
            password=string.Empty;

             LoginVisibility = "Collapsed";
            LogoutVisibility = "Visible";

            OnPropertyChanged(nameof(LoginVisibility));
            OnPropertyChanged(nameof(LogoutVisibility));
        }
    }
}
