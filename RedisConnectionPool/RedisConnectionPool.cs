using System;
using StackExchange.Redis;

namespace RedisConnectionPool
{
	public static class RedisConnectionPool
	{
		private static Lazy<ConnectionMultiplexer> Connection = new Lazy<ConnectionMultiplexer>(
				() => ConnectionMultiplexer.Connect("localhost:6379"));

		public static IDatabase RedisServerDB
		{
			get
			{
				return Connection.Value.GetDatabase();
			}
		}
	}
}
