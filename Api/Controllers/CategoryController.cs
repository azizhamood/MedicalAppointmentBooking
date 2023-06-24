
using Api.Model;
using Application.Futures.Category.Command;
using Application.Futures.Category.Queries;
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
    public class CategoryController : ControllerBase
    {
        private IMediator _mediator;
        public CategoryController( IMediator mediator) 
        { 
            _mediator= mediator;
        }
        // GET: api/<CategoryController>
        [HttpGet, Authorize(Roles = $"{UserRole.User},{UserRole.Admin}" )]
        public async Task<ResponseModel> Get()
        {
            var reuslt = await _mediator.Send(new GetAllCategorys());
            return new ResponseModel(reuslt);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoryController>
        [HttpPost, Authorize(Roles = $"{UserRole.User},{UserRole.Admin}")]
        public async Task<ResponseModel> Post([FromBody] CategoryModel categoryModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new ResponseModel(500, ModelState.ToString());

                var result = await _mediator.Send(new CreateCategory() { Category = categoryModel });
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

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
