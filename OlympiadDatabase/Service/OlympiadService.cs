using OlympiadDatabase.Classes;
using OlympiadProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympiadDatabase.Service
{
    public class OlympiadService
    {
        OlympiadContext db = new OlympiadContext();

        public List<Olympiad> GetOlympiad()
        {
            return db.Olympiads.AsNoTracking().ToList();
        }

        public List<OlympResult> GetMedalStandings()
        {
            return db.OlympResults.AsNoTracking().ToList();
        }
        public List<SportType> GetSportTypesByOlympiad(string OlympiadName)
        {
            return db.SportTypes.AsNoTracking().ToList();
        }
        public List<OlympResult> GetMedalistBySport(string SportName)
        {
            return db.OlympResults.AsNoTracking().Where(x => x.SportType.Name == SportName).ToList();
        }

        public List<OlympResult> GetTeamStatsByCountry(string Country)
        {
            return db.OlympResults.AsNoTracking().Where(x => x.Person.Country.Name == Country).ToList();
        }

        public string GetMostHostOfOlymp()
        {
            return db.OlympResults.AsNoTracking().GroupBy(c => c.Olympiad.Country.Name).Max().ToString();
        }
    }
}
