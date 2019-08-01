using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using API;

namespace Triscal.Teste
{
    public class Contex
    {
        public HttpClient Client { get; set; }
        private TestServer _server;

        public Contex()
        {
            SetupClient();
        }
        private void SetupClient()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = _server.CreateClient();
        }
    }
}
