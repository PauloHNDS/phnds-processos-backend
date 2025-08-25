using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using phnds_processos.domain.Advogado;

namespace phnds_processos.data.ef.Mapper
{
    public class AdvogadoEntityConfiguration : BaseEntityConfiguration<AdvogadoEntity>
    {
        public void Configure(EntityTypeBuilder<AdvogadoEntity> builder)
        {
            
            builder.ToTable("advogado");
            

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.OAB)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Celular)
                .IsRequired()
                .HasMaxLength(15);  

            builder.HasMany(x => x.Parte)
                .WithOne(x => x.Advogado)
                .HasForeignKey(x => x.AdvogadoId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
