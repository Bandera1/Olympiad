using MahApps.Metro;
using MahApps.Metro.Controls;
using OlympiadDatabase.Classes;
using OlympiadDatabase.Service;
using OlympiadProject.Windows.AdminsWindows;
using OlympiadProject.Windows.AdminsWindows.AddingsWindows;
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

namespace OlympiadProject.Windows
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : MetroWindow
    {      
        TablesCounts TablesCounts;



        public AdminWindow()
        {
            InitializeComponent();
            ThemeManager.ChangeAppStyle(Application.Current,
                                   ThemeManager.GetAccent("Blue"),
                                   ThemeManager.GetAppTheme("BaseLight"));

            

            InitUI();
        }

        private void Flyout_Open(object sender, RoutedEventArgs e)
        {
            OtherFeaturesFlyout.IsOpen = true;
        }

        private void InitUI()
        {
            TopTablesCountInit();
            OlympResultInit();
        }

        private void TopTablesCountInit()
        {
            TablesCounts = new TablesCounts();

            try
            {
                GetCountsService<OlympType> getOlympTypeCount = new GetCountsService<OlympType>();
                TablesCounts.OlympTypesCount = getOlympTypeCount.GetCount();

                GetCountsService<Country> getCountryCount = new GetCountsService<Country>();
                TablesCounts.CountriesCount = getCountryCount.GetCount();

                GetCountsService<City> getCitiesCount = new GetCountsService<City>();
                TablesCounts.CitiesCount = getCitiesCount.GetCount();

                GetCountsService<SportType> getSportTypeCount = new GetCountsService<SportType>();
                TablesCounts.SportTypeCount = getSportTypeCount.GetCount();

                GetCountsService<Person> getPersonCount = new GetCountsService<Person>();
                TablesCounts.PersonCount = getPersonCount.GetCount();

                GetCountsService<Olympiad> getOlympiadCount = new GetCountsService<Olympiad>();
                TablesCounts.OlympiadCount = getOlympiadCount.GetCount();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            TopCountsStackPanel.DataContext = TablesCounts;
        }
        private void OlympResultInit()
        {
            GetPropForSelectedService service = new GetPropForSelectedService();
            var Results = service.GetOlympsResult();

            List<OlympResultNodeTemplate> ResultsData = new List<OlympResultNodeTemplate>();

            foreach (var r in Results)
            {
                OlympResultNodeTemplate node = new OlympResultNodeTemplate();

                node.OlympiadName = $"{r.Olympiad.Type.Name} olympiad in {r.Olympiad.Country.Name} {String.Format("{0:y}", r.Olympiad.Date)}";
                node.PersonName = $"{r.Person.FirstName} {r.Person.SecondName} {r.Person.ThirdName}";
                node.SportTypeName = r.SportType.Name;
                node.Place = r.Place;

                ResultsData.Add(node);
            }

            OlympResultDataGrid.ItemsSource = ResultsData;

        }


        private void AddOlympTypeClick(object sender, RoutedEventArgs e)
        {
            try
            {
                AddOlympTypeWindow window = new AddOlympTypeWindow();
                window.ShowDialog();
            }
            catch (Exception)
            {                
            }            
            InitUI();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddCountryWindow window = new AddCountryWindow();
                window.ShowDialog();
            }
            catch (Exception)
            {                
            }          
            InitUI();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                AddCityWindow window = new AddCityWindow();
                window.ShowDialog();
            }
            catch (Exception)
            {
            }         
            InitUI();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddSportTypeWindow window = new AddSportTypeWindow();
            window.ShowDialog();
            InitUI();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                AddPersonWindow window = new AddPersonWindow();
                window.ShowDialog();              
            }
            catch (Exception)
            {
            }
            InitUI();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                AddOlympiadWindow window = new AddOlympiadWindow();
                window.ShowDialog();
            }
            catch (Exception)
            {
            }
            InitUI();   
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                AddOlympResultNode window = new AddOlympResultNode();
                window.ShowDialog();
            }
            catch (Exception)
            {
            }          
            InitUI();
        }
    }

    public class OlympResultNodeTemplate
    {
        public string OlympiadName { get; set; }
        public string SportTypeName { get; set; }        
        public string PersonName { get; set; }
        public int Place { get; set; }
    }
    public class TablesCounts
    {
        public int OlympTypesCount { get; set; }
        public int CountriesCount { get; set; }
        public int CitiesCount { get; set; }
        public int SportTypeCount { get; set; }
        public int PersonCount { get; set; }
        public int OlympiadCount { get; set; }
    }

}
