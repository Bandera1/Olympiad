namespace OlympiadProject
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class OlympiadContext : DbContext
    {       
        public OlympiadContext() : base("name=OlympiadContext")
        {
        }
        
    }
}