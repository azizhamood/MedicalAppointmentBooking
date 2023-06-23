
using Api.Model;
using Application.Futures.Doctor.Command;
using Application.Futures.Doctor.Queries;
using Application.Futures.Periode.Queries;
using Core.Constaince;
using Core.Exceptions;
using Core.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {

        private IMediator _mediator;
        public DoctorController(IMediator mediator) {
            _mediator= mediator;
        }    
        // GET: api/<DoctoController>
        [HttpGet]
        public async Task<ResponseModel> Get()
        {
            var reuslt = await _mediator.Send(new GetAllDoctors());
            return new ResponseModel(reuslt);
        }

        // GET api/<DoctoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DoctoController>
        [HttpPost]
        public async Task<ResponseModel> Post([FromBody] DoctorModel doctor)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new ResponseModel(500, ModelState.ToString());

                var result = await _mediator.Send(new CreateDoctor() { Doctor=doctor });
                return new ResponseModel(result);
            }
            catch (MABException ex)
            {
                Log.Information(ex.ToString());
                return new ResponseModel(ex.Code, ex.Message);
            }
            catch (Exception ex)
            {
                Log.Information(ex.ToString());
                return new ResponseModel(500, ex.Message);
            }
        }

        // PUT api/<DoctoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DoctoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
