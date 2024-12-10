using CentralAdminApp.Domain.Dtos;
using CentralAdminApp.Domain.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CentralAdminApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClienteResponse), 201)]
        public IActionResult Post([FromBody] ClienteRequest dto)
        {
            try
            {
                var response = _clienteService.Add(dto);
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
        [ProducesResponseType(typeof(ClienteResponse), 200)]
        public IActionResult Put(int id, [FromBody] ClienteRequest dto)
        {
            try
            {
                var response = _clienteService.Update(id, dto);
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
        [ProducesResponseType(typeof(ClienteResponse), 200)]
        public IActionResult Delete(int id)
        {
            try
            {
                var response = _clienteService.Delete(id);
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
        [ProducesResponseType(typeof(List<ClienteResponse>), 200)]
        public IActionResult Get()
        {
            try
            {
                var response = _clienteService.Get();

                if (response.Any())
                    return StatusCode(200, response);
                else
                    return StatusCode(204, new { message = "Nenhum cliente encontrado." });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClienteResponse), 200)]
        public IActionResult Get(int id)
        {
            try
            {
                var response = _clienteService.Get(id);
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