using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DClubs
{
    /// <summary>
    /// Логика взаимодействия для GroupsView.xaml
    /// </summary>
    public partial class GroupsView : Page
    {
        public GroupsView()
        {
            InitializeComponent();
            Dg.ItemsSource = ClubsEntities.GetContext().Groups.ToList();
        }
        public void Update()
        {
            Dg.ItemsSource = ClubsEntities.GetContext().Groups.ToList();
            ClubsEntities.GetContext().SaveChanges();
            ClubsEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
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
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ClId = (Dg.SelectedItem as Groups).id_group;
                Groups gr = (from r in ClubsEntities.GetContext().Groups where r.id_group == ClId select r).SingleOrDefault();
                ClubsEntities.GetContext().Groups.Remove(gr);
                GroupFullness gf = (from r in ClubsEntities.GetContext().GroupFullness where r.id_groupfullness == ClId select r).SingleOrDefault();
                ClubsEntities.GetContext().GroupFullness.Remove(gf);
                Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            GroupCreate GrCr = new GroupCreate();
            GrCr.Show();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
