using Triscal.Entities;
using System.Collections.Generic;

namespace Triscal.Repositorio
{
    interface IClientes
    {
        void InseriCliente(Cliente Cliente);
        void AtualizaCliente(Cliente Cliente);
        Cliente BuscaCliente(int? id);
        IEnumerable<Cliente> BuscaTodosClientes();
        void ExcluiCliente(int? id);
    }
}
