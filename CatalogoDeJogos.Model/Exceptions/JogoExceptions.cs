using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoDeJogos.Model.Exceptions
{
    public class JogoJaCadastradoException : Exception
    {
        public JogoJaCadastradoException() : base("Esse jogo já consta em nosso banco de dados!")
        { }
    }

    public class JogoNaoExisteException : Exception
    {
        public JogoNaoExisteException() : base("Não foi encontrado o console pedido!")
        { }
    }
}
