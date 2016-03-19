using System.Threading.Tasks;

namespace RedisConnectionPool
{
	class Program
	{
		static void Main(string[] args)
		{
			for (int i = 0; i < 100000; i++)
			{
				string[] redisKeyList = new string[] {
					"a", "b", "c", "d", "e", "f", "g", "h", "i",
					"j", "k", "l", "m", "n", "o", "p", "q", "r",
					"s", "t", "u", "v", "w", "x", "y", "z" };
				Parallel.ForEach(redisKeyList, currentKey =>
				{
					RedisConnectionPool.RedisServerDB.StringSet(currentKey, "some data to store at this location in redis");

					string ignoreMe = RedisConnectionPool.RedisServerDB.StringGet(currentKey);
				});
			}
		}
	}
}
