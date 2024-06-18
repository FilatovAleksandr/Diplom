using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DClubs
{
    /// <summary>
    /// Логика взаимодействия для RequestCreate.xaml
    /// </summary>
    public partial class GroupCreate : Window
    {
        public GroupCreate()
        {
            InitializeComponent();
            ClubCB.ItemsSource = ClubsEntities.GetContext().Clubs.ToList();
            ClubCB.DisplayMemberPath = "Club_Name";
            ClubCB.SelectedValuePath = "id_club";
            ClubCB.Text = "Выберите кружок";
            TeacherCB.ItemsSource = ClubsEntities.GetContext().Accounts.Where(a => a.id_role == 2).ToList();
            TeacherCB.DisplayMemberPath = "Account_Surname";
            TeacherCB.SelectedValuePath = "id_account";
            TeacherCB.Text = "Выберите кружок";

        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (String.IsNullOrEmpty(ClubCB.Text) && (String.IsNullOrEmpty(TeacherCB.Text)))
            {
                errors.AppendLine("Заполните поля");
            }
            else
            {
                try
                {
                    Groups AddGr = new Groups { id_club = Convert.ToInt32(ClubCB.SelectedValue), id_account = Convert.ToInt32(TeacherCB.SelectedValue), Group_Name = Convert.ToInt32(NameTB.Text) };
                ClubsEntities.GetContext().Groups.Add(AddGr);
                ClubsEntities.GetContext().SaveChanges();
                GroupFullness AddFullness = new GroupFullness { id_groupfullness = AddGr.id_group, id_group = AddGr.id_group };
                ClubsEntities.GetContext().GroupFullness.Add(AddFullness);
                ClubsEntities.GetContext().SaveChanges();
                AddGr.id_groupfullness = AddGr.id_group;
                ClubsEntities.GetContext().SaveChanges();
                ClubsEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                MessageBox.Show("Информация сохранена!");
                this.Close();
                GroupsView groupsView = new GroupsView();
                groupsView.Update();
            }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application app = Application.Current;
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

        private void NameText_Changed(object sender, TextChangedEventArgs e)
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

        private void Teacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TeacherMark.Visibility = Visibility.Hidden;
        }

        private void Club_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClubMark.Visibility = Visibility.Hidden;
        }
    }
}
