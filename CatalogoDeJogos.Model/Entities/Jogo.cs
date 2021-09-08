using CatalogoDeJogos.Model.Entities.Enums;
using CatalogoDeJogos.Model.Interfaces;
using System;

namespace CatalogoDeJogos.Model.Entities
{
    public class Jogo : IEntity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Produtora { get; set; }
        public double Preco { get; set; }
        public Genero Genero { get; set; }
        public Plataforma PlataformaConsole { get; set; }
        public Guid IdPlataforma { get; set; }
    }
}
