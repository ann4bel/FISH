using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace FISH.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        private const string connection_string = @"{TODO}";

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Game> Get()
        {
            const string QUERY = "SELECT * FROM games;";
            List<Game> games = [];
            try {
                //access SQL Server and run your command
                using SqlConnection conn = new(connection_string);
                SqlCommand cmd = new(QUERY, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    // append retrieved record
                    games.Add(new Game{
                        Id = (int) reader["id"],
                        Size = (int) reader["size"],
                        TotalSize = (int) reader["total_size"],
                        OwnerName = (string) reader["owner_name"]
                    });
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex) {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return games;
        }

        [HttpPost("[action]")]
        // [FromBody] is necessary because owner_name is a simple variable
        // for simple variables, the default action is to look in the URI
        public bool NewGame([FromBody] string owner_name)
        {
            const string QUERY = "INSERT INTO games (total_size, size, owner_name) VALUES (6, 1, @owner_name);";
            // connect to the SQL Server through Provider
            try
            {
                //access SQL Server and run your command
                using SqlConnection conn = new(connection_string);
                SqlCommand cmd = new(QUERY, conn);
                cmd.Parameters.Add(new SqlParameter("@owner_name", owner_name));
                conn.Open();
                int numOfRowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                return numOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
                return false;
            }
        }
    }
}
