using Api.Model;
using Application.Futures.Doctor.Command;
using Application.Futures.Medical.Command;
using Application.Futures.Medical.Queries;
using Application.Futures.Periode.Queries;
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

    public class MedicalController : ControllerBase
    {
        private IMediator _mediator;
        public MedicalController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<MedicalController>
        [HttpGet]
        public async Task<ResponseModel> Get()
        {
            var reuslt = await _mediator.Send(new GetAllMedical());
            return new ResponseModel(reuslt);
        }

        // GET api/<MedicalController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MedicalController>
        [HttpPost]
        public async Task<ResponseModel> Post([FromBody] MedicalModel medical)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new ResponseModel(500, ModelState.ToString());

                var result = await _mediator.Send(new CreateMedical() { MedicalModel = medical });
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

        // PUT api/<MedicalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MedicalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
