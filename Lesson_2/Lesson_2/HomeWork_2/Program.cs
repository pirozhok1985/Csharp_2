using System;

namespace HomeWork_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Employee[] arr = {
            //    new fpEmployee("Вася", "Пупкин", 1234),
            //    new fpEmployee("Петя", "Васечкин", 1235),
            //    new fpEmployee("Илья", "Курякин", 1236),
            //    new phpEmployee("Михаил", "Хлыстов", 2234, 500),
            //    new phpEmployee("Леонид", "Пальчиков", 2235, 600)
            //};
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    arr[i].Display();
            //}
            //Array.Sort(arr);
            //Console.WriteLine();
            //Console.WriteLine();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    arr[i].Display();
            //}

            Department it = new Department(5);
            it[0] = new phpEmployee("Михаил", "Хлыстов", 2234, 500);
            it[1] = new phpEmployee("Леонид", "Пальчиков", 2235, 600);
            it[2] = new fpEmployee("Илья", "Курякин", 1236);
            it[3] = new fpEmployee("Петя", "Васечкин", 1235);
            it[4] = new fpEmployee("Вася", "Пупкин", 1234);
            foreach (Employee val in it)
            {
                val.Display();
            }
            Console.ReadLine();
        }
    }
}
