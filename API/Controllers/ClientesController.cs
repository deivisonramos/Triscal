using System;
using System.Collections.Generic;
using System.Linq;
using Triscal.Negocio;
using Triscal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Cliente")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpGet("BuscaTodosClientes")]
        public ActionResult<IEnumerable<Cliente>> BuscaTodosClientes()
        {
            try
            {
                return new ClienteBO().BuscaTodosClientes().ToList();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("BuscaCliente/{id}")]
        public ActionResult<Cliente> BuscaCliente(int id)
        {
            try
            {
                return new ClienteBO().BuscaCliente(id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("InseriCliente")]
        public void InseriCliente([FromBody] Cliente value)
        {
            try
            {
                new ClienteBO().InseriCliente(value);
            }
            catch (Exception ex)
            {
                BadRequest(ex);
            }
        }

        [HttpPut("AtualizaCliente")]
        public void AtualizaCliente([FromBody] Cliente value)
        {
            try
            {
                new ClienteBO().AtualizaCliente(value);
            }
            catch (Exception ex)
            {
                BadRequest(ex);
            }
        }

        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
            try
            {
                new ClienteBO().ExcluiCliente(id);
            }
            catch (Exception ex)
            {
                BadRequest(ex);
            }
        }
    }
}