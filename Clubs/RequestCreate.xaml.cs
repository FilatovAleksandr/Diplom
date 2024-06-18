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
    public partial class RequestCreate : Window
    {
        public RequestCreate()
        {
            InitializeComponent();
            ClubCB.ItemsSource = ClubsEntities.GetContext().Clubs.ToList();
            ClubCB.DisplayMemberPath = "Club_Name";
            ClubCB.SelectedValuePath = "id_club";
            if (ClubCB.DisplayMemberPath == null)
            {
                ClubCB.DisplayMemberPath = null;
            }
            GroupCB.Visibility = Visibility.Hidden;
            GroupMark.Visibility = Visibility.Hidden;
            ErrorMark.Visibility = Visibility.Hidden;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (String.IsNullOrEmpty(ClubCB.Text))
            {
                errors.AppendLine("Выберите кружок");
            }
            else
                try
                {
                    Requests AddReq = new Requests { Request_Date = DateTime.Now, id_club = Convert.ToInt32(ClubCB.SelectedValue), id_status = 2, id_account = Manager.IdAccount, id_group = Convert.ToInt32(GroupCB.SelectedValue) };
                    ClubsEntities.GetContext().Requests.Add(AddReq);
                    ClubsEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена!");
                    ClubsEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    ClubsEntities.GetContext().SaveChanges();
                    RequestsView requestsview = new RequestsView();
                    requestsview.Update();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
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

        private void Club_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClubMark.Visibility = Visibility.Hidden;
            int SelClub = Convert.ToInt32(ClubCB.SelectedValue);
            GroupCB.ItemsSource = ClubsEntities.GetContext().Groups.Where(a => a.id_club == SelClub)
            .Where(a => a.GroupFullness.GroupFullness_Count <= 2).ToList();
            GroupCB.DisplayMemberPath = "Group_Name";
            GroupCB.SelectedValuePath = "id_group";
            if (GroupCB.HasItems == false)
            {
                ErrorMark.Visibility = Visibility.Visible;
                GroupCB.Visibility = Visibility.Hidden;
            }
            else
            {
                GroupCB.Visibility = Visibility.Visible;
                GroupMark.Visibility = Visibility.Visible;
                ErrorMark.Visibility = Visibility.Hidden;
            }
        }

        private void Group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GroupMark.Visibility = Visibility.Hidden;
        }
    }
}
