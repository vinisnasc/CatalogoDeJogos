using CatalogoDeJogos.Data.ContextDB;
using CatalogoDeJogos.Model.Interfaces.Repository;

namespace CatalogoDeJogos.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Contexto _contexto;
        public IJogoRepository JogoRepository { get; }
        public IPlataformaRepository PlataformaRepository { get; }

        public UnitOfWork(Contexto contexto)
        {
            _contexto = contexto;
            JogoRepository = new JogoRepository(contexto);
            PlataformaRepository = new PlataformaRepository(contexto);
        }
    }
}
