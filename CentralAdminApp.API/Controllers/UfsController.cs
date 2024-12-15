using CentralAdminApp.Domain.Dtos;
using CentralAdminApp.Domain.Interfaces.Services;
using CentralAdminApp.Domain.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CentralAdminApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UfsController : ControllerBase
    {
        private readonly IUfService _ufService;

        public UfsController(IUfService ufService)
        {
            _ufService = ufService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UfResponse), 201)]
        public IActionResult Post([FromBody] UfRequest dto)
        {
            try
            {
                var response = _ufService.Add(dto);
                return StatusCode(201, response);
            }
            catch (ValidationException e)
            {
                var errors = e.Errors.Select(e => new
                {
                    Name = e.PropertyName,
                    Error = e.ErrorMessage
                });

                return StatusCode(400, errors);
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UfResponse), 200)]
        public IActionResult Put(int id, [FromBody] UfRequest dto)
        {
            try
            {
                var response = _ufService.Update(id, dto);
                return StatusCode(200, response);
            }
            catch (ValidationException e)
            {
                var errors = e.Errors.Select(e => new
                {
                    Name = e.PropertyName,
                    Error = e.ErrorMessage
                });

                return StatusCode(400, errors);
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UfResponse), 200)]
        public IActionResult Delete(int id)
        {
            try
            {
                var response = _ufService.Delete(id);
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<UfResponse>), 200)]
        public IActionResult Get()
        {
            try
            {
                var response = _ufService.Get();

                if (response.Any())
                    return StatusCode(200, response);
                else
                    return StatusCode(204, new { message = "Nenhuma UF encontrada." });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UfResponse), 200)]
        public IActionResult Get(int id)
        {
            try
            {
                var response = _ufService.Get(id);
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }
    }
}