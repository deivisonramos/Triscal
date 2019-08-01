using System.Threading.Tasks;
using FluentAssertions;
using System.Net;
using Xunit;

namespace Triscal.Teste
{
    public class ValidaClientes
    {

        private readonly Contex _test;
        public ValidaClientes()
        {
            _test = new Contex();
        }

        [Fact]
        public async Task StatusDeSucessoSeTiverRetornoPositivo()
        {
            var response = await _test.Client.GetAsync("/Clientes/BuscaTodosClientes");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task StatusDeSucessoSeTiverRetornoPositivoPorIDParaCliente()
        {
            var response = await _test.Client.GetAsync("/Clientes/BuscaCliente/2");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task StatusDeSucessoSeTiverRetornoPositivoPorIDParaEndereco()
        {
            var response = await _test.Client.GetAsync("/Enderecos/BuscaEndereco/1");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}