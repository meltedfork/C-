using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using LostInWoods.Models;
 
namespace LostInWoods.Factory
{
    public class TrailFactory : IFactory<Trail>
    {
        private string connectionString;
        public TrailFactory()
        {
            connectionString = "server=localhost;userid=root;password=;port=3306;database=FindTrails;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get 
            {
                return new MySqlConnection(connectionString);
            }
        }
        // TRAILFACTORY CLASS DEFINITION
 
        public void Add(Trail item)
        {
            using (IDbConnection dbConnection = Connection) 
            {
                string query =  "INSERT INTO Trail (Name, Description, Length, Elevation, Longitude, Latitude) VALUES(@Name, @Description, @Length, @Elevation, @Longitude, @Latitude)";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Trail> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM Trail");
            }
        }
        public Trail FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM Trail WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

    }
}
