using OlympiadDatabase.Classes;
using OlympiadProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympiadDatabase.Service
{
    public class GetPropForSelectedService
    {
        OlympiadContext db = new OlympiadContext();

        public List<SportType> GetSportsTypes(bool AsNoTracking = false)
        {
            return AsNoTracking ? db.SportTypes.AsNoTracking().ToList() : db.SportTypes.ToList();
        }

        public List<Country> GetCountry(bool AsNoTracking = false)
        {
            return AsNoTracking ? db.Countries.AsNoTracking().ToList() : db.Countries.ToList();
        }

        public List<City> GetCities(bool AsNoTracking = false)
        {
            return AsNoTracking ? db.Cities.AsNoTracking().ToList() : db.Cities.ToList();
        }

        public List<SportType> GetSportTypes(bool AsNoTracking = false)
        {
            return AsNoTracking ? db.SportTypes.AsNoTracking().ToList() : db.SportTypes.ToList(); 
        }

        public List<Person> GetPersons(bool AsNoTracking = false)
        {
            return AsNoTracking ? db.Persons.AsNoTracking().ToList() : db.Persons.ToList();
        }

        public List<Olympiad> GetOlympiads(bool AsNoTracking = false)
        {
            return AsNoTracking ? db.Olympiads.AsNoTracking().ToList() : db.Olympiads.ToList();
        }

        public List<OlympResult> GetOlympsResult(bool AsNoTracking = false)
        {
            return AsNoTracking ? db.OlympResults.AsNoTracking().ToList() : db.OlympResults.ToList();
        }
    }
}
