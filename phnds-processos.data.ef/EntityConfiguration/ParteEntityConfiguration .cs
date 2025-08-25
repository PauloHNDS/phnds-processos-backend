using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using phnds_processos.domain.Parte;

namespace phnds_processos.data.ef.Mapper
{
    public class ParteEntityConfiguration : BaseEntityConfiguration<ParteEntity>
    {
        public void Configure(EntityTypeBuilder<ParteEntity> builder)
        {
            builder.ToTable("parte");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Tipo)
                .IsRequired();

            builder.HasOne(x => x.Processo)
                .WithMany(x => x.Partes)
                .HasForeignKey(x => x.ProcessoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Advogado)
                .WithMany(x => x.Parte)
                .HasForeignKey(x => x.AdvogadoId)
                .OnDelete(DeleteBehavior.SetNull);
    
        }
    }
}
