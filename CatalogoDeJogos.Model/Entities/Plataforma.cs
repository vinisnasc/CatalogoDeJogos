using CatalogoDeJogos.Model.Interfaces;
using System;
using System.Collections.Generic;

namespace CatalogoDeJogos.Model.Entities
{
    public class Plataforma : IEntity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Desenvolvedor { get; set; }
        public int Ano { get; set; }
        public List<Jogo> Jogos { get; set; }
    }
}
