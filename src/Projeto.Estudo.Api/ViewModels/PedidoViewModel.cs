using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Estudo.Api.ViewModels
{
    public class PedidoViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(2)]
        [MaxLength(150)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Data de Registro é obrigatório")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Data Registro")]
        public DateTime DataRegistro { get; set; }
    }
}
