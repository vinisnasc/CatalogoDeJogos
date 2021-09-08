using System;

namespace CatalogoDeJogos.Model.Exceptions
{
    public class PlataformaJaCadastradaException : Exception
    {
        public PlataformaJaCadastradaException() : base("Esse console já consta em nosso banco de dados!")
        { }
    }

    public class PlataformaNaoExisteException : Exception
    {
        public PlataformaNaoExisteException() : base("Não foi encontrado o console pedido!")
        { }
    }
}
