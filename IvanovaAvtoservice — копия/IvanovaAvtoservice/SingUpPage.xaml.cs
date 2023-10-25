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
   
    public partial class SingUpPage : Page
    { 
        public SingUpPage()
        {
            InitializeComponent();
        }
        private ClientService _currentClientService = new ClientService();
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (ComboClient.SelectedItem == null)
                errors.AppendLine("Укажите фио клиента");
            if (StartDate.Text=="")
                errors.AppendLine("Укажите дату услуги");
            if (TBStart.Text == "")
                errors.AppendLine("Укажите время начала услуги");
          

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            _currentClientService.ClientID = ComboClient.SelectedIndex + 1;
            _currentClientService.ServiceID = _currentServicee.ID;
            _currentClientService.StartTime = Convert.ToDateTime(StartDate.Text + " " + TBStart.Text);
            if(_currentClientService.ID == 0)
            {
                Ivanova_carserviceEntities.GetContext().ClientService.Add(_currentClientService);
            }
            try
            {
                Ivanova_carserviceEntities.GetContext().SaveChanges();
                MessageBox.Show("информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private Servisee _currentServicee = new Servisee();
        public  SingUpPage(Servisee SelecedService)
        {
            InitializeComponent();
            if (SelecedService != null)
                this._currentServicee = SelecedService;
            DataContext = _currentServicee;
            var _currentClient = Ivanova_carserviceEntities.GetContext().client.ToList();
            ComboClient.ItemsSource = _currentClient;
        }

        private void TBStart_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s = TBStart.Text;
            string filteredText = new string(s.Where(c => char.IsDigit(c) || c == ':').ToArray());
            if (s!= filteredText)
            {
                TBEnd.Text = "";
                TBStart.Text = TBStart.Text.Substring(TBStart.Text.Length);
                return;
            }
            if (s.Length < 5|| !s.Contains(':'))
            {
                TBEnd.Text = "";
                
                return;
                
            }
                
            else
            {
                string[] start = s.Split( ':');
                int startHour = Convert.ToInt32(start[0]) * 60;
                int startMin = Convert.ToInt32(start[1]);
                int sum = startHour + startMin + _currentServicee.Duration;
                int EndHour = sum / 60;
                int EndMin = sum % 60;
                if (EndHour>=24)
                {
                    EndHour -= 24;
                }
                s = EndHour.ToString() + " :" + EndMin.ToString("D2");
                TBEnd.Text = s;

            }
              
        }
    }
}
