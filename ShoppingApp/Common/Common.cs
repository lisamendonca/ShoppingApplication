using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingApp.Common
{
    public class JsonResponseModel
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public string ResponseData { get; set; }
        public string RedirectUrl { get; set; }
    }
}
