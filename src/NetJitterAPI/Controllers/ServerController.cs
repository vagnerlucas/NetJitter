using NetJitterAPI.Controllers.Filters;
using NetJitterAPI.Core;
using NetJitterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NetJitterAPI.Controllers
{
    public class ServerController : BaseController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody]SERVER model)
        {
            var responseModel = new HttpResponseModel();

            if (!ModelState.IsValid)
            {
                responseModel.ResponseType = ResponseType.rtError;
                responseModel.Message = "Some required fields or values are invalid";

                string modelFields = string.Join(" | ", ModelState.Keys
                                                .Select(v => v));

                string errMessage = string.Join(" | ", ModelState.Values
                                            .SelectMany(v => v.Errors)
                                            .Select(e => e.ErrorMessage));
                responseModel.Exception = "Exception info: " + modelFields + " :: " + errMessage;
            }
            else
            {
                try
                {
                    using (context = new LocalDatabaseEntities())
                    {
                        var server = context.SERVER.Add(model);
                        context.SaveChanges();
                        responseModel.ResponseType = ResponseType.rtSuccess;
                        responseModel.Message = "Added successfully";
                        responseModel.Data = server;
                    }
                }
                catch (Exception ex)
                {
                    responseModel.ResponseType = ResponseType.rtError;
                    responseModel.Message = "An error has occurred";
                    responseModel.Exception = ex;
                }
            }
            return Ok<HttpResponseModel>(responseModel);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Remove([FromBody]SERVER model)
        {
            var responseModel = new HttpResponseModel();

            try
            {
                using (context = new LocalDatabaseEntities())
                {
                    var entityServer = context.SERVER.Find(model.ID);
                    if (entityServer == null) throw new Exception("SERVER not found to remove");

                    context.SERVER.Remove(entityServer);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                responseModel.ResponseType = ResponseType.rtError;
                responseModel.Message = "An error has occurred";
                responseModel.Exception = ex;
            }

            return Ok<HttpResponseModel>(responseModel);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Edit([FromBody]SERVER model)
        {
            var responseModel = new HttpResponseModel();

            if (!ModelState.IsValid)
            {
                responseModel.ResponseType = ResponseType.rtError;
                responseModel.Message = "Some required fields or values are invalid";

                string modelFields = string.Join(" | ", ModelState.Keys
                                                .Select(v => v));

                string errMessage = string.Join(" | ", ModelState.Values
                                            .SelectMany(v => v.Errors)
                                            .Select(e => e.ErrorMessage));
                responseModel.Exception = "Exception info: " + modelFields + " :: " + errMessage;
            }
            else
            {
                try
                {
                    using (context = new LocalDatabaseEntities())
                    {
                        var entityServer = context.SERVER.Find(model.ID);
                        if (entityServer == null) throw new Exception("SERVER not found to edit");

                        entityServer.DESCRIPTION = model.DESCRIPTION;
                        entityServer.IP_ADDRESS = model.IP_ADDRESS;
                        entityServer.NAME = model.NAME;

                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    responseModel.ResponseType = ResponseType.rtError;
                    responseModel.Message = "An error has occurred";
                    responseModel.Exception = ex;
                }
            }
            return Ok<HttpResponseModel>(responseModel);
        }

        public async Task<IHttpActionResult> GetServerList()
        {
            var responseModel = new HttpResponseModel();
            try
            {
                using (context = new LocalDatabaseEntities())
                {
                    responseModel.ResponseType = ResponseType.rtSuccess;
                    responseModel.Message = "Action executed successfully";
                    responseModel.Data = context.SERVER.ToArray();
                }
            }
            catch (Exception ex)
            {
                responseModel.ResponseType = ResponseType.rtError;
                responseModel.Message = "An error has occurred";
                responseModel.Exception = ex;
                //Even though it is an exception, return an "OK"
            }

            return Ok<HttpResponseModel>(responseModel);
        }

        [HttpGet]
        //[BindJson]
        public async Task<IHttpActionResult> GetStatistics()//(HttpRequestModel model)
        {
            var responseModel = new HttpResponseModel();

            responseModel.Data = pingServer.GetStatistics();

            return Ok<HttpResponseModel>(responseModel);
        }
    }
}
