using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DClubs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool hidden;
        double panelWidth;
        DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            Manager._MainFrame = Frame;
            Manager._Usersbutton = UsersB;
            Manager._Requestsbutton = RequestsB;
            Manager._AccountButton = AccountB;
            Manager._ScheduleButton = ScheduleB;
            Manager._GroupButton = GroupB;
            using (var db = new ClubsEntities())
            {
                foreach (var groupFullness in db.GroupFullness.ToList())
                {
                    int count = db.Requests.Where(r => r.id_group == groupFullness.id_group)
                        .Select(r => r.id_request).Distinct().Count();
                    groupFullness.GroupFullness_Count = count;
                    if (count <= 20)
                    {

                    }
                }
                db.SaveChanges();
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
        private void FrameLoaded(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new AccountView());
            this.Frame.Navigate(new Uri("AccountView.xaml", UriKind.Relative));
        }
        private void Requests_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new RequestsView());
            this.Frame.Navigate(new Uri("RequestsView.xaml", UriKind.Relative));
        }
        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new ScheduleView());
            this.Frame.Navigate(new Uri("ScheduleView.xaml", UriKind.Relative));
        }
        private void Users_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new UsersView());
            this.Frame.Navigate(new Uri("UsersView.xaml", UriKind.Relative));
        }
        private void Account_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new AccountView());
            this.Frame.Navigate(new Uri("AccountView.xaml", UriKind.Relative));
        }
        private void Clubs_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new ClubsView());
            this.Frame.Navigate(new Uri("ClubsView.xaml", UriKind.Relative));
        }
        private void Group_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new GroupsView());
            this.Frame.Navigate(new Uri("GroupsView.xaml", UriKind.Relative));
        }
        private void Leave_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите выйти?",
        "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }
    }
}
