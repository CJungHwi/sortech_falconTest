namespace Sortech.DBConn
{
    public class DBConnection
    {
        public static IConfigurationRoot? Configuration { get; set; }

        public string? ConnectionString;

        public DBConnection(string dbname)
        {
            ConnectionString = GetDBConString(dbname);
        }

        public string GetDBConString(string dbname)
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            return Configuration.GetConnectionString(dbname);
        }
    }
}
