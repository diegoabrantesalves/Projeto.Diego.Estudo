using Projeto.Estudo.Api.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Estudo.Api.ViewModels
{
    public class PedidoViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(2, ErrorMessage = "O nome tem que estar entre 2 e 150 caracteres")]
        [MaxLength(150, ErrorMessage = "O nome tem que estar entre 2 e 150 caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Data de Registro é obrigatório")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Data Registro")]
        [CurrentDate(ErrorMessage = "Data tem que ser maior ou igual +a data atual")]
        public DateTime DataRegistro { get; set; }
    }
}
