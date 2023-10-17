﻿using System;
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
                errors.AppendLine("Укажит стоимость услуги");
            if ( _currentServise.Discount== null)
                errors.AppendLine("Укажите скидку");
            if (string.IsNullOrWhiteSpace(_currentServise.DurationIn))
                errors.AppendLine("Укажие длительность услуги");
            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentServise.ID ==0)
            {
                Ivanova_carserviceEntities1.GetContext().Servisee.Add(_currentServise);

            }
            try
            {
                Ivanova_carserviceEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
