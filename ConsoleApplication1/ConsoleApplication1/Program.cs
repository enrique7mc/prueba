using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static Random r = new Random();

        static void Main(string[] args)
        {
            var t = SumAsync();
            Console.WriteLine(t.IsCompleted);
            Console.WriteLine(t.Result);
        }

        static async Task<int> GetNumberAsync()
        {            
            await Task.Delay(3000);
            int i = r.Next(10);
            Console.WriteLine(i);
            return i;
        }

        static async Task<int> SumAsync()
        {
            var t1 = GetNumberAsync();
            var t2 = GetNumberAsync();
            var results = await Task.WhenAll<int>(t1, t2);

            return results[0] + results[1];
        }
    }
}
