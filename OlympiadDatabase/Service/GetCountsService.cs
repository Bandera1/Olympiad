using OlympiadDatabase.Classes;
using OlympiadProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympiadDatabase.Service
{
    public class GetCountsService<TEntity> where TEntity : EntityBase
    {
        OlympiadContext db = new OlympiadContext();

        public int GetCount()
        {
            return db.Set<TEntity>().AsNoTracking().Count();
        }
    }
}
