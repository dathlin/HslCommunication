using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.Enthernet.Redis;
using Newtonsoft.Json;

namespace HslRedisDesktop
{
    public class RedisSettings
    {
        public string Name { get; set; }

        public string IpAddress { get; set; }

        public int Port { get; set; }

        public string Password { get; set; }

        [JsonIgnore]
        public int DBBlock { get; set; }

        [JsonIgnore]
        public RedisClient Redis { get; set; }

        public RedisClient GetClient( )
        {
            return new RedisClient( IpAddress, Port, Password ) { ConnectTimeOut = 5000 };
        }

        public override string ToString( ) => Name;
    }

    /// <summary>
    /// DB块的设置对象信息，暂时不用于存储
    /// </summary>
    public class DbSettings
    {
        public DbSettings( )
        {
            Filter = "*";
        }

        /// <summary>
        /// DB块的信息
        /// </summary>
        public int DBNumber { get; set; }

        /// <summary>
        /// 过滤的信息数据，默认为*
        /// </summary>
        public string Filter { get; set; }
    }
}
