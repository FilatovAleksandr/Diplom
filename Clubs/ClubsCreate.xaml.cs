using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DClubs
{
    /// <summary>
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class ClubsCreate : Window
    {
        public ClubsCreate()
        {
            InitializeComponent();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (String.IsNullOrEmpty(NameTB.Text) || String.IsNullOrEmpty(DescTB.Text))
            {
                errors.AppendLine("Заполните все поля");
            }
            else
            {
                try
                {
                    Clubs AddClub = new Clubs { Club_Name = NameTB.Text, Club_Description = DescTB.Text };
                    ClubsEntities.GetContext().Clubs.Add(AddClub);
                    ClubsEntities.GetContext().SaveChanges();
                    MessageBox.Show("Кружок добавлен.");
                    ClubsView Window = Application.Current.Windows.OfType<ClubsView>().FirstOrDefault();
                    if (Window != null)
                    {
                        Window.Update();
                    }
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
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Turn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void StartText_Changed(object sender, TextChangedEventArgs e)
        {
            if (NameTB.Text != "")
            {
                NameMark.Visibility = Visibility.Hidden;
            }
            else
            {
                NameMark.Visibility = Visibility.Visible;
            }
        }
        private void EndText_Changed(object sender, TextChangedEventArgs e)
        {
            if (DescTB.Text != "")
            {
                DescMark.Visibility = Visibility.Hidden;
            }
            else
            {
                DescMark.Visibility = Visibility.Visible;
            }
        }
    }
}
