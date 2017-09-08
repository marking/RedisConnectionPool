
using System;
using StackExchange.Redis;

namespace RedisConnectionPool
{
    public static class LazyRedisConnectionPool
    {

        private static Lazy<ConfigurationOptions> configOptions
            = new Lazy<ConfigurationOptions>(() =>
            {
                var configOptions = new ConfigurationOptions();
                configOptions.EndPoints.Add(System.Configuration.ConfigurationManager.AppSettings["redisConnection"]);
                configOptions.ClientName = "SafeRedisConnection";
                configOptions.ConnectTimeout = 100000;
                configOptions.SyncTimeout = 100000;
                configOptions.AbortOnConnectFail = false;
                return configOptions;
            });

        private static Lazy<ConnectionMultiplexer> conn
            = new Lazy<ConnectionMultiplexer>(
                () => ConnectionMultiplexer.Connect(configOptions.Value));

        private static ConnectionMultiplexer SafeConn
        {
            get
            {
                return conn.Value;
            }
        }
        public static IDatabase RedisServerDB
		{
			get
			{
				return conn.Value.GetDatabase();
			}
		}

    }
}
