using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestAsyncAwaitMethods();
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        public async static void TestAsyncAwaitMethods()
        {
            await LongRunningMethod();
        }

        public static async Task<int> LongRunningMethod()
        {
            Console.WriteLine("Starting Long Running method...");
            await Task.Delay(5000);
            Console.WriteLine("End Long Running method...");
            return 1;
        }
    }

}


/*******************************************

And the output is:

Starting Long Running method...
Press any key to exit...
End Long Running method...
Thus,

Main starts the long running method via TestAsyncAwaitMethods. That immediately returns without halting the current thread and we immediately see 'Press any key to exit' message
All this while, the LongRunningMethod is running in the background. Once its completed, another thread from Threadpool picks up this context and displays the final message
Thus, not thread is blocked

******************************************/