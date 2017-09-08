using StackExchange.Redis;
using System.Configuration;

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
					redis = ConnectionMultiplexer.Connect(System.Configuration.ConfigurationManager.AppSettings["redisConnection"]);
					db = redis.GetDatabase();
				}

				return db;
			}
		}
	}
}
