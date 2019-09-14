using OlympiadDatabase.Classes;
using OlympiadDatabase.Service;
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
using System.Windows.Shapes;

namespace OlympiadProject.Windows.AdminsWindows.AddingsWindows
{
    /// <summary>
    /// Interaction logic for AddOlympiadService.xaml
    /// </summary>
    public partial class AddOlympiadWindow : Window
    {
        private List<Country> Countries;
        private List<OlympType> OlympTypes;

        public AddOlympiadWindow()
        {
            InitializeComponent();

            GetPropForSelectedService service = new GetPropForSelectedService();
            Countries = service.GetCountry(false);
            OlympTypes = service.GetOlympTypes(false);

            if (Countries.Count <= 0)
            {
                this.Hide();
                MessageBox.Show("Add countries first.");
                this.Close();
                return;
            }
            if (OlympTypes.Count <= 0)
            {
                this.Hide();
                MessageBox.Show("Add olymp types first.");
                this.Close();
                return;
            }

            OlympTypeComboBox.ItemsSource = OlympTypes;
            CountryComboBox.ItemsSource = Countries;

            this.DataContext = this;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(DatePicker.DisplayDate == null)
            {
                MessageBox.Show("Date can`t be null.");
                return;
            }

            Olympiad newType = new Olympiad();

            GetPropForSelectedService getService = new GetPropForSelectedService();
            newType.Date = DatePicker.SelectedDate.Value;
            newType.Type = getService.GetOlympTypes().FirstOrDefault(x => x.Name == (OlympTypeComboBox.SelectedItem as OlympType).Name);
            newType.Country = getService.GetCountry().FirstOrDefault(x => x.Name == (CountryComboBox.SelectedValue as Country).Name);


            foreach (var o in getService.GetOlympiads())
            {
                if(o.Date == newType.Date)
                {
                    MessageBox.Show($"Olympiads in {o.Date.ToString("0:d")} alredy exists.");
                }
            }

            AddingService addService = new AddingService();
            addService.AddOlympiad(newType);
            MessageBox.Show("Olympiad adding");
        }
    }
}
