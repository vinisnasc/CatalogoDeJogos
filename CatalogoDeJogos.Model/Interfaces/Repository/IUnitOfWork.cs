namespace CatalogoDeJogos.Model.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        public IJogoRepository JogoRepository { get; }
        public IPlataformaRepository PlataformaRepository { get; }
    }
}
