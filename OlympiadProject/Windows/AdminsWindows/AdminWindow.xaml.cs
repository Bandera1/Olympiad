using MahApps.Metro;
using MahApps.Metro.Controls;
using OlympiadDatabase.Classes;
using OlympiadDatabase.Service;
using OlympiadProject.Windows.AdminsWindows;
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
        List<TestClass> lists = new List<TestClass>();
        TablesCounts TablesCounts;



        public AdminWindow()
        {
            InitializeComponent();
            ThemeManager.ChangeAppStyle(Application.Current,
                                   ThemeManager.GetAccent("Blue"),
                                   ThemeManager.GetAppTheme("BaseLight"));


            TestDataGrid.ItemsSource = lists;

            InitUI();
        }

        private void Flyout_Open(object sender, RoutedEventArgs e)
        {
            OtherFeaturesFlyout.IsOpen = true;
        }

        private void InitUI()
        {
            TopTablesCountInit();
        }

        private void TopTablesCountInit()
        {
            TablesCounts = new TablesCounts();

            try
            {
                //GetCountsService<OlympType> getOlympTypeCount = new GetCountsService<OlympType>();
                //TablesCounts.OlympTypesCount = getOlympTypeCount.GetCount();
                //if (TablesCounts.OlympiadCount == null) TablesCounts.OlympiadCount = 0;

                //GetCountsService<Country> getCountryCount = new GetCountsService<Country>();
                //TablesCounts.CountriesCount = getCountryCount.GetCount();
                //if (TablesCounts.CountriesCount == null) TablesCounts.CountriesCount = 0;

                //GetCountsService<City> getCitiesCount = new GetCountsService<City>();
                //TablesCounts.CitiesCount = getCitiesCount.GetCount();
                //if (TablesCounts.CitiesCount == null) TablesCounts.CitiesCount = 0;

                //GetCountsService<SportType> getSportTypeCount = new GetCountsService<SportType>();
                //TablesCounts.SportTypeCount = getSportTypeCount.GetCount();
                //if (TablesCounts.SportTypeCount == null) TablesCounts.SportTypeCount = 0;

                //GetCountsService<Person> getPersonCount = new GetCountsService<Person>();
                //TablesCounts.PersonCount = getPersonCount.GetCount();
                //if (TablesCounts.PersonCount == null) TablesCounts.PersonCount = 0;

                //GetCountsService<Person> getOlympiadCount = new GetCountsService<Person>();
                //TablesCounts.OlympiadCount = getOlympiadCount.GetCount();
                //if (TablesCounts.OlympiadCount == null) TablesCounts.OlympiadCount = 0;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }          

            TopCountsStackPanel.DataContext = TablesCounts;
        }

        private void AddOlympTypeClick(object sender, RoutedEventArgs e)
        {
            AddOlympTypeWindow window = new AddOlympTypeWindow();

            window.ShowDialog();              
        }
    }

    public class TestClass
    {     
        public int OlympiadName { get; set; }      
        public int SportTypeName { get; set; }       
        public int CityName { get; set; }   
        public int PersonName { get; set; }       
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
