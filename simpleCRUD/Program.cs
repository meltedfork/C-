using System;
using DbConnection;
    
namespace simpleCRUD
{
    class Program
    {
        public static void read()
        {
            string query = "SELECT * from users";
            var users = DbConnector.Query(query);
            foreach(var user in users)
            {
                System.Console.WriteLine(user["firstname"] + " " + user["lastname"] + " has a favorite number: " + user["favnumber"]);
            }
        }

        public static void create()
        {
            System.Console.WriteLine("Enter your first name");
            string first = Console.ReadLine();
            System.Console.WriteLine("Enter your last name");
            string last = Console.ReadLine();
            System.Console.WriteLine("Enter your favorite number");
            string favnum = Console.ReadLine();
            string query = $"INSERT into users (firstname, lastname, favnumber) VALUES('{first}', '{last}', '{favnum}')";
            DbConnector.Execute(query);
            read();
        }
        
        static void Main(string[] args)
        {  
            create();
        }
    }
}
