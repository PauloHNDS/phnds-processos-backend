using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using phnds_processos.domain.Base;

namespace phnds_processos.data.ef.Mapper
{
    public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => x.Code);

            builder.Property(x => x.CriadoEm)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.AtualizadoEm)
                   .IsRequired(false)
                   .HasDefaultValue(null);

            builder.Property(x => x.ApagadoEm)
                .IsRequired(false)
                .HasDefaultValue(null);

            builder.Property(x => x.Apagado)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
