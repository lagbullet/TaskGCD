using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GCDApp
{
    class Program
    {
        static int EuclidAlgorithm(int a, int b)
        {
            while (b != 0)
                b = a % (a = b);
            return a;
        }

        static int BinaryAlgorithm(int a, int b)
        {
            int nod = 1;
            int tmp;
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            if (a == b)
                return a;
            if (a == 1 || b == 1)
                return 1;
            while (a != 0 && b != 0)
            {
                if (a % 2 == 0 && b % 2 == 0)
                {
                    nod *= 2;
                    a /= 2;
                    b /= 2;
                    continue;
                }
                if (a % 2 == 0 && b % 2 != 0)
                {
                    a /= 2;
                    continue;
                }
                if (a % 2 != 0 && b % 2 == 0)
                {
                    b /= 2;
                    continue;
                }
                if (a > b)
                {
                    tmp = a;
                    a = b;
                    b = tmp;
                }
                tmp = a;
                a = (b - a) / 2;
                b = tmp;
            }
            if (a == 0)
                return nod * b;
            else
                return nod * a;
        }

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            Random r = new Random();
            List<int> list = new List<int>() { 99467310};
            int k = 0;
            while (list.Count != 1000000)
            {
                k = r.Next(3,int.MaxValue);
                if (k % 3 == 0)
                    list.Add(k);
            }
            k = 0;
            stopwatch.Start();
            foreach (var item in list)
                k = EuclidAlgorithm(k, item);
            stopwatch.Stop();
            Console.WriteLine($"Greatest common divisor - {k}; \nTime spent on colculation - {stopwatch.Elapsed}");
            Console.ReadLine();
            stopwatch.Reset();
            stopwatch.Start();
            foreach (var item in list)
                k = BinaryAlgorithm(k,item);
            stopwatch.Stop();
            Console.WriteLine($"Greatest common divisor - {k}; \nTime spent on colculation - {stopwatch.Elapsed}");
            Console.ReadLine();
        }
    }
}
