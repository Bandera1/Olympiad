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
    /// Interaction logic for AddOlympResultNode.xaml
    /// </summary>
    public partial class AddOlympResultNode : Window
    {
        private List<TemplateOlympiadName> Olympiads;
        private List<SportType> SportTypes;
        private List<City> Cities;
        private List<Person> Persons;

        public AddOlympResultNode()
        {
            InitializeComponent();

            GetPropForSelectedService getService = new GetPropForSelectedService();

            Olympiads = RemakeOlymp(getService.GetOlympiads());
            SportTypes = getService.GetSportTypes();
            Cities = getService.GetCities();
            Persons = getService.GetPersons();

            DataCheck();

            this.DataContext = this;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            OlympResult newType = new OlympResult();

            GetPropForSelectedService getService = new GetPropForSelectedService();
            foreach (var or in getService.GetOlympsResult())
            {
                if(or.Olympiad.Date == newType.Olympiad.Date)
                    if(or.SportType.Name == newType.SportType.Name)
                        if(or.City.Name == newType.City.Name)
                            if(or.Person.FirstName == newType.Person.FirstName)
                                if (or.Person.SecondName == newType.Person.SecondName)
                                    if (or.Person.ThirdName == newType.Person.ThirdName)
                                        if(or.Place == newType.Place)
                                        {
                                            MessageBox.Show("This node alredy exist.");
                                            return;
                                        }
            }

            AddingService addService = new AddingService();
            addService.AddOlympiadResultNode(newType);
            MessageBox.Show("New result node adding.");
        }

        private void DataCheck()
        {
            if(Olympiads.Count <= 0)
            {
                this.Hide();
                MessageBox.Show("Add olympiads first.");
                this.Close();
                return;
            }
            if(SportTypes.Count <= 0)
            {
                this.Hide();
                MessageBox.Show("Add sport types first.");
                this.Close();
                return;
            }
            if(Cities.Count <= 0)
            {
                this.Hide();
                MessageBox.Show("Add cities first.");
                this.Close();
                return;
            }
            if(Persons.Count <= 0)
            {
                this.Hide();
                MessageBox.Show("Add persons first.");
                this.Close();
                return;
            }
        }

        private List<TemplateOlympiadName> RemakeOlymp(List<Olympiad> Olymps)
        {
            List<TemplateOlympiadName> returnList = new List<TemplateOlympiadName>();

            foreach (var o in Olymps)
            {
                returnList.Add(new TemplateOlympiadName() { Name = $"{o.Type.Name} in {o.Country.Name} {o.Date.ToString("0:y")}" });
            }

            return returnList;
        }
    }

    class TemplateOlympiadName
    {
        public string Name { get; set; }
    }
}
