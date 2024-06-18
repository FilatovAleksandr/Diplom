using System;
using System.Data.Entity.Validation;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DClubs
{
    /// <summary>
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (String.IsNullOrEmpty(login.Text) || String.IsNullOrEmpty(password.Password))
            {
                errors.AppendLine("Заполните все поля");
            }
            else
            {
                try
                {
                    Accounts AddAccount = new Accounts { Account_Name = NameTB.Text, Account_Surname = SurnameTB.Text, Account_Patronymic = PatronymicTB.Text, Account_Phonenumber = PhoneTB.Text, Account_Email = EmailTB.Text, Account_Birthdate = Convert.ToDateTime(DateTB.Text), id_role = 3 };
                    ClubsEntities.GetContext().Accounts.Add(AddAccount);
                    ClubsEntities.GetContext().SaveChanges();
                    int Acid = (AddAccount as Accounts).id_account;
                    Users AddUser = new Users { user_login = login.Text, user_password = password.Password, id_account = Acid };
                    ClubsEntities.GetContext().Users.Add(AddUser);
                    ClubsEntities.GetContext().SaveChanges();
                    MessageBox.Show("Регистрация успешно завершена.");
                    Login loginw = new Login();
                    loginw.Show();
                    this.Close();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                    {
                        MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            MessageBox.Show(err.ErrorMessage + "");
                        }
                    }
                }
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Login loginw = new Login();
            loginw.Show();
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

        private void DateText_Changed(object sender, TextChangedEventArgs e)
        {
            if (DateTB.Text != "")
            {
                DateMark.Visibility = Visibility.Hidden;
            }
            else
            {
                DateMark.Visibility = Visibility.Visible;
            }
            if (sender is TextBox textBox)
            {
                var text = textBox.Text.Replace(".", "");
                if (text.Length >= 2 && text.Length < 4)
                {
                    textBox.Text = text.Insert(2, ".");
                    textBox.Select(textBox.Text.Length, 0);
                }
                else if (text.Length >= 4)
                {
                    textBox.Text = text.Insert(2, ".").Insert(5, ".");
                    textBox.Select(textBox.Text.Length, 0);
                }
            }
        }

        private void EmailText_Changed(object sender, TextChangedEventArgs e)
        {
            if (EmailTB.Text != "")
            {
                EmailMark.Visibility = Visibility.Hidden;
            }
            else
            {
                EmailMark.Visibility = Visibility.Visible;
            }
        }
        private void PatronymicText_Changed(object sender, TextChangedEventArgs e)
        {
            if (PatronymicTB.Text != "")
            {
                PatronymicMark.Visibility = Visibility.Hidden;
            }
            else
            {
                PatronymicMark.Visibility = Visibility.Visible;
            }
        }
        private void SurnameText_Changed(object sender, TextChangedEventArgs e)
        {
            if (SurnameTB.Text != null)
            {
                SurnameMark.Visibility = Visibility.Hidden;
            }
            else
            {
                SurnameMark.Visibility = Visibility.Visible;
            }
        }
        private void NameText_Changed(object sender, TextChangedEventArgs e)
        {
            if (NameTB.Text != null)
            {
                NameMark.Visibility = Visibility.Hidden;
            }
            else
            {
                NameMark.Visibility = Visibility.Visible;
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
