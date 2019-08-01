using Triscal.Entities;
using System.Collections.Generic;

namespace Triscal.Repositorio
{
    interface IEnderecos
    {
        void InseriEndereco(Endereco Endereco);
        void AtualizaEndereco(Endereco Endereco);
        Endereco BuscaEndereco(int? id);
        void ExcluiEndereco(int? id);
        IEnumerable<Endereco> BuscaTodosEnderecos();
    }
}
