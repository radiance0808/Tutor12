using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private IDbService _service;

        public OrderController(IDbService service)
        {
            _service = service;
        }


        [HttpGet("{name}")]
        public IActionResult getOrders(string name)
        {
            try
            {
                var res = _service.getOrder(name);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("{id}/orders")]
        public IActionResult newOrder(int id, OrderRequest request)
        {
            try
            {
                _service.newOrder(id, request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}