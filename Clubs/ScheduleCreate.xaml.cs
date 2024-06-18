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
    public partial class ScheduleCreate : Window
    {
        public ScheduleCreate()
        {
            InitializeComponent();
            GroupCB.ItemsSource = ClubsEntities.GetContext().Groups.ToList();
            GroupCB.DisplayMemberPath = "Group_Name";
            GroupCB.SelectedValuePath = "id_group";
            DayCB.Items.Insert(0, "Понедельник");
            DayCB.Items.Add("Вторник");
            DayCB.Items.Add("Среда");
            DayCB.Items.Add("Четверг");
            DayCB.Items.Add("Пятница");
            DayCB.Items.Add("Суботта");
            DayCB.Items.Add("Воскресенье");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (String.IsNullOrEmpty(DayCB.Text) || String.IsNullOrEmpty(GroupCB.Text) || String.IsNullOrEmpty(StartTB.Text) || String.IsNullOrEmpty(EndTB.Text))
            {
                errors.AppendLine("Заполните все поля");
            }
            else
            {
                try
                {
                    Schedule AddSchedule = new Schedule { Schedule_DayOfWeek = Convert.ToString(DayCB.SelectedValue), Schedule_StartTime = StartTB.Text, Schedule_EndTime = EndTB.Text, id_group = Convert.ToInt32(GroupCB.SelectedValue) };
                    ClubsEntities.GetContext().Schedule.Add(AddSchedule);
                    ClubsEntities.GetContext().SaveChanges();
                    MessageBox.Show("Расписание добавлено.");
                    ScheduleView Window = Application.Current.Windows.OfType<ScheduleView>().FirstOrDefault();
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
            ScheduleView Window = Application.Current.Windows.OfType<ScheduleView>().FirstOrDefault();
            if (Window != null)
            {
                Window.Update();
            }
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
            if (StartTB.Text != "")
            {
                StartMark.Visibility = Visibility.Hidden;
            }
            else
            {
                StartMark.Visibility = Visibility.Visible;
            }
            if (sender is TextBox textBox)
            {
                var text = textBox.Text.Replace(":", "");
                if (text.Length >= 2 && text.Length < 4)
                {
                    textBox.Text = text.Insert(2, ":");
                    textBox.Select(textBox.Text.Length, 0);
                }
            }
        }
        private void EndText_Changed(object sender, TextChangedEventArgs e)
        {
            if (EndTB.Text != "")
            {
                EndMark.Visibility = Visibility.Hidden;
            }
            else
            {
                EndMark.Visibility = Visibility.Visible;
            }
            if (sender is TextBox textBox)
            {
                var text = textBox.Text.Replace(":", "");
                if (text.Length >= 2 && text.Length < 4)
                {
                    textBox.Text = text.Insert(2, ":");
                    textBox.Select(textBox.Text.Length, 0);
                }
            }
        }

        private void Day_Changed(object sender, SelectionChangedEventArgs e)
        {
            DayMark.Visibility = Visibility.Hidden;
        }

        private void Group_Changed(object sender, SelectionChangedEventArgs e)
        {
            GroupMark.Visibility = Visibility.Hidden;
        }
    }
}
