using System;
using System.ComponentModel.DataAnnotations;

namespace CatalogoDeJogos.Model.DTO.ImputModel
{
    public class PlataformaImputModel
    {
        [Required(ErrorMessage = "Nome da plataforma é obrigatorio!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O nome da plataforma deve conter entre 3 e 20 caracteres!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Nome do desenvolvedor é obrigatorio!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O nome do desenvolvedor deve conter entre 3 e 20 caracteres!")]
        public string Desenvolvedor { get; set; }
        [Required]
        [Range(0, 2025, ErrorMessage = "Utilize um ano valido!")]
        public int Ano { get; set; }
    }
}
