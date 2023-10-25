using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
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

namespace IvanovaAvtoservice
{


    public partial class ServicePage : Page
    {
        int CountRecords;
        int CountPage;
        int CurrentPage = 0;
        public List<Servisee> CurrentPageList = new List<Servisee>();
        public List<Servisee> TableList;
        public ServicePage()
        {
            InitializeComponent();
            var currentServisee = Ivanova_carserviceEntities.GetContext().Servisee.ToList();
            ServiceListView.ItemsSource = currentServisee;
            ComboType.SelectedIndex = 0;
            UpdateServices();


        }
        private void UpdateServices()
        {
            var currentServisee = Ivanova_carserviceEntities.GetContext().Servisee.ToList();
            if (ComboType.SelectedIndex == 0)
            { currentServisee = currentServisee.Where(p => (p.Discount >= 0 && p.Discount <= 100)).ToList(); }
            if (ComboType.SelectedIndex == 1)
            { currentServisee = currentServisee.Where(p => (p.Discount >= 0 && p.Discount < 5)).ToList(); }
            if (ComboType.SelectedIndex == 2)
            {
                currentServisee = currentServisee.Where(p => (p.Discount >= 5 && p.Discount < 15)).ToList();

            }
            if (ComboType.SelectedIndex == 3)
            {
                currentServisee = currentServisee.Where(p => (p.Discount >= 15 && p.Discount < 30)).ToList();
            }
            if (ComboType.SelectedIndex == 4)
            {
                currentServisee = currentServisee.Where(p => (p.Discount >= 30 && p.Discount < 70)).ToList();
            }
            if (ComboType.SelectedIndex == 5)
            {
                currentServisee = currentServisee.Where(p => (p.Discount >= 70 && p.Discount < 100)).ToList();
            }
            
            if (RButtonDown.IsChecked.Value)
            {
                currentServisee = currentServisee.OrderByDescending(p => p.Cost).ToList();
            }
            if (RButtonUp.IsChecked.Value)
            {
                currentServisee = currentServisee.OrderBy(p => p.Cost).ToList();
            }
           
            ServiceListView.ItemsSource = currentServisee;
            TableList = currentServisee;
            ChangePage(0, 0);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage());
        }


        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateServices();
        }

        private void RButtonDown_Checked(object sender, RoutedEventArgs e)
        {
            UpdateServices();
        }

        private void RButtonUp_Checked(object sender, RoutedEventArgs e)
        {
            UpdateServices();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateServices();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var context = Ivanova_carserviceEntities.GetContext();
            foreach (var entry in context.ChangeTracker.Entries().Where(p => p.State != EntityState.Added).ToList())
            {
                entry.Reload();
            }
            ServiceListView.ItemsSource = context.Servisee.ToList();
        }
      
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var currentService = (sender as Button).DataContext as Servisee;
            var currentClientServices = Ivanova_carserviceEntities.GetContext().ClientService.ToList();
            currentClientServices = currentClientServices.Where(p => p.ServiceID == currentService.ID).ToList();
            if (currentClientServices.Count != 0)
            {
                MessageBox.Show("Невозможно выполнить удаление, так как существуют записи на эту услугу");
            }
            else
            {
                if (MessageBox.Show("ВЫ точно хотите выполнить удаление?", "Внимание!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        Ivanova_carserviceEntities.GetContext().Servisee.Remove(currentService);
                        Ivanova_carserviceEntities.GetContext().SaveChanges();

                        ServiceListView.ItemsSource = Ivanova_carserviceEntities.GetContext().Servisee.ToList();

                        UpdateServices();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Servisee));
        }



        private void ChangePage(int direction, int? selectedPage)
        {


            CurrentPageList.Clear();
            CountRecords = TableList.Count;
            if (CountRecords % 10 > 0) CountPage = CountRecords / 10 + 1;
            else CountPage = CountRecords / 10;

            Boolean Ifupdate = true;

            int min;
            if (selectedPage.HasValue)
            {
                if (selectedPage >= 0 && selectedPage <= CountPage)
                {
                    CurrentPage = (int)selectedPage;
                    min = CurrentPage * 10 + 10 < CountRecords ? CurrentPage * 10 + 10 : CountRecords;
                    for (int i = CurrentPage * 10; i < min; i++)
                    {
                        CurrentPageList.Add(TableList[i]);
                    }
                }
            }

            else
            {
                switch (direction)
                {
                    case 1:
                        if (CurrentPage > 0)
                        {
                            CurrentPage--;
                            min = CurrentPage * 10 + 10 < CountRecords ? CurrentPage * 10 + 10 : CountRecords;
                            for (int i = CurrentPage * 10; i < min; i++)
                            {
                                CurrentPageList.Add(TableList[i]);
                            }

                        }
                        else
                        {
                            Ifupdate = false;
                        }
                        break;
                    case 2:
                        if (CurrentPage > CurrentPage - 1)
                        {
                            CurrentPage++;
                            min = CurrentPage * 10 + 10 < CountRecords ? CurrentPage * 10 + 10 : CountRecords;
                            for (int i = CurrentPage * 10; i < min; i++)
                            {
                                CurrentPageList.Add(TableList[i]);
                                ;
                            }
                            
                        }
                        else
                        {
                            Ifupdate = false;
                        }

                        break;
                }
            }
            if (Ifupdate)
            {
                PageListBox.Items.Clear();

                for (int i = 1; i <= CountPage; i++)  PageListBox.Items.Add(i);
                PageListBox.SelectedIndex = CurrentPage;
                min = CurrentPage * 10 + 10 < CountRecords ? CurrentPage * 10 + 10 : CountRecords;
                TBCount.Text = min.ToString();
                TBALLRecords.Text = "из" + CountRecords.ToString();
                ServiceListView.ItemsSource = CurrentPageList;
                ServiceListView.Items.Refresh();
                    
            }


        }

        private void PageListBox_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ChangePage(0, Convert.ToInt32(PageListBox.SelectedItem.ToString()) - 1);
        }
        private void LeftDirButton_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(1, null);
        }
        private void RightDirButton_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(2, null);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new SingUpPage((sender as Button).DataContext as Servisee));
        }

        
    }
}
