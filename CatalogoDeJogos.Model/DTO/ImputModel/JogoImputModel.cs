using CatalogoDeJogos.Model.Entities.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CatalogoDeJogos.Model.DTO.ImputModel
{
    public class JogoImputModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O nome do jogo deve conter entre 3 e 20 caracteres!")]
        public string Nome { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "O nome da produtora deve conter entre 2 e 20 caracteres!")]
        public string Produtora { get; set; }
        [Required]
        [Range(0, 500, ErrorMessage = "O preço deve estar entre 0 a 500 reais")]
        public double Preco { get; set; }
        [Required]
        [EnumDataType(typeof(Genero))]
        public string Genero { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "O nome do console deve conter entre 2 e 20 caracteres!")]
        public string PlataformaConsole { get; set; }
    }
}
