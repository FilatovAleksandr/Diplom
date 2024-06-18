using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DClubs
{
    /// <summary>
    /// Логика взаимодействия для PartsView.xaml
    /// </summary>
    public partial class UsersView : Page
    {
        public UsersView()
        {
            InitializeComponent();
            Dg.ItemsSource = ClubsEntities.GetContext().Users.ToList();
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var context = new ClubsEntities())
            {
                string searchText = Search.Text;
                var searchResult = context.Users.Where(p => p.user_login.Contains(searchText)).ToList();
                Dg.ItemsSource = searchResult;
                if (Search.Text != "")
                {
                    SearchMark.Visibility = Visibility.Hidden;
                }
                else
                {
                    SearchMark.Visibility = Visibility.Visible;
                }
            }
        }

        private void Update()
        {
            ClubsEntities.GetContext().SaveChanges();
            ClubsEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            Dg.ItemsSource = ClubsEntities.GetContext().Users.ToList();
        }
        private void Focused(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
