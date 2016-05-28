using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetJitterAPI.Models
{
    public class StatisticModel
    {
        private SERVER server;
        private long actualPing = 0;
        private long avgPing = 0;
        private long jitter = 0;

        public long Ping
        {
            get { return actualPing; }
            set { actualPing = value; }
        }

        public SERVER Server
        {
            get { return server; }
            set { server = value; }
        }

        public long Jitter
        {
            get { return jitter; }
            set { jitter = value; }
        }
    }
}