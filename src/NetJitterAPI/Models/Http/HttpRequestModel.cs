using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetJitterAPI.Models
{
    public class HttpRequestModel
    {
        private SERVER[] serverList;

        public SERVER[] ServerList
        {
            get
            {
                return serverList;
            }

            set
            {
                serverList = value;
            }
        }
    }
}