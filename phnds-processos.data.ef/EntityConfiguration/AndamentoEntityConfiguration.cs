using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using phnds_processos.domain.Andamento;

namespace phnds_processos.data.ef.Mapper
{
    public class AndamentoEntityConfiguration : BaseEntityConfiguration<AndamentoEntity>
    {
        public void Configure(EntityTypeBuilder<AndamentoEntity> builder)
        {
            builder.ToTable("andamento");

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(x => x.Processo)
                .WithMany(p => p.Andamentos)
                .HasForeignKey(x => x.ProcessoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
