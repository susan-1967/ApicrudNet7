
using Microsoft.Extensions.Configuration;
namespace APIcrud.Datos
{
    public class conDatos
    {
       
        public static string ConSQL() {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json") // Asegúrate de que el archivo appsettings.json exista
            .Build();

            return configuration.GetConnectionString("crudStoreDb");
        }
       

    }
}
