using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SilverPE_Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SilverPE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SilverJewelryController : ControllerBase
    {
        private readonly IJewelryRepository _jewelryRepository;

        public SilverJewelryController(IJewelryRepository jewelryRepository)
        {
            _jewelryRepository = jewelryRepository;
        }

        // GET: api/<SilverJewelryController>
        [EnableQuery]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        // GET api/<SilverJewelryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SilverJewelryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SilverJewelryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SilverJewelryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
