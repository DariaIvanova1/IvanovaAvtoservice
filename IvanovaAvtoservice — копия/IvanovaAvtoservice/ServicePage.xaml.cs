using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        public ServicePage()
        {
            InitializeComponent();
            var currentServisee = Ivanova_carserviceEntities1.GetContext().Servisee.ToList();
            ServiceListView.ItemsSource = currentServisee;
            ComboType.SelectedIndex = 0;
            UpdateServices();
           

        }
    private void UpdateServices()
    {
        var currentServisee = Ivanova_carserviceEntities1.GetContext().Servisee.ToList();
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
        currentServisee = currentServisee.Where(p => p.Title.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
        if (RButtonDown.IsChecked.Value)
        {
            currentServisee = currentServisee.OrderByDescending(p => p.Cost).ToList();
        }
        if (RButtonUp.IsChecked.Value)
        {
            currentServisee = currentServisee.OrderBy(p => p.Cost).ToList();
        }
            ServiceListView.ItemsSource = currentServisee;
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
            if(Visibility == Visibility.Visible) {
                Ivanova_carserviceEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ServiceListView.ItemsSource = Ivanova_carserviceEntities1.GetContext().Servisee.ToList();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Servisee));
        }
    }
}
