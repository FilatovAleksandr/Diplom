using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DClubs
{
    /// <summary>
    /// Логика взаимодействия для PartsView.xaml
    /// </summary>
    public partial class ClubsView : Page
    {
        public ClubsView()
        {
            InitializeComponent();
            ClubsEntities.GetContext().SaveChanges();
            ClubsEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            Dg.ItemsSource = ClubsEntities.GetContext().Clubs.ToList();
            if (Manager.IdRole == 3)
            {
                DelB.Visibility = Visibility.Hidden;
                DelB.IsEnabled = false;
                AddB.Visibility = Visibility.Hidden;
                AddB.IsEnabled = false;
            }
            if (Manager.IdRole == 4)
            {
                DelB.Visibility = Visibility.Hidden;
                DelB.IsEnabled = false;
                AddB.Visibility = Visibility.Hidden;
                AddB.IsEnabled = true;
            }
            else
            if (Manager.IdRole == 1)
            {
                DelB.Visibility = Visibility.Visible;
                DelB.IsEnabled = true;
                AddB.Visibility = Visibility.Visible;
                AddB.IsEnabled = true;
            }
            else
            if (Manager.IdRole == 2)
            {
                DelB.Visibility = Visibility.Hidden;
                DelB.IsEnabled = false;
                AddB.Visibility = Visibility.Visible;
                AddB.IsEnabled = true;
            }
        }
        public void Update()
        {
            ClubsEntities.GetContext().SaveChanges();
            ClubsEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            Dg.ItemsSource = ClubsEntities.GetContext().Clubs.ToList();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int ClId = (Dg.SelectedItem as Clubs).id_club;
            Clubs club = (from r in ClubsEntities.GetContext().Clubs where r.id_club == ClId select r).SingleOrDefault();
            ClubsEntities.GetContext().Clubs.Remove(club);
            Update();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ClubsCreate ClCr = new ClubsCreate();
            ClCr.Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
