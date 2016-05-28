using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NetJitterAPI.Models
{
    [MetadataType(typeof(ServerModel))]
    public partial class SERVER
    {
        internal sealed class ServerModel
        {
            private ServerModel() { }

            [Required(ErrorMessage = "Required Field")]
            public string DESCRIPTION { get; set; }

            [Required(ErrorMessage = "Required Field")]
            public string IP_ADDRESS { get; set; }
        }

    }
}