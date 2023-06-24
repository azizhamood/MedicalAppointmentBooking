using Api.Model;
using Application.Futures.Category.Command;
using Application.Futures.Periode.Command;
using Application.Futures.Periode.Queries;
using Core.Constaince;
using Core.Exceptions;
using Core.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodeController : ControllerBase
    {
        private IMediator _mediator;

        public PeriodeController(IMediator mediator) {
        
            _mediator = mediator;
        }
        // GET: api/<PeriodeController>
        [HttpGet, Authorize(Roles = $"{UserRole.User},{UserRole.Admin}")]
        public async Task<ResponseModel> Get()
        {
             var reuslt= await _mediator.Send(new GetAllPeriod());
            return new ResponseModel(reuslt);
        }

        // GET api/<PeriodeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PeriodeController>
        [HttpPost, Authorize(Roles = $"{UserRole.User},{UserRole.Admin}")]
        public async Task<ResponseModel> Post([FromBody] PeroidModel peroidModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new ResponseModel(500, ModelState.ToString());

                var result = await _mediator.Send(new CreatePeriod() { PeroidModel = peroidModel });
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


        // PUT api/<PeriodeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PeriodeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
