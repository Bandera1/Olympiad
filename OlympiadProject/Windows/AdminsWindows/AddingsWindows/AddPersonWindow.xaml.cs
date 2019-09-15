using Microsoft.Win32;
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
    /// Interaction logic for AdPersonWindow.xaml
    /// </summary>
    public partial class AddPersonWindow : Window
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }

        private List<Country> Countries;
        private string PhotoPath;

        public AddPersonWindow()
        {
            InitializeComponent();


            GetPropForSelectedService service = new GetPropForSelectedService();
            Countries = service.GetCountry(true);

            if (Countries.Count <= 0)
            {
                this.Hide();
                MessageBox.Show("Add countries first.");
                this.Close();
                return;
            }

            CountryComboBox.ItemsSource = Countries;

            this.DataContext = this;
        }

        private void AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Image files|*.img;*.png;*jpg;*.jpeg";
            dialog.ShowDialog();

            PhotoPath = dialog.FileName;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(DatePicker.DisplayDate == null)
            {
                MessageBox.Show("Date can`t be null.");
                return;
            }
            if(PhotoPath == null)
            {
                MessageBox.Show("Photo can`t be null.");
                return;
            }


            Person newType = new Person();
            GetPropForSelectedService getService = new GetPropForSelectedService();

            newType.FirstName = FirstName;
            newType.SecondName = SecondName;
            newType.ThirdName = ThirdName;
            newType.CountryID = getService.GetCountry(false).FirstOrDefault(x => x.Name == (CountryComboBox.SelectedItem as Country).Name).ID;
            newType.DateOfBirth = DatePicker.SelectedDate.Value;
            newType.PhotoPath = PhotoPath;


            foreach (var p in getService.GetPersons())
            {
                if(p.FirstName == newType.FirstName)
                    if(p.SecondName == newType.SecondName)
                        if(p.ThirdName == newType.ThirdName)
                        {
                            MessageBox.Show($"{p.FirstName} {p.SecondName} {p.ThirdName} alredy exist`s.");
                            return;
                        }
            }


            AddingService addService = new AddingService();
            addService.AddPerson(newType);
            MessageBox.Show("New person added.");
        }
    }
}
