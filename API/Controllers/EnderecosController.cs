using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Triscal.Negocio;
using Triscal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Endereco")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        [HttpGet("BuscaTodosEnderecos")]
        public ActionResult<IEnumerable<Endereco>> BuscaTodosEnderecos()
        {
            try
            {
                return new EnderecoBO().BuscaTodosEnderecos().ToList();
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

        [HttpGet("BuscaEndereco/{id}")]
        public ActionResult<Endereco> BuscaEndereco(int id)
        {
            try
            {
                return new EnderecoBO().BuscaEndereco(id);
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

        [HttpPost("InseriEndereco")]
        public void InseriEndereco([FromBody] Endereco value)
        {
            try
            {
                new EnderecoBO().InseriEndereco(value);
            }
            catch (Exception ex)
            {
                BadRequest(ex);
            }
        }

        [HttpPut("AtualizaEndereco")]
        public void AtualizaEndereco([FromBody] Endereco value)
        {
            try
            {
                new EnderecoBO().AtualizaEndereco(value);
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
                new EnderecoBO().ExcluiEndereco(id);
            }
            catch (Exception ex)
            {
                BadRequest(ex);
            }
        }
    }
}
