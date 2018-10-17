using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using api.Models;

namespace api.Controllers
{
    public class BaseAPIController : ControllerBase
    {
        public string toJSON(HttpResponseModel value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}