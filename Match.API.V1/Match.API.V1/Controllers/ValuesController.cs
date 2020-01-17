using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Match.API.V1.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Match.API.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _dataContext; 


        public ValuesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: api/Values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dataContext.Values.ToList());
        }

        // GET: api/Values/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return Ok(_dataContext.Values.SingleOrDefault(v=> v.Id == id));
        }

        // POST: api/Values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
