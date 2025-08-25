using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using phnds_processos.domain.Usuario;

namespace phnds_processos.data.ef.Mapper
{
    public class UsuarioEntityConfiguration : BaseEntityConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> entity)
        {
            entity.ToTable("usuario");

            entity.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(x => x.Senha)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(x => x.Tipo)
                .IsRequired();


        }
    }
}
