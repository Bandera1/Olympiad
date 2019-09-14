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

namespace OlympiadProject.Windows.AdminsWindows
{
    /// <summary>
    /// Interaction logic for AddOlympTypeWindow.xaml
    /// </summary>
    public partial class AddOlympTypeWindow : Window
    {
        public string Name_ { get; set; }

        public AddOlympTypeWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            OlympType newType = new OlympType();
            newType.Name = Name_;

            GetPropForSelectedService GettingService = new GetPropForSelectedService();
            foreach (var type in GettingService.GetOlympTypes())
            {
                if(type.Name == Name_)
                {
                    MessageBox.Show($"{Name_} type alredy exists.");
                    return;
                }
            }

            AddingService service = new AddingService();
            service.AddOlympType(newType);

            MessageBox.Show("New olymp type added.");        
        }
    }
}
