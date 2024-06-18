using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DClubs
{
    /// <summary>
    /// Логика взаимодействия для PartsView.xaml
    /// </summary>
    public partial class ScheduleView : Page
    {
        public ScheduleView()
        {
            InitializeComponent();
            ClubsEntities.GetContext().SaveChanges();
            ClubsEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            Dg.ItemsSource = ClubsEntities.GetContext().Schedule.ToList();
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
            Dg.ItemsSource = ClubsEntities.GetContext().Schedule.ToList();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int ClId = (Dg.SelectedItem as Schedule).id_schedule;
            Schedule schedule = (from r in ClubsEntities.GetContext().Schedule where r.id_schedule == ClId select r).SingleOrDefault();
            ClubsEntities.GetContext().Schedule.Remove(schedule);
            Update();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ScheduleCreate SchCr = new ScheduleCreate();
            SchCr.Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
