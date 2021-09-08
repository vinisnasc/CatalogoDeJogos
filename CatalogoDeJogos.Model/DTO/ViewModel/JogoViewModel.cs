using CatalogoDeJogos.Model.Entities;
using CatalogoDeJogos.Model.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoDeJogos.Model.DTO.ViewModel
{
    public class JogoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Produtora { get; set; }
        public double Preco { get; set; }
        public Genero Genero { get; set; }
        public Plataforma PlataformaConsole { get; set; }
    }
}
