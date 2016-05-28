using NetJitterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;

namespace NetJitterAPI.Controllers.Filters
{
    public class BindJson : System.Web.Http.Filters.ActionFilterAttribute
    {
        /// <summary>
        /// ActionFilterAttribute override
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var json = actionContext.Request.RequestUri.ParseQueryString()["json"];
            var serializer = new JavaScriptSerializer();
            actionContext.ActionArguments["model"] = json == null ? null : serializer.Deserialize(json, typeof(HttpRequestModel));
        }
    }
}