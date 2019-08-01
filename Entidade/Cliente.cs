using Triscal.Validacoes;
using System.ComponentModel.DataAnnotations;

namespace Triscal.Entities
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        [StringLength(30)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo idade é obrigatório")]
        public int Idade { get; set; }

        [StringLength(11)]
        [Required(ErrorMessage = "CPF obrigatório")]
        [ValidacaoDoCPF(ErrorMessage = "CPF inválido")]
        public string Cpf { get; set; }
    }
}
