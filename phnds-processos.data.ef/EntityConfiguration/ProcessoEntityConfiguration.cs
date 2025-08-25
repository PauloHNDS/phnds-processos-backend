using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using phnds_processos.domain.Advogado;

namespace phnds_processos.data.ef.Mapper
{
    public class ProcessoEntityConfiguration : BaseEntityConfiguration<ProcessoEntity>
    {
        public void Configure(EntityTypeBuilder<ProcessoEntity> entity)
        {
            entity.ToTable("processo");

            entity.Property(x => x.NumeroProcesso)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(x => x.Classe)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(x => x.Assunto)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(x => x.Juiz)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(x => x.Vara)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(x => x.InicioProcesso)
                .IsRequired();

            entity.Property(x => x.Estado)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasMany(x => x.Andamentos)
                .WithOne(x => x.Processo)
                .HasForeignKey(x => x.ProcessoId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(x => x.Partes)
                .WithOne(x => x.Processo)
                .HasForeignKey(x => x.ProcessoId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
