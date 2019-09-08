using MahApps.Metro;
using MahApps.Metro.Controls;
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

        public List<MedalStandings> test = new List<MedalStandings>();
        public List<SportMedal> medals = new List<SportMedal>();
        public List<TeamStat> stats = new List<TeamStat>();

        public MainWindow()
        {
            InitializeComponent();
            InitUI();

            test.Add(new MedalStandings() { Number = 1,Country = "Ukraine",Golds = 13,Sereb = 14,Bronz = 10,All = 37 });
            test.Add(new MedalStandings() { Number = 2,Country = "USA",Golds = 7,Sereb = 12,Bronz = 9,All = 28 });
           

            this.DataContext = test;
            MedalStandingsListBox.ItemsSource = test;



           
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

            window.ShowDialog();
        }



        private void InitUI()
        {
            InitLockButton();
            InitMedalStandings();
            InitSportsMedalists();
            InitTeamStats();
            InitHostestOfOlymps();
            InitAthleteRecord();
            InitCompositionOfOlympTeam();
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
        private void InitMedalStandings()
        {

        }
        private void InitSportsMedalists()
        {

        }
        private void InitTeamStats()
        {

        }
        private void InitHostestOfOlymps()
        {

        }
        private void InitAthleteRecord()
        {

        }
        private void InitCompositionOfOlympTeam()
        {

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
