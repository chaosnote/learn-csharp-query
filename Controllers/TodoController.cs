using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Services;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : BaseAPIController
    {
        public TodoController(TodoService _service)
        {
            m_service = _service ;
        }
        private readonly TodoService m_service ;

        [HttpPost("add")]
        public dynamic AddItem([FromBody] TodoAddModel v)
        {
            if (TryValidateModel(v) )
            {
                m_service.AddItem(v) ;
                return Ok(toJSON(new HttpResponseModel() { Code = HttpResponseType.OK }));
            }
            else return BadRequest(toJSON(new HttpResponseModel() { Code = HttpResponseType.FAIL }));
        }

        [HttpGet("list")]
        public dynamic GetItems()
        {
            return Ok(toJSON(new HttpResponseModel() { Code = HttpResponseType.OK, Data = this.m_service.GetItems() }));
        }

        [HttpPost("remove")]
        public dynamic RemoveItem([FromBody]string[] v)
        {
            this.m_service.RemoveItem(v) ;
            return Ok(toJSON(new HttpResponseModel() { Code = HttpResponseType.OK }));
        }
    }
}