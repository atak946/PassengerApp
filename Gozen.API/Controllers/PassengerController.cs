using Gozen.Application.Abstract;
using Gozen.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gozen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerService _service;

        public PassengerController(IPassengerService service)
        {
            _service = service;
        }

        /* 
         * 
         * {type} => ONLINE, OFFLINE, USA, UK ETC..
         * 
         */

        // GET: api/<PassengerController>/{type}
        [HttpGet("{type}")]
        public async Task<List<PassengerDto>> GetAsync(string type)
        {
            return await _service.Read(type);
        }

        // GET api/<PassengerController>/5
        [HttpGet("{id}/{type}")]
        public async Task<PassengerDto> GetAsync(string id, string type)
        {
            return await _service.Read(Guid.Parse(id), type);
        }

        // POST api/<PassengerController>/{type}
        [HttpPost("{type}")]
        public async Task Post(string type, [FromBody] PassengerDto passenger)
        {
            await _service.Create(passenger, type);
        }

        // PUT api/<PassengerController>/{type}
        [HttpPut("{type}")]
        public async Task PutAsync(string type, [FromBody] PassengerDto passenger)
        {
            await _service.Update(passenger, type);
        }

        // DELETE api/<PassengerController>/5/{type}
        [HttpDelete("{id}/{type}")]
        public async void Delete(string id, string type)
        {
            await _service.Delete(Guid.Parse(id), type);
        }
    }
}
