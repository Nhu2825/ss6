using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ss6
{
    internal class Bonus
    {
        public static void Main()
        {

        }
        /*public static void VD()
   {
       int[] a = new int[100];
       Random ran = new Random();
       for (int i = 0; i < a.Length; i++)
       {
           a[i] = ran.Next(0,100)+1;
       }
       foreach (int i in a)
       {
           Console.Write($"{i}, ");
       }
   }*/
        public static void Ex01()
        {
            Console.Write("Nhap so phan tu cua mang: __"); int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhap phan tu {i}: __");
                a[i] = int.Parse(Console.ReadLine());
            }
            foreach (int i in a) Console.Write($"{i}, ");
            change(a);
            Console.WriteLine();
            Console.WriteLine("Mang sau khi thay doi ");
            for (int i = 0; i < n; i++)
                Console.Write($"{a[i]}  ");
        }
        public static void change(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i]++;
            }
        }

    }
}
