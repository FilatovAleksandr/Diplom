using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DClubs
{
    /// <summary>
    /// Логика взаимодействия для PartsView.xaml
    /// </summary>
    public partial class AccountView : Page
    {
        public AccountView()
        {
            InitializeComponent();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ClubsEntities.GetContext().SaveChanges();
            ClubsEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            Dg.ItemsSource = ClubsEntities.GetContext().Accounts.ToList();
            try
            {
                Dg.ItemsSource = ClubsEntities.GetContext().Accounts.Where(Item => Item.Account_Phonenumber.Contains(Manager.NumAccount)).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка аккаунта");
            }
        }
    }
}