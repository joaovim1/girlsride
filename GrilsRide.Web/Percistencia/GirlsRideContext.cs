using GirlsRide.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace GirlsRide.Web.Percistencia
{
    public class GirlsRideContext : DbContext
    {
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cartao> Cartoes  { get; set; }
        public DbSet<Pagamento> pagamentos { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<ClienteAgendamento> clienteAgendamentos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurando a chave composta associativa
            modelBuilder.Entity<ClienteAgendamento>()
                .HasKey(v => new { v.ClienteId, v.AgendamentoId });
            base.OnModelCreating(modelBuilder);
            //Configurando a associativa com  Cliente
            modelBuilder.Entity<ClienteAgendamento>()
                .HasOne(v => v.Cliente)
                .WithMany(v => v.clienteAgendamentos)
                .HasForeignKey(v => v.ClienteId);
            //Configurando a  associativa com Agendamento
            modelBuilder.Entity<ClienteAgendamento>()
               .HasOne(v => v.Agendamento)
               .WithMany(v => v.clienteAgendamentos)
               .HasForeignKey(v => v.AgendamentoId);
            base.OnModelCreating(modelBuilder);
        }

        public GirlsRideContext(DbContextOptions op):base(op)
        {
        }

       
    }
}
