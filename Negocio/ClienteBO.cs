using Triscal.Entities;
using Triscal.Repositorio;
using System.Collections.Generic;

namespace Triscal.Negocio
{
    public class ClienteBO
    {
        public void InseriCliente(Cliente Cliente)
        {
            new Clientes().InseriCliente(Cliente);
        }

        public void ExcluiCliente(int? id)
        {
            new Clientes().ExcluiCliente(id);
        }
        public IEnumerable<Cliente> BuscaTodosClientes()
        {
            return new Clientes().BuscaTodosClientes();
        }
        public Cliente BuscaCliente(int? id)
        {
            return new Clientes().BuscaCliente(id);
        }
        public void AtualizaCliente(Cliente Cliente)
        {
            new Clientes().AtualizaCliente(Cliente);
        }
    }
}
