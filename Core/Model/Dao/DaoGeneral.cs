using System;
using System.Linq;

namespace Core.Model.Dao
{
    public class DaoGeneral
    {
        public static DateTime GetDateTimeNow()
        {
            try
            {
                using (var db = Utilities.Configuration.Instance().ContextDB())
                {
                    var dateQuery = db.Database.SqlQuery<DateTime>("SELECT GETDATE() ");
                    DateTime dateFromSql = dateQuery.AsEnumerable().First();
                    return dateFromSql;
                }
            }
            catch (Exception ex)
            {
                CatchError.Log4Net("ERROR", ex);
                return DateTime.MinValue;
            }
        }

    }

}
