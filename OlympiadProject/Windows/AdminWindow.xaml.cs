using MahApps.Metro;
using MahApps.Metro.Controls;
using OlympiadDatabase.Classes;
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
        public AdminWindow()
        {
            InitializeComponent();
            ThemeManager.ChangeAppStyle(Application.Current,
                                   ThemeManager.GetAccent("Blue"),
                                   ThemeManager.GetAppTheme("BaseLight"));


            TestDataGrid.ItemsSource = lists;
        }

        private void Flyout_Open(object sender, RoutedEventArgs e)
        {
            OtherFeaturesFlyout.IsOpen = true;
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
}
