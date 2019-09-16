using MahApps.Metro;
using MahApps.Metro.Controls;
using OlympiadDatabase.Classes;
using OlympiadDatabase.Service;
using OlympiadProject.Windows;
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

namespace OlympiadProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private bool Theme = true;
       
        public List<SportMedal> medals = new List<SportMedal>();
        public List<TeamStat> stats = new List<TeamStat>();

        private Olympiad CurrentOlympaid = null;

        public MainWindow()
        {
            InitializeComponent();
            InitStartUpUI();
            MainStackPanel.Visibility = Visibility.Hidden;

            medals.Add(new SportMedal() { Number = 1, Country = "France", AllName = "Zan Shirak" });
            StatStore_SportsMedalistListBox.ItemsSource = medals;



            stats.Add(new TeamStat() { Number = 1, Sport = "Sport", AllName = "Vlad Negodiyk", Place = 11 });
            StatStore_TeamStatsListBox.ItemsSource = stats;           
        }

        

        

        private void ChangeThemeButton_Click(object sender, RoutedEventArgs e)
        {
            if (Theme)
            {
                Theme = false;
                ThemeManager.ChangeAppStyle(Application.Current,
                                    ThemeManager.GetAccent("Blue"),
                                    ThemeManager.GetAppTheme("BaseDark"));
                (sender as Button).Background = Brushes.LightGray;
            }
            else
            {
                Theme = true;
                ThemeManager.ChangeAppStyle(Application.Current,
                                   ThemeManager.GetAccent("Blue"),
                                   ThemeManager.GetAppTheme("BaseLight"));
                (sender as Button).Background = Brushes.DarkGray;
            }
           
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OtherInfoFlyout.IsOpen = true;
        }
        private void LockButton_Click(object sender, RoutedEventArgs e)
        {
            SecretWindow window = new SecretWindow();

            this.Hide();
            window.ShowDialog();
            this.Show();
        }



        private void InitStartUpUI()
        {
            InitOlympList();
            InitLockButton();
        }
        private void InitContentUI()
        {          
            InitTopBlock();          
            InitMedalStandings();
            InitSportsMedalists();
            InitTeamStats();
            InitHostestOfOlymps();
            InitAthleteRecord();
            InitCompositionOfOlympTeam();
        }

        private void InitOlympList()
        {
            GetPropForSelectedService service = new GetPropForSelectedService();

            foreach (var o in service.GetOlympiads().OrderByDescending(x => x.Date))
            {
                TreeViewItem Item = new TreeViewItem();

                Item.Header = $"{o.Type.Name} olympiad in {o.Country.Name} {String.Format("{0:y}", o.Date)}";

                OlympiadTreeView.Items.Add(Item);
            }
        }
        private void InitLockButton()
        {
            var image = new Image();
            var fullFilePath = @"http://pluspng.com/img-png/png-lock-picture-lock-9-icons-512.png";

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();

            image.Source = bitmap;
            LockButton.Content = image;
        }

        private void InitTopBlock()
        {
            StatStore_OlympName.Text = $"{CurrentOlympaid.Type.Name} olympiad";
            StatStore_OlympCountry.Text = $"{CurrentOlympaid.Country.Name}";
            StatStore_OlympYear.Text = $"{String.Format("{0:y}", CurrentOlympaid.Date)}";
        }    
        private void InitMedalStandings()
        {
            List<MedalStandings> MedalsStanding = new List<MedalStandings>();
            GetPropForSelectedService service = new GetPropForSelectedService();

            List<string> bufCountries = service.GetOlympsResult().Where(x => x.Olympiad.Date == CurrentOlympaid.Date).GroupBy(x => x.Person.Country.Name).Select(g => g.Key).ToList();
            var OlympRes = service.GetOlympsResult().Where(x => x.Olympiad.Date == CurrentOlympaid.Date);

            for (int i = 0; i < bufCountries.Count; i++)
            {
                MedalStandings bufMedal = new MedalStandings();
            
                bufMedal.Country = bufCountries[i];
                bufMedal.Golds = OlympRes.Where(x => x.Person.Country.Name == bufMedal.Country && x.Place == 1).Count();
                bufMedal.Sereb = OlympRes.Where(x => x.Person.Country.Name == bufMedal.Country && x.Place == 2).Count(); ;    
                bufMedal.Bronz = OlympRes.Where(x => x.Person.Country.Name == bufMedal.Country && x.Place == 3).Count();
                bufMedal.All = bufMedal.Golds + bufMedal.Sereb + bufMedal.Bronz;

                MedalsStanding.Add(bufMedal);
            }
            MedalsStanding.OrderBy(x => x.All);
            MedalStandingsListBox.ItemsSource = MedalsStanding.OrderByDescending(x => x.All);

            for (int i = 0; i < MedalStandingsListBox.Items.Count; i++)
            {
                (MedalStandingsListBox.Items[i] as MedalStandings).Number = i+1;
            }
        }
        private void InitSportsMedalists()
        {            
            GetPropForSelectedService service = new GetPropForSelectedService();

            var sports = service.GetOlympsResult().Where(x => x.Olympiad.Date == CurrentOlympaid.Date).GroupBy(x => x.SportType).Select(g => g.Key).ToList();
            List<string> Sports = new List<string>();

            for (int i = 0; i < sports.Count; i++)
            {
                Sports.Add(sports[i].Name);
            }          

            try
            {
                StatStore_SportsMedalistComboBox.ItemsSource = Sports;
                StatStore_SportsMedalistComboBox.SelectedItem = StatStore_SportsMedalistComboBox.Items[0];
            }
            catch (Exception)
            {
            }
        }
        private void InitTeamStats()
        {
            GetPropForSelectedService service = new GetPropForSelectedService();
            List<string> bufCountries = service.GetOlympsResult().Where(x => x.Olympiad.Date == CurrentOlympaid.Date).GroupBy(x => x.Person.Country.Name).Select(g => g.Key).ToList();

            try
            {
                StatStore_TeamStatsCountryComboBox.ItemsSource = bufCountries;
                StatStore_TeamStatsCountryComboBox.SelectedItem = StatStore_TeamStatsCountryComboBox.Items[0];
            }
            catch (Exception)
            {
            }
        }
        private void InitHostestOfOlymps()
        {
            GetPropForSelectedService service = new GetPropForSelectedService();
            //var count = service.GetOlympsResult().GroupBy(x => x.Person.Country).Select(group => new
            //{
            //    Name = group.Key,
            //    Count = group.Count()
            //}).OrderByDescending(x => x.Count).Select(x => x.Count).ToList();

            var count = service.GetOlympsResult().GroupBy(x => x.Person.Country).Select(group => new
            {
                Count = group.Count()
            }).Select(x => x.Count);

            MessageBox.Show(count.First().ToString());

        }
        private void InitAthleteRecord()
        {

        }
        private void InitCompositionOfOlympTeam()
        {

        }

        private void OlympiadTreeView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            GetPropForSelectedService service = new GetPropForSelectedService();

            DateTime currOlympDate = new DateTime();

            foreach (var o in service.GetOlympiads())
            {
                string bufName;
                string gettingOlympName;
                
                bufName = ((sender as TreeView).SelectedItem as TreeViewItem).Header.ToString();
                gettingOlympName = $"{o.Type.Name} olympiad in {o.Country.Name} {String.Format("{0:y}", o.Date)}";

                if (bufName == gettingOlympName)
                    currOlympDate = o.Date;
            }
            MainStackPanel.Visibility = Visibility.Visible;

            CurrentOlympaid = service.GetOlympiads().FirstOrDefault(x => x.Date == currOlympDate);
            InitContentUI();
        }
    }


    public class MedalStandings
    {
        public int Number { get; set; }
        public string Country { get; set; }
        public int Golds { get; set; }
        public int Sereb { get; set; }
        public int Bronz { get; set; }
        public int All { get; set; }
    }
    public class SportMedal
    {
        public int Number { get; set; }
        public string Country { get; set; }
        public string AllName { get; set; }
    }
    public class TeamStat
    {
        public int Number { get; set; }
        public string Sport { get; set; }
        public string AllName { get; set; }
        public int Place { get; set; }
    }
}
