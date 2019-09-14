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
    /// Interaction logic for AddCityWindow.xaml
    /// </summary>
    public partial class AddCityWindow : Window
    {
        public string Name_ { get; set; }

        public AddCityWindow()
        {
            InitializeComponent();

            GetPropForSelectedService getService = new GetPropForSelectedService();

            if(getService.GetCountry(true).Count <= 0)
            {
                MessageBox.Show("Add country first.");
                this.Close();
                return;
            }

            CountryComboBox.ItemsSource = getService.GetCountry(false);

            this.DataContext = this;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            City newType = new City();
            newType.Name = Name_;
            newType.Country = (CountryComboBox.SelectedItem as Country);

            GetPropForSelectedService GettingService = new GetPropForSelectedService();
            foreach (var type in GettingService.GetCities())
            {
                if (type.Name == Name_)
                {
                    MessageBox.Show($"{Name_} type alredy exists.");
                    return;
                }
            }

            AddingService service = new AddingService();
            service.AddCity(newType);

            MessageBox.Show("New city added.");
        }       
    }
}
