using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UvvFintech.Model;

namespace UvvFintech.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Cliente> ClienteS { get; set; }
        public DbSet<Corrente> CorrenteS { get; set; }
        public DbSet<Poupanca> PoupancaS { get; set; }
        public DbSet<Depositar> DepositarS { get; set; }
        public DbSet<Sacar> SacarS { get; set; }
        public DbSet<Transferencia> TransferenciaS { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=UvvFintech;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Tabela de Clientes
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Cliente>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Cliente>().Property(c => c.Senha).IsRequired();
            modelBuilder.Entity<Cliente>().Property(c => c.Cpf).IsRequired();
            modelBuilder.Entity<Cliente>().Property(c => c.Telefone).IsRequired();
            modelBuilder.Entity<Cliente>().Property(c => c.Email).IsRequired();
            modelBuilder.Entity<Cliente>().Property(c => c.Rua);
            modelBuilder.Entity<Cliente>().Property(c => c.Numero);
            modelBuilder.Entity<Cliente>().Property(c => c.Bairro);
            modelBuilder.Entity<Cliente>().Property(c => c.Cidade);
            modelBuilder.Entity<Cliente>().HasKey(c => c.Id);
            modelBuilder.Entity<Cliente>().HasMany<Conta>(c => c.Contas).WithOne(c => c.Dono);

            //Tabelas de Contas Corrente
            modelBuilder.Entity<Corrente>().ToTable("ContaCorrente");
            modelBuilder.Entity<Corrente>().Property(c => c.Numero).IsRequired();
            modelBuilder.Entity<Corrente>().Property(c => c.Senha).IsRequired();
            modelBuilder.Entity<Corrente>().Property(c => c.Saldo).IsRequired().HasDefaultValue(0.00);
            modelBuilder.Entity<Corrente>().Property(c => c.LimiteSaque).IsRequired();

            //Tabela de Contas Poupança
            modelBuilder.Entity<Poupanca>().ToTable("ContaPoupanca");
            modelBuilder.Entity<Poupanca>().Property(p => p.Numero).IsRequired();
            modelBuilder.Entity<Poupanca>().Property(p => p.Senha).IsRequired();
            modelBuilder.Entity<Poupanca>().Property(p => p.Saldo).IsRequired().HasDefaultValue(0.00);
            modelBuilder.Entity<Poupanca>().Property(p => p.LimiteSaque).IsRequired();

            //Tabela Base das Contas (Classe Abstrata)
            modelBuilder.Entity<Conta>().UseTpcMappingStrategy();
            modelBuilder.Entity<Conta>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Conta>().HasKey(c => c.Id);
            modelBuilder.Entity<Conta>().HasOne<Cliente>(c => c.Dono).WithMany().HasForeignKey(c => c.ClienteId);
            modelBuilder.Entity<Conta>().HasMany<Sacar>().WithOne();
            modelBuilder.Entity<Conta>().HasMany<Depositar>().WithOne();
            modelBuilder.Entity<Conta>().HasMany<Transferencia>().WithOne();

            //Tabela da Transação de Depósitos
            modelBuilder.Entity<Depositar>().ToTable("Deposito");
            modelBuilder.Entity<Depositar>().Property(d => d.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Depositar>().Property(d => d.Valor).IsRequired();
            modelBuilder.Entity<Depositar>().Property(d => d.DataHora).IsRequired();
            modelBuilder.Entity<Depositar>().HasKey(d => d.Id);
            modelBuilder.Entity<Depositar>().HasOne<Conta>(d => d.ContaRelacionada).WithMany().HasForeignKey(d => d.ContaId);

            //Tabela da Transação de Saques
            modelBuilder.Entity<Sacar>().ToTable("Saque");
            modelBuilder.Entity<Sacar>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Sacar>().Property(s => s.Valor).IsRequired();
            modelBuilder.Entity<Sacar>().Property(s => s.DataHora).IsRequired();
            modelBuilder.Entity<Sacar>().HasKey(s => s.Id);
            modelBuilder.Entity<Sacar>().HasOne<Conta>(s => s.ContaRelacionada).WithMany().HasForeignKey(s => s.ContaId);

            //Tabela da Transação de Transferências
            modelBuilder.Entity<Transferencia>().ToTable("Transferencia");
            modelBuilder.Entity<Transferencia>().Property(t => t.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Transferencia>().Property(t => t.Valor).IsRequired();
            modelBuilder.Entity<Transferencia>().Property(t => t.DataHora).IsRequired();
            modelBuilder.Entity<Transferencia>().Property(t => t.Metodo).IsRequired();
            modelBuilder.Entity<Transferencia>().HasKey(t => t.Id);
            modelBuilder.Entity<Transferencia>().HasOne<Conta>(t => t.ContaRelacionada).WithMany().HasForeignKey(t => t.ContaId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Transferencia>().HasOne<Conta>(t => t.ContaDestino).WithMany().HasForeignKey(t => t.ContaDestinoId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
