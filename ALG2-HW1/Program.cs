using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALG2_HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read N
            Console.Write("N = ");
            string nStr = Console.ReadLine();

            // Read K
            Console.Write("K = ");
            string kStr = Console.ReadLine();

            // Store N & K
            int n = Convert.ToInt32(nStr);
            int k = Convert.ToInt32(kStr); 

            Console.WriteLine("Opdracht B.1 (" + n + "/" + k + ") = " + NOverK1(n, k));
            Console.WriteLine("Opdracht B.2 (" + n + "/" + k + ") = " + NOverK2(n, k));
            Console.WriteLine("Opdracht B.3 (" + n + "/" + k + ") = " + NOverK3(n, k));
            Console.WriteLine("Opdracht B.4 (" + n + "/" + k + ") = " + NOverK4(n, k));
            Console.Read();
        }
        private static double f(int n)
        {
            if (n > 0)
            {
                double f = 1;
                for (int i = 1; i < n; i++)
                {
                    f *= i + 1;
                }
                return f;
            }
            return 0;
        }
        private static double NOverK1(int n, int k)
        {   
            return f(n)/(f(k)*(f(n-k)));   
        }               
        private static double NOverK2(int n, int k)
        {
            double result = 1;
            for (int i = 0; i <= k ; i++)
            {
                result *= ((n - i) / (i+1));
            }
            return result;
        }               
        private static double NOverK3(int n, int k)
        {
            return ((n - 1) / (k - 1)) * n / k;
        }               
        private static double NOverK4(int n, int k)
        {
            double result = 0;
            return result;
        }
    }
}
