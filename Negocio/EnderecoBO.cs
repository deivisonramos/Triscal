using Triscal.Entities;
using Triscal.Repositorio;
using System.Collections.Generic;


namespace Triscal.Negocio
{
    public class EnderecoBO
    {
        public void InseriEndereco(Endereco Endereco)
        {
            new Enderecos().InseriEndereco(Endereco);
        }

        public void ExcluiEndereco(int? id)
        {
            new Enderecos().ExcluiEndereco(id);
        }
        public IEnumerable<Endereco> BuscaTodosEnderecos()
        {
            return new Enderecos().BuscaTodosEnderecos();
        }
        public Endereco BuscaEndereco(int? id)
        {
            return new Enderecos().BuscaEndereco(id);
        }
        public void AtualizaEndereco(Endereco Endereco)
        {
            new Enderecos().AtualizaEndereco(Endereco);
        }
    }
}
