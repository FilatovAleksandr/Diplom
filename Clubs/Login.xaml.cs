using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DClubs
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (login.Text.Length > 0)
                {
                    if (password.Password.Length > 0)
                    {

                        string username = login.Text;
                        string pword = password.Password;
                        using (var context = new ClubsEntities())
                        {
                            var user = context.Users.FirstOrDefault(u => u.user_login == username && u.user_password == pword);
                            if (user != null)
                            {
                                int roleId = Convert.ToInt32(user.Accounts.id_role);
                                int accId = Convert.ToInt32(user.id_account);
                                int usId = user.id_user;
                                string accountnum = user.Accounts.Account_Phonenumber;
                                Manager.IdRole = roleId;
                                Manager.NumAccount = accountnum;
                                Manager.IdAccount = accId;
                                Manager.IdUser = usId;
                                if (roleId == 1)
                                {
                                    MessageBox.Show("Вход выполнен успешно!");
                                    MainWindow win = new MainWindow();
                                    Manager._Usersbutton.Visibility = Visibility.Visible;
                                    Manager._Usersbutton.IsEnabled = true;
                                    Manager._Requestsbutton.Visibility = Visibility.Visible;
                                    Manager._Requestsbutton.IsEnabled = true;
                                    Manager._AccountButton.Visibility = Visibility.Visible;
                                    Manager._AccountButton.IsEnabled = true;
                                    Manager._ScheduleButton.Visibility = Visibility.Visible;
                                    Manager._ScheduleButton.IsEnabled = true;
                                    Manager._GroupButton.Visibility = Visibility.Visible;
                                    Manager._GroupButton.IsEnabled = true;
                                    win.Show();
                                    this.Close();
                                }
                                else if (roleId == 2)
                                {
                                    MessageBox.Show("Вход выполнен успешно!");
                                    MainWindow win = new MainWindow();
                                    Manager._Usersbutton.Visibility = Visibility.Hidden;
                                    Manager._Usersbutton.IsEnabled = false;
                                    Manager._Requestsbutton.Visibility = Visibility.Visible;
                                    Manager._Requestsbutton.IsEnabled = true;
                                    Manager._AccountButton.Visibility = Visibility.Visible;
                                    Manager._AccountButton.IsEnabled = true;
                                    Manager._ScheduleButton.Visibility = Visibility.Visible;
                                    Manager._ScheduleButton.IsEnabled = true;
                                    Manager._GroupButton.Visibility = Visibility.Visible;
                                    Manager._GroupButton.IsEnabled = true;
                                    win.Show();
                                    this.Close();
                                }
                                else if (roleId == 3)
                                {
                                    MessageBox.Show("Вход выполнен успешно!");
                                    MainWindow win = new MainWindow();
                                    Manager._Usersbutton.Visibility = Visibility.Hidden;
                                    Manager._Usersbutton.IsEnabled = false;
                                    Manager._Requestsbutton.Visibility = Visibility.Visible;
                                    Manager._Requestsbutton.IsEnabled = true;
                                    Manager._AccountButton.Visibility = Visibility.Visible;
                                    Manager._AccountButton.IsEnabled = true;
                                    Manager._ScheduleButton.Visibility = Visibility.Hidden;
                                    Manager._ScheduleButton.IsEnabled = true;
                                    Manager._GroupButton.Visibility = Visibility.Hidden;
                                    Manager._GroupButton.IsEnabled = false;
                                    win.Show();
                                    this.Close();
                                }
                                else if (roleId == 4)
                                {
                                    MessageBox.Show("Вход выполнен успешно!");
                                    MainWindow win = new MainWindow();
                                    Manager._Usersbutton.Visibility = Visibility.Hidden;
                                    Manager._Usersbutton.IsEnabled = false;
                                    Manager._Requestsbutton.Visibility = Visibility.Visible;
                                    Manager._Requestsbutton.IsEnabled = true;
                                    Manager._AccountButton.Visibility = Visibility.Visible;
                                    Manager._AccountButton.IsEnabled = true;
                                    Manager._ScheduleButton.Visibility = Visibility.Visible;
                                    Manager._ScheduleButton.IsEnabled = true;
                                    Manager._GroupButton.Visibility = Visibility.Hidden;
                                    Manager._GroupButton.IsEnabled = false;
                                    win.Show();
                                    this.Close();
                                }
                            }
                            else
                            {
                                // Ошибка входа
                                MessageBox.Show("Неверное имя пользователя или пароль.");
                            }
                        }
                    }
                    else MessageBox.Show("Введите пароль");
                }
                else MessageBox.Show("Введите логин");
            }
            catch
            {
                MessageBox.Show("Ошибка подключения к базе данных");
            }
        }


        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp Signupw = new SignUp();
            Signupw.Show();
            this.Close();
        }

        private void LoginText_Changed(object sender, TextChangedEventArgs e)
        {
            if (login.Text != "")
            {
                LoginMark.Visibility = Visibility.Hidden;
            }
            else
            {
                LoginMark.Visibility = Visibility.Visible;
            }
        }

        private void PassswordText_Changed(object sender, RoutedEventArgs e)
        {
            if (password.Password != "")
            {
                PasswordMark.Visibility = Visibility.Hidden;
            }
            else
            {
                PasswordMark.Visibility = Visibility.Visible;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application app = Application.Current;
            app.Shutdown();
        }

        private void Turn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
