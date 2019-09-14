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
    /// Interaction logic for AddSportTypeWindow.xaml
    /// </summary>
    public partial class AddSportTypeWindow : Window
    {
        public string Name { get; set; }

        public AddSportTypeWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SportType newType = new SportType();
            newType.Name = Name;

            GetPropForSelectedService GettingService = new GetPropForSelectedService();
            foreach (var type in GettingService.GetSportTypes())
            {
                if (type.Name == Name)
                {
                    MessageBox.Show($"{Name} type alredy exists.");
                    return;
                }
            }

            AddingService service = new AddingService();
            service.AddSportType(newType);

            MessageBox.Show("New sport type added.");
        }
    }
}
