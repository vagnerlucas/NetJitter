using NetJitterAPI.Core;
using NetJitterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace NetJitterAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class BaseController : ApiController
    {
        protected LocalDatabaseEntities context;
        protected static PingServer pingServer;

        public BaseController()
        {
            pingServer = pingServer ?? new PingServer();
        }

        protected override void Dispose(bool disposing)
        {
            if (context != null)
                context.Dispose();
            base.Dispose(disposing);
        }
    }
}
