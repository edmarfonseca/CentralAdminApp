using CentralAdminApp.Domain.Dtos;
using CentralAdminApp.Domain.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CentralAdminApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemasController : ControllerBase
    {
        private readonly ISistemaService _sistemaService;

        public SistemasController(ISistemaService sistemaService)
        {
            _sistemaService = sistemaService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(SistemaResponse), 201)]
        public IActionResult Post([FromBody] SistemaRequest dto)
        {
            try
            {
                var response = _sistemaService.Add(dto);
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
        [ProducesResponseType(typeof(SistemaResponse), 200)]
        public IActionResult Put(int id, [FromBody] SistemaRequest dto)
        {
            try
            {
                var response = _sistemaService.Update(id, dto);
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
        [ProducesResponseType(typeof(SistemaResponse), 200)]
        public IActionResult Delete(int id)
        {
            try
            {
                var response = _sistemaService.Delete(id);
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
        [ProducesResponseType(typeof(List<SistemaResponse>), 200)]
        public IActionResult Get()
        {
            try
            {
                var response = _sistemaService.Get();

                if (response.Any())
                    return StatusCode(200, response);
                else
                    return StatusCode(204, new { message = "Nenhum sistema encontrado." });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SistemaResponse), 200)]
        public IActionResult Get(int id)
        {
            try
            {
                var response = _sistemaService.Get(id);
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