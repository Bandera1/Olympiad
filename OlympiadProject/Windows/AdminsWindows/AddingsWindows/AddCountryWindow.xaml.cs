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
    /// Interaction logic for AddCountryWindow.xaml
    /// </summary>
    public partial class AddCountryWindow : Window
    {
        public string Name { get; set; }

        public AddCountryWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Country newType = new Country();
            newType.Name = Name;

            GetPropForSelectedService GettingService = new GetPropForSelectedService();
            foreach (var type in GettingService.GetCountry())
            {
                if (type.Name == Name)
                {
                    MessageBox.Show($"{Name} alredy exists.");
                    return;
                }
            }

            AddingService service = new AddingService();
            service.AddCountry(newType);

            MessageBox.Show("New olymp type added.");
        }
    }
}
