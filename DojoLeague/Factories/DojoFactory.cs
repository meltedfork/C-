using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using DojoLeague.Models;
 
namespace DojoLeague.Factory
{
    public class DojoFactory : IFactory<Dojo>
    {
        private string connectionString;
        public DojoFactory()
        {
            connectionString = "server=localhost;userid=root;password=;port=3306;database=DojoLeague;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get 
            {
                return new MySqlConnection(connectionString);
            }
        }

        public void Add(Dojo item)
        {
            using (IDbConnection dbConnection = Connection) 
            {
                string query =  "INSERT INTO Dojos (Name, Location, Description) VALUES(@Name, @Location, @Description)";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Dojo> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Dojo>("SELECT * FROM Dojos");
            }
        }

        public Dojo FindById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Dojo>("SELECT * FROM Dojos WHERE Id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public Dojo FindDojoById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var query =
                @"
                SELECT * FROM Dojos WHERE Id = @Id;
                SELECT * FROM Ninjas WHERE Dojos_Id = @Id;
                ";
        
                using (var multi = dbConnection.QueryMultiple(query, new {Id = id}))
                {
                    var dojo = multi.Read<Dojo>().Single();
                    dojo.ninjas = multi.Read<Ninja>().ToList();
                    return dojo;
                }
            }
        }
    }
}       