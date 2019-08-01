using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triscal.Entities
{
    public class Endereco
    {
        public int IdEndereco { get; set; }

        [Required(ErrorMessage = "O campo bairro é obrigatório", AllowEmptyStrings = false)]
        [StringLength(40)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo cidade é obrigatório", AllowEmptyStrings = false)]
        [StringLength(40)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório", AllowEmptyStrings = false)]
        [StringLength(40)]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo logradouro é obrigatório", AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Logradouro { get; set; }
    }
}
