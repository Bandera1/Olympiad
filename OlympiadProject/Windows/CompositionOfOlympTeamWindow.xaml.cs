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
    /// Interaction logic for CompositionOfOlympTeamWindow.xaml
    /// </summary>
    public partial class CompositionOfOlympTeamWindow : MetroWindow
    {
        public CompositionOfOlympTeamWindow(string CountryName,List<Person> Persons,List<SportType> SportTypes)
        {
            InitializeComponent();
            this.Title = CountryName + " composition.";
            
            ToTemplateParse(Persons, SportTypes);
        }

        private void ToTemplateParse(List<Person> Persons, List<SportType> SportTypes)
        {
            List<CompositionOfTeamTemplate> Source = new List<CompositionOfTeamTemplate>();

            for (int i = 0; i < Persons.Count; i++)
            {
                CompositionOfTeamTemplate buf = new CompositionOfTeamTemplate();

                buf.Number = i + 1;
                buf.SportType = SportTypes[i].Name;
                buf.AllName = $"{Persons[i].FirstName} {Persons[i].SecondName} {Persons[i].ThirdName}";

                Source.Add(buf);
            }

            MainListBox.ItemsSource = Source;
        }
    }

    public class CompositionOfTeamTemplate
    {
        public int Number { get; set; }
        public string SportType { get; set; }
        public string AllName { get; set; }
    }

}
