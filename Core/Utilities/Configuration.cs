
namespace Core.Utilities
{
    public class Configuration
    {
        private static Configuration instance;

        private Configuration()
        {
        }

        public static Configuration Instance()
        {
            if (instance == null)
            {
                instance = new Configuration();
            }

            return instance;
        }

        /// <summary>
        /// Contexto de Base de datos.
        /// </summary>
        /// <returns></returns>
        public VuelosContext ContextDB()
        {
            return new VuelosContext();
        }

        public static bool JsonReturn { get; set; }

    }
}
