using System;
using System.Threading.Tasks;

namespace RedisConnectionPool
{
    class Program
    {
        static void Main(string[] args)
        {
            var loop = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["iterations"]);
            string[] redisKeyList = new string[] {
                    "a", "b", "c", "d", "e", "f", "g", "h", "i",
                    "j", "k", "l", "m", "n", "o", "p", "q", "r",
                    "s", "t", "u", "v", "w", "x", "y", "z" };
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            Console.WriteLine("Setting many keys");
            try
            {
                for (int i = 0; i < loop; i++)
                {
                    Parallel.ForEach(redisKeyList, currentKey =>
                    {
                        RedisConnectionPool.RedisServerDB.StringSet(currentKey, "some data to store at this location in redis");

                    });
                }
            }
            catch { }
            sw.Stop();
            Console.WriteLine($"performed {(loop * redisKeyList.Length) / sw.Elapsed.TotalSeconds} writes / sec");
            sw.Restart();
            Console.WriteLine("Getting many keys");

            for (int i = 0; i < loop; i++)
            {
                var res = Parallel.ForEach(redisKeyList, currentKey =>
                {
                    string ignoreMe = RedisConnectionPool.RedisServerDB.StringGet(currentKey);
                });

            }
            Console.WriteLine($"performed {(loop * redisKeyList.Length) / sw.Elapsed.TotalSeconds} reads / sec");

        }
    }
}
