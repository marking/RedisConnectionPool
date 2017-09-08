using System;
using StackExchange.Redis;

namespace RedisConnectionPool
{
	public static class RedisConnectionPool
	{
		private static Lazy<ConnectionMultiplexer> Connection = new Lazy<ConnectionMultiplexer>(
				() => ConnectionMultiplexer.Connect(System.Configuration.ConfigurationManager.AppSettings["redisConnection"]));

		public static IDatabase RedisServerDB
		{
			get
			{
				return Connection.Value.GetDatabase();
			}
		}
	}
}
