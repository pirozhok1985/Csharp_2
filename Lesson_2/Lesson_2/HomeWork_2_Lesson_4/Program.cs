using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_2_Lesson_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> Pairs = new Dictionary<int, int>();
            Random rand = new Random();
            int count = 1;
            List<int> list = new List<int>(50);
            for (var i = 0; i < list.Capacity; i++)
            {
                list.Add(rand.Next(0,10));
            }

            for (var i = 0; i < list.Capacity; i++)
            {
                if (Pairs.ContainsKey(list[i]))
                {
                    Pairs[list[i]] += 1;
                }
                else
                {
                    Pairs.Add(list[i],count);
                }
            }

            foreach (var item in list)
            {
                Console.Write(item);
            }

            Console.WriteLine();

            foreach (var element in Pairs)
            {
                Console.WriteLine("{0}:{1}",element.Key, element.Value);
            }
        }
    }
}
