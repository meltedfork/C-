using System;
using System.Collections.Generic;

namespace collection
{
    class Program
    {
        static void Main(string[] args)
        {
            // int [] array1 = {0,1,2,3,4,5,6,7,8,9};
            // string [] array2 = {"Tim", "Martin", "Nikki", "Sara"};
            // bool [] array3 = {true, false, true, false, true, false, true, false, true, false};
            // int [,] array4 = new int [10,10];
            // for(int k = 0; k <10; k++)
            // {
            //     for(int i = 1; i <= 10; i++)
            //     {
            //         for(int j = 1; j <= 10; j++)
            //         {
            //             array4[0,k] = i*j;
            //             Console.WriteLine(array4[0,9]);
            //         }
            //     }
            // }
            // List<string> iceCream = new List<string>();
            // iceCream.Add("Chocolate");
            // iceCream.Add("Vanilla");
            // iceCream.Add("Strawberry");
            // iceCream.Add("Mango");
            // iceCream.Add("Peanut Butter");
            // Console.WriteLine("We currently offer these flavors: ");
            // for (var idx = 0; idx < iceCream.Count; idx++)
            // {
            //     Console.WriteLine(iceCream[idx]);
            // }
            // Console.WriteLine(iceCream.Count);
            // Console.WriteLine(iceCream[2]);
            // iceCream.RemoveAt(2);
            // Console.WriteLine(iceCream.Count);
            Dictionary<string,string> profile = new Dictionary<string,string>();
            profile.Add("Tim", "Strawberry");
            profile.Add("Martin", "Vanilla");
            profile.Add("Nikki", "Mango");
            profile.Add("Sara", "Peanut Butter");
            foreach (var entry in profile)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}
