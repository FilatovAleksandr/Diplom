using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DClubs
{
    /// <summary>
    /// Логика взаимодействия для PartsView.xaml
    /// </summary>
    public partial class RequestsView : Page
    {
        public RequestsView()
        {
            InitializeComponent();
            ComboBoxItem CBitem = new ComboBoxItem();
            Filter.Items.Insert(0, "Все");
            Filter.Items.Insert(1, "Одобрено");
            Filter.Items.Insert(2, "Ожидание");
            Filter.Items.Insert(3, "Отклонено");
            Filter.SelectedIndex = 0;
            if (Manager.IdRole == 3)
            {
                ClubsEntities.GetContext().SaveChanges();
                ClubsEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                try
                {
                    Dg.ItemsSource = ClubsEntities.GetContext().Requests.Where(Item => Item.Accounts.Account_Phonenumber.Contains(Manager.NumAccount)).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "У вас нет запросов");
                }
                DelB.Visibility = Visibility.Hidden;
                DelB.IsEnabled = false;
                AddB.Visibility = Visibility.Visible;
                AddB.IsEnabled = true;
                ApproveB.Visibility = Visibility.Hidden;
                ApproveB.IsEnabled = false;
                RejectB.Visibility = Visibility.Hidden;
                RejectB.IsEnabled = false;
            }
            if (Manager.IdRole == 4)
            {
                ClubsEntities.GetContext().SaveChanges();
                ClubsEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                try
                {
                    Dg.ItemsSource = ClubsEntities.GetContext().Requests.Where(Item => Item.Accounts.Account_Phonenumber.Contains(Manager.NumAccount)).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "У вас нет запросов");
                }
                DelB.Visibility = Visibility.Hidden;
                DelB.IsEnabled = false;
                AddB.Visibility = Visibility.Visible;
                AddB.IsEnabled = true;
                ApproveB.Visibility = Visibility.Hidden;
                ApproveB.IsEnabled = false;
                RejectB.Visibility = Visibility.Hidden;
                RejectB.IsEnabled = false;
            }
            else
            if (Manager.IdRole == 1)
            {
                ClubsEntities.GetContext().SaveChanges();
                ClubsEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                Dg.ItemsSource = ClubsEntities.GetContext().Requests.ToList();
                DelB.Visibility = Visibility.Visible;
                DelB.IsEnabled = true;
                AddB.Visibility = Visibility.Visible;
                AddB.IsEnabled = true;
                ApproveB.Visibility = Visibility.Visible;
                ApproveB.IsEnabled = true;
                RejectB.Visibility = Visibility.Visible;
                RejectB.IsEnabled = true;
            }
            else
            if (Manager.IdRole == 2)
            {
                ClubsEntities.GetContext().SaveChanges();
                ClubsEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                Dg.ItemsSource = ClubsEntities.GetContext().Requests.ToList();
                DelB.Visibility = Visibility.Hidden;
                DelB.IsEnabled = false;
                AddB.Visibility = Visibility.Visible;
                AddB.IsEnabled = true;
                ApproveB.Visibility = Visibility.Visible;
                ApproveB.IsEnabled = true;
                RejectB.Visibility = Visibility.Visible;
                RejectB.IsEnabled = true;
            }
        }
        public void Update()
        {
            try
            {
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
                if (Manager.IdRole == 3)
                {
                    ClubsEntities.GetContext().SaveChanges();
                    ClubsEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    try
                    {
                        Dg.ItemsSource = ClubsEntities.GetContext().Requests.Where(Item => Item.Accounts.Account_Phonenumber.Contains(Manager.NumAccount)).ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "У вас нет запросов");
                    }
                    DelB.Visibility = Visibility.Hidden;
                    DelB.IsEnabled = false;
                    AddB.Visibility = Visibility.Visible;
                    AddB.IsEnabled = true;
                    ApproveB.Visibility = Visibility.Hidden;
                    ApproveB.IsEnabled = false;
                    RejectB.Visibility = Visibility.Hidden;
                    RejectB.IsEnabled = false;
                }
                else
                if (Manager.IdRole == 4)
                {
                    ClubsEntities.GetContext().SaveChanges();
                    ClubsEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    try
                    {
                        Dg.ItemsSource = ClubsEntities.GetContext().Requests.Where(Item => Item.Accounts.Account_Phonenumber.Contains(Manager.NumAccount)).ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "У вас нет запросов");
                    }
                    DelB.Visibility = Visibility.Hidden;
                    DelB.IsEnabled = false;
                    AddB.Visibility = Visibility.Visible;
                    AddB.IsEnabled = true;
                    ApproveB.Visibility = Visibility.Hidden;
                    ApproveB.IsEnabled = false;
                    RejectB.Visibility = Visibility.Hidden;
                    RejectB.IsEnabled = false;
                }
                else
                if (Manager.IdRole == 1)
                {
                    ClubsEntities.GetContext().SaveChanges();
                    ClubsEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    Dg.ItemsSource = ClubsEntities.GetContext().Requests.ToList();
                    DelB.Visibility = Visibility.Visible;
                    DelB.IsEnabled = true;
                    AddB.Visibility = Visibility.Visible;
                    AddB.IsEnabled = true;
                    ApproveB.Visibility = Visibility.Visible;
                    ApproveB.IsEnabled = true;
                    RejectB.Visibility = Visibility.Visible;
                    RejectB.IsEnabled = true;
                }
                else
                if (Manager.IdRole == 2)
                {
                    ClubsEntities.GetContext().SaveChanges();
                    ClubsEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    Dg.ItemsSource = ClubsEntities.GetContext().Requests.ToList();
                    DelB.Visibility = Visibility.Hidden;
                    DelB.IsEnabled = false;
                    AddB.Visibility = Visibility.Visible;
                    AddB.IsEnabled = true;
                    ApproveB.Visibility = Visibility.Visible;
                    ApproveB.IsEnabled = true;
                    RejectB.Visibility = Visibility.Visible;
                    RejectB.IsEnabled = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Dg.SelectedItem == null)
                {
                    int ClId = (Dg.SelectedItem as Requests).id_request;
                    Requests requests = (from r in ClubsEntities.GetContext().Requests where r.id_request == ClId select r).SingleOrDefault();
                    ClubsEntities.GetContext().Requests.Remove(requests);
                    Update();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            RequestCreate ReqCr = new RequestCreate();
            ReqCr.Show();
        }
        private void Approve_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Dg.SelectedItem != null)
                {
                    var selectedRow = (Requests)Dg.SelectedItem;
                    selectedRow.id_status = 1;
                    ClubsEntities.GetContext().SaveChanges();
                    Dg.Items.Refresh();
                    Accounts account = (from r in ClubsEntities.GetContext().Accounts where r.id_account == Manager.IdAccount select r).SingleOrDefault();
                    selectedRow.Accounts.id_role = 4;
                    Update();
                }
                else MessageBox.Show("Выберите запрос");
                Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
        private void Reject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Dg.SelectedItem != null)
                {
                    var selectedRow = (Requests)Dg.SelectedItem;
                    selectedRow.id_status = 3;
                    ClubsEntities.GetContext().SaveChanges();
                    Dg.Items.Refresh();
                }
                else MessageBox.Show("Выберите запрос");
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
            Update();
        }
        private void Filter_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (Filter.SelectedIndex == 0)
            {
                ClubsEntities.GetContext().SaveChanges();
                Dg.ItemsSource = ClubsEntities.GetContext().Requests.ToList();
            }
            else
            if (Filter.SelectedIndex == 1)
            {
                var FilterResult1 = ClubsEntities.GetContext().Requests.Where(p => p.id_status == 1).ToList();
                Dg.ItemsSource = FilterResult1;
                Dg.Items.Refresh();
            }
            else
            if (Filter.SelectedIndex == 2)
            {
                var FilterResult2 = ClubsEntities.GetContext().Requests.Where(p => p.id_status == 2).ToList();
                Dg.ItemsSource = FilterResult2;
                Dg.Items.Refresh();
            }
            else
            if (Filter.SelectedIndex == 3)
            {
                var FilterResult3 = ClubsEntities.GetContext().Requests.Where(p => p.id_status == 3).ToList();
                Dg.ItemsSource = FilterResult3;
                Dg.Items.Refresh();
            }
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
