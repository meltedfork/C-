using System;
using System.Collections.Generic;

namespace boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> stuff = new List<object>();
            stuff.Add(7);
            stuff.Add(28);
            stuff.Add(-1);
            stuff.Add(true);
            stuff.Add("chair");
            // for (var idx = 0; idx < stuff.Count; idx++) 
            // {
            //     System.Console.WriteLine(stuff[idx]);
                
            // }
            int sum = 0;
            foreach (object item in stuff)
            {
                if (item is int)
                {
                    sum = sum + Convert.ToInt32(item);
                    Console.WriteLine($"The number is {item}");
                }
                if (item is string)
                {
                    Console.WriteLine($"The word is {item}");
                }
            }
            System.Console.WriteLine($"The total sum is {sum}"); 
        }
    }
}
