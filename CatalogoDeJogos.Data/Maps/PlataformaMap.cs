using CatalogoDeJogos.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoDeJogos.Data.Maps
{
    public class PlataformaMap : IEntityTypeConfiguration<Plataforma>
    {
        public void Configure(EntityTypeBuilder<Plataforma> builder)
        {
            builder.ToTable("Console");

            builder.HasKey(x => x.Id);

        }
    }
}
