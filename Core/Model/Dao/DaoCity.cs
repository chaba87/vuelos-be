using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Model.Dao
{
    public class DaoCity
    {
        public static List<City> GetAll()
        {
            try
            {
                using (var db = Configuration.Instance().ContextDB())
                {
                    return db.Cities.ToList();
                }
            }
            catch (Exception ex)
            {
                CatchError.Log4Net("ERROR", ex);
                return null;
            }

        }

        public static List<City> Search(string search)
        {
            try
            {
                using (var db = Configuration.Instance().ContextDB())
                {
                    return db.Cities.Where(x => x.Name.ToUpper().Contains(search.ToUpper())).ToList();
                }
            }
            catch (Exception ex)
            {
                CatchError.Log4Net("ERROR", ex);
                return null;
            }

        }

        public static City GetByCode(string IATACode)
        {
            try
            {
                using (var db = Configuration.Instance().ContextDB())
                {
                    return db.Cities.FirstOrDefault(x => x.IATACode.ToUpper() == IATACode.ToUpper());
                }
            }
            catch (Exception ex)
            {
                CatchError.Log4Net("ERROR", ex);
                return null;
            }

        }

        public static City GetById(int id)
        {
            try
            {
                using (var db = Configuration.Instance().ContextDB())
                {
                    return db.Cities.FirstOrDefault(x => x.Id == id);
                }
            }
            catch (Exception ex)
            {
                CatchError.Log4Net("ERROR", ex);
                return null;
            }

        }

    }

}
