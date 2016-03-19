using StackExchange.Redis;

namespace RedisConnectionPool
{
	public class RedisConnection
	{
		private static ConnectionMultiplexer redis;
		private static IDatabase db;

		public static IDatabase RedisServerDB
		{
			get
			{
				if (db == null)
				{
					redis = ConnectionMultiplexer.Connect("localhost:6379");
					db = redis.GetDatabase();
				}

				return db;
			}
		}
	}
}
