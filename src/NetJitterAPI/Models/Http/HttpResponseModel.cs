using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace NetJitterAPI.Models
{
    internal enum ResponseType
    {
        rtSuccess,
        rtError,
        rtWarning,
    }

    internal static class ResponseTypeExtensions
    {
        public static int StatusCode(this ResponseType responseType)
        {
            switch (responseType)
            {
                case ResponseType.rtSuccess:
                    return 0;
                case ResponseType.rtError:
                    return 1;
                case ResponseType.rtWarning:
                    return 2;
                default:
                    throw new Exception("Invalid status code");
            }
        }

        public static string Description(this ResponseType responseType)
        {
            switch (responseType)
            {
                case ResponseType.rtSuccess:
                    return "Success";
                case ResponseType.rtError:
                    return "Error";
                case ResponseType.rtWarning:
                    return "Warning";
                default:
                    throw new Exception("Response type invalid");
            }
        }
    }

    public class HttpResponseModel : ISerializable
    {
        private ResponseType responseType;
        private string message = "";
        private object data;
        private object exception;

        internal ResponseType ResponseType
        {
            get
            {
                return responseType;
            }

            set
            {
                responseType = value;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

        public object Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }

        public object Exception
        {
            get
            {
                return exception;
            }

            set
            {
                exception = value;
            }
        }

        public int StatusCode
        {
            get { return responseType.StatusCode(); }
        }

        public string Description
        {
            get { return responseType.Description();  }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ResponseType", ResponseType, typeof(ResponseType));
            info.AddValue("Message", Message, typeof(string));
            info.AddValue("Data", Data, typeof(object));
            info.AddValue("Exception", Exception, typeof(object));
            info.AddValue("StatusCode", StatusCode, typeof(int));
            info.AddValue("Description", Description, typeof(string));
        }
    }
}