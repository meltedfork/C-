using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using DojoLeague.Models;
 
namespace DojoLeague.Factory
{
    public class NinjaFactory : IFactory<Ninja>
    {
        private string connectionString;
        public NinjaFactory()
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

        public void Add(Ninja ninja)
        {
            using (IDbConnection dbConnection = Connection) 
            {
                string query =  "INSERT INTO Ninjas (Name, Level, Description) VALUES(@Name, @Level, @Description)";
                dbConnection.Open();
                dbConnection.Execute(query, ninja);
            }
        }
        public IEnumerable<Ninja> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                System.Console.WriteLine("=============something here");
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT Dojos.Name as Dojos_Id, Ninjas.Id, Ninjas.Name FROM Ninjas LEFT JOIN Dojos ON Ninjas.Dojos_Id = Dojos.Id");
            }
        }

        public IEnumerable<Ninja> FindById(int Id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>($"SELECT * FROM Ninjas WHERE Id = {Id}");
            }
        }    
        public IEnumerable<Ninja> NinjasForDojoById(int Id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = $"SELECT * FROM Ninjas JOIN Dojos ON Ninjas.Dojos_Id WHERE Dojos.Id = Ninjas.Dojos_Id AND Dojos.Id = {Id}";
                dbConnection.Open();
        
                var myNinjas = dbConnection.Query<Ninja, Dojo, Ninja>(query, (ninja, dojo) => { ninja.dojo = dojo; return ninja; });
                return myNinjas;
            }
        }
    }
}        