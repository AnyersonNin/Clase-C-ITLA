using BoletoBusApp.Data.Base;
using BoletoBusApp.Data.Interfaces;
using BoletoBusApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BoletoBusApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBusRepository _busRepository;
        public BusController(IBusRepository busRepository)
        {
          _busRepository = busRepository;
        }
        // GET: api/<BusController>
        [HttpGet("GetBuses")]
        public async Task<IActionResult> Get()
        {
          OperationResult<List<BusModel>> result = await _busRepository.GetAll();

          if (!result.Success)
          {
            return BadRequest(result);
          }

          return Ok(result);
        }

        // GET api/<BusController>/5
        [HttpGet("GetBusbyId")]
        public async Task<IActionResult> Get(int id)
        {
            OperationResult<BusModel> result = await _busRepository.GetEntityBy(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
               

        // POST api/<BusController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BusController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BusController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
