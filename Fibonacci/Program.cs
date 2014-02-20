using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
              int f =0;
            while (true)
            {
                Console.WriteLine("输入要计算的位数:");
                string flag = Console.ReadLine();
                if (!int.TryParse(flag,out f))
                {
                    Console.WriteLine("必须输入纯数字");
                    continue;
                }
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                double result = Fibonacci2(f);
                stopwatch.Stop();
                TimeSpan timespan = stopwatch.Elapsed;
                Console.WriteLine(result);
                Console.WriteLine("执行时间："+timespan.TotalSeconds.ToString());
            }
        }

        /// <summary>
        /// 递归算法
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static double Fibonacci1(int n)
        {
            if (n <= 0)
            {
                return 0; 
            }
            else if (n == 1)
            {
                return 1;
            }
            else 
            {
                return Fibonacci1(n - 1) + Fibonacci1(n - 2);
            } 
        }

        /// <summary>
        /// 普通循环
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static double Fibonacci2(int n)
        {
            if (n <= 0)
            {
                return 0;
            }
            double result = 1;
             
            double f1 = 0, f2 = 1;
            for (int i =1; i < n; i++) 
            {
                result = f1 + f2;
                f1 = f2;
                f2 = result;
            }

            return result;
        }

        /// <summary>
        /// 矩阵算法
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static double Fibonacci3(int n)
        {
            double[,] a = new double[2, 2] { { 1, 1 }, { 1, 0 } };
            double[,] b = MatirxClub(a, n);
            return b[1, 0];
        }

        static double[,] MatirxClub(double[,] a, int n)
        {
            if (n == 1) { return a; }
            else if (n == 2) { return Matirx(a, a); }
            else if (n % 2 == 0)
            {
                double[,] temp = MatirxClub(a, n / 2);
                return Matirx(temp, temp);
            }
            else
            {
                double[,] temp = MatirxClub(a, n / 2);
                return Matirx(Matirx(temp, temp), a);
            }
        }

        static double[,] Matirx(double[,] a, double[,] b)
        {
            double[,] c = new double[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return c;
        }

        /// <summary>
        /// 公式算法
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static double Fibonacci4(int n)
        {
            double k5 = Math.Sqrt(5);
            double sum2 = Math.Floor((Math.Pow(((1 + k5) / 2), n) - Math.Pow(((1 - k5) / 2), n)) / k5);
            return sum2;        
        }
    }
}
