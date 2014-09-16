using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            
            Stopwatch s = new Stopwatch();
            s.Start();
            double nk1 = NOverK1(n, k);
            s.Stop();
            Console.WriteLine("Opdracht B.1 (" + n + "/" + k + ") = " + nk1 + " (" + s.Elapsed + "sec)");
            s.Reset();
            s.Start();
            double nk2 = NOverK2(n, k);
            s.Stop();
            Console.WriteLine("Opdracht B.2 (" + n + "/" + k + ") = " + nk2 + " (" + s.Elapsed + "sec)");
            s.Reset();
            s.Start();
            double nk3 = NOverK3(n, k);
            s.Stop();
            Console.WriteLine("Opdracht B.3 (" + n + "/" + k + ") = " + nk3 + " (" + s.Elapsed + "sec)");
            s.Reset();
            s.Start();
            double nk4 = NOverK4(n, k);
            s.Stop();
            Console.WriteLine("Opdracht B.4 (" + n + "/" + k + ") = " + nk4 + " (" + s.Elapsed + "sec)"); 
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
            for (int i = 1; i <= k; i++)
            {
                result = result * (n-(k-i))/i;
            }
            return result;
        }   
            
        private static double NOverK3(int n, int k)
        {
            if (k == 0 || k == n)
            {
                return 1;
            }
            else
            {
                return NOverK3(n - 1, k - 1) * n / k;
            }
        }  
             
        private static double NOverK4(int n, int k)
        {
            if (k == 0 || k == n)
            {
                return 1;
            }
            else
            {
                return NOverK4(n - 1, k) + NOverK4(n - 1, k - 1);
            }
        }
    }
}
