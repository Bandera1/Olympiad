using OlympiadDatabase.Classes;
using OlympiadProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympiadDatabase.Service
{
    public class AddingService
    {
        OlympiadContext db = new OlympiadContext();

        public void AddOlympType(OlympType olympType)
        {
            db.OlympTypes.Add(olympType);
            db.SaveChanges();
        }

        public void AddCountry(Country country)
        {
            db.Countries.Add(country);
            db.SaveChanges();
        }

        public void AddCity(City city)
        {
            db.Cities.Add(city);
            db.SaveChanges();
        }

        public void AddSportType(SportType sportType)
        {
            db.SportTypes.Add(sportType);
            db.SaveChanges();
        }

        public void AddPerson(Person person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
        }

        public void AddOlympiad(Olympiad olympiad)
        {
            db.Olympiads.Add(olympiad);
            db.SaveChanges();
        }

        public void AddOlympiadResultNode(OlympResult olympResultNode)
        {
            db.OlympResults.Add(olympResultNode);
            db.SaveChanges();
        }
    }
}
