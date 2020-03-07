using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    class Program
    {
        // delegate void DoSomeJob(int x, int y);
        //delegate int DoNumbers(int x, int y);
        delegate bool DoCheck(int x);
        static void Main(string[] args)
        {
            Nullable<int> age = 12;
            age = null;

            int? width = 23;
            width = null;

            DoCheck dc = x =>
            {
                if (x % 2 == 1)
                {
                    return false;
                }
                else
                    return true;
            };

            Console.WriteLine(dc(21)); 

            Func<int,int,int> t1 = (x, y) => { return x + y; };
            Console.WriteLine(t1(5,8));

          
            Action<int,int> d = ( x1 ,y) =>  Console.WriteLine(x1 + y); 
            d(4,6);
            d(7, 8);
            Action<int,int> d2 = (x, y) =>
            {
                if (x > y)
                {
                    Console.WriteLine($"Max {x}");
                }
                else
                {
                    Console.WriteLine($"Max {y}");
                }
            };
            d2(6, 8);
            d2(4, 6);
            Console.ReadLine();
        }
    }
}
