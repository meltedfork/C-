using System;

namespace basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            // Print Odd between 1-255
            // for(int i = 0; i < 256; i++)
            // {
                // if(i % 2 != 0){
                //     Console.WriteLine(i);   
                // }

            // Print Sum
            // int sum = 0;
            // for(int i = 0; i < 256; i++)
            // {
            //     sum += i;
            //     Console.WriteLine($"The number is {i} and the sum is {sum}");   
            // }

            // Iterate through Array
            // int[] arrayX = {1,3,5,7,9,13};
            // for (int i = 0; i < arrayX.Length; i++)
            // {
            //     System.Console.WriteLine(arrayX[i]);
            // }
            
            // Find Max
            // int[] arrayY = {1,3,-6,0,-2,5};
            // int max = arrayY[0];
            // for (int i = 0; i < arrayX.Length; i++)
            // {
            //     if (max < arrayY[i])
            //     {
            //         max = arrayY[i];
            //     }
            // }
            // System.Console.WriteLine(max);

            // Get Average
            // int sum = 0;
            // int count = 0;
            // int[] arrAvg = {2,10,-3};
            // for (int i = 0; i < arrAvg.Length; i++)
            // {
            //     sum += arrAvg[i];
            //     count++;
            // }
            // int avg = sum / count;  // optional line of code adds another variable
            //System.Console.WriteLine(sum/count);

            // Odd Number Array
            // int[] y = new int[128];
            // int j = 0;
            // for(int i = 1; i < 256; i++)
            // {  
            //     if(i % 2 != 0)
            //     {  
            //         y[j] = i; 
            //         j++;     
            //     }
            // }
            // System.Console.WriteLine($"This is array y: {y[10]}");       

            //Greater than Y
            // int count = 0;
            // int Y = 3;
            // int[] arrCase = {1,3,5,7};
            // for(int idx = 0; idx < arrCase.Length; idx++)
            // {
            //     if(arrCase[idx] > Y)
            //     {
            //         count++;
            //     }
            // }
            // System.Console.WriteLine(count);

            //Square the values
            // int[] arrStuff = {1,5,10,-2};
            // for(int idx = 0; idx < arrStuff.Length; idx++)
            // {
            //     arrStuff[idx] = arrStuff[idx] * arrStuff[idx];
            // }
            // System.Console.WriteLine(arrStuff[3]);

            // Eliminate Neg Nums
            // int[] arrX = {1,5,10,-2};
            // for(int idx = 0; idx < arrX.Length; idx++)
            // {
            //     if(arrX[idx] < 0)
            //     {
            //         arrX[idx] = 0;
            //     }
            // }
            // System.Console.WriteLine(arrX[3]);

            // Min, Max, Avg
            // int[] arrX = {1,5,10,-2};
            // int max = arrX[0];
            // int min = arrX[0];
            // double sum = 0;
            // double count = arrX.Length;
            
            // for(int idx = 0; idx < arrX.Length; idx++)
            // {
            //     sum += arrX[idx];
            //     if(arrX[idx] > max)
            //     {
            //         max = arrX[idx];
            //     }
            //     else if(arrX[idx] < min)
            //     {
            //         min = arrX[idx];
            //     }
            // }
            // double avg = sum/count;
            // System.Console.WriteLine($"This is max num {max} and this is min num {min}. The avg is {avg}");

            //Shifting Values in Array
            // int[] arrX = {1,5,10,7,-2};
            // for(int idx = 1; idx < arrX.Length; idx++)
            // {
            //     arrX[idx - 1] = arrX[idx];
            //     arrX[arrX.Length - 1] = 0;
            // }
            // System.Console.WriteLine(arrX[0]);
            // System.Console.WriteLine(arrX[4]);

            // Number to String
            int[] arrX = {-1,-3,2};
            string word = "Dojo";
            for(int idx = 0; idx < arrX.Length; idx++)
            {
                if(arrX[idx] < 0)
                {
                    arrX[idx] = word;
                }
            }
            System.Console.WriteLine(arrX[0]);
            //this doesn't work but the concept is right; need to figure of num.ToString
        }

    }
}
