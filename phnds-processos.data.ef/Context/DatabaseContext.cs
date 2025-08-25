using Microsoft.EntityFrameworkCore;
using phnds_processos.data.ef.Mapper;
using phnds_processos.domain.Advogado;
using phnds_processos.domain.Andamento;
using phnds_processos.domain.Parte;
using phnds_processos.domain.Usuario;

namespace phnds_processos.data.ef.DbContext 
{
    public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<ProcessoEntity> Processos { get; set; }
        public DbSet<ParteEntity> Partes { get; set; }
        public DbSet<AndamentoEntity> Andamentos { get; set; }
        public DbSet<AdvogadoEntity> Advogados { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProcessoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ParteEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AndamentoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AdvogadoEntityConfiguration());
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
