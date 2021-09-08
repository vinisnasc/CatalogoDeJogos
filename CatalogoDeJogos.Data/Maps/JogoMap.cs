using CatalogoDeJogos.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoDeJogos.Data.Maps
{
    class JogoMap : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
            builder.ToTable("Funcionarios");

            builder.HasKey(x => x.Id);

            builder.HasOne<Plataforma>(d => d.PlataformaConsole)
                   .WithMany(f => f.Jogos)
                   .HasForeignKey(k => k.IdPlataforma);
        }
    }
}
