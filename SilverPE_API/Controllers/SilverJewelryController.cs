using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SilverPE_Repository.Interfaces;
using SilverPE_Repository.Request;

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
        public async Task<IActionResult> GetAllJewerly()
        {
            var response = await _jewelryRepository.GetJewelries();
            return Ok(response);
        }

        // GET api/<SilverJewelryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SilverJewelryController>
        [HttpPost]
        public async Task<IActionResult> CreateSilverJewerlry([FromBody] CreateSilverJewerlryRequest body)
        {
            var response = await _jewelryRepository.AddJewelry(body);

            if (response)
            {
                return Ok(new
                {
                    Success = response,
                });
            }
            return BadRequest(new
            {
                Success = response,
                Message = "Failed to add jewelry",
            });
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
