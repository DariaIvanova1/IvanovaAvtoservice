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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Servisee _currentServise = new Servisee();
        public AddEditPage()
        {
            InitializeComponent();
            DataContext = _currentServise;
         
        }
        public AddEditPage(Servisee SelectedService)
        {
            InitializeComponent();
            
            if (SelectedService != null)
                _currentServise = SelectedService;
            DataContext = _currentServise;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentServise.Title))
                errors.AppendLine("Укажите название услуги");
            if (_currentServise.Cost==0)
                errors.AppendLine("Укажите стоимость услуги");
            if ( _currentServise.Discount== null)
                errors.AppendLine("Укажите скидку");
            if (_currentServise.Duration > 240)
                errors.AppendLine("Длительность не может быть больше 240 минут");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            var allServices = Ivanova_carserviceEntities.GetContext().Servisee.ToList();
            // Исключаем текущую услугу из списка всех услуг
            allServices = allServices.Where(p => p.ID != _currentServise.ID && p.Title == _currentServise.Title).ToList();
            if (allServices.Count == 0)
            {
                if (_currentServise.ID == 0)
                {
                    Ivanova_carserviceEntities.GetContext().Servisee.Add(_currentServise);

                }
                try
                {
                    Ivanova_carserviceEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                    Manager.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Уже существует такая услуга");
            }
            
        }
    }
}
