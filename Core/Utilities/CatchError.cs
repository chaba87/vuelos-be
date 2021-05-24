using System;
using log4net;
using Core.Utilities;

public class CatchError
{
    public static void Log4Net(string tipoLog, Exception ex)
    {
        string dia = DateTime.Now.ToString("yyyy-MM-dd");
        GlobalContext.Properties["LogName"] = dia;

        var path = @"C:\Log\Vuelo\";
        GlobalContext.Properties["LogPath"] = path;

        log4net.Config.XmlConfigurator.Configure();

        LogManager.GetLogger("ROOT").Info("Method: " + NombreMetodoError(ex.StackTrace) + "\r\n     Message: " + ex.Message);

        switch (tipoLog)
        {
            case "WARN":
                LogManager.GetLogger("WARN").Warn("Method: " + NombreMetodoError(ex.StackTrace) + "\r\n     Message: " + ex.Message);
                break;
            case "ERROR":
                LogManager.GetLogger("ERROR").Error("Method: " + NombreMetodoError(ex.StackTrace) + "\r\n     Message: " + ex.Message);
                break;
            case "FATAL":
                LogManager.GetLogger("FATAL").Fatal("Method: " + NombreMetodoError(ex.StackTrace) + "\r\n     Message: " + ex.Message);
                break;
        }
    }

    protected static string NombreMetodoError(string stackTrace)
    {
        try
        {
            var pos = stackTrace.LastIndexOf("\r\n") + 4;

            return stackTrace.Substring(pos, stackTrace.Length - pos);
        }
        catch { return "stackTrace: null"; }
    }

    public class Error
    {
        public DateTime Fecha { get; set; }
        public string Mensaje { get; set; }
        public string Exception { get; set; }

    }

    public class DaoError
    {
        public static void Insert(Error error)
        {
            try
            {
                using (var db = Configuration.Instance().ContextDB())
                {
                    //db.Errores.Add(error);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Log4Net("ERROR", ex);
            }

        }

    }

}
