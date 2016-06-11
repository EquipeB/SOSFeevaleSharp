using Database.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class SOSFeevaleContext : IdentityDbContext<Usuario>
    {
        public SOSFeevaleContext()
            : base("DefaultConnection")
        {
        }

        public static SOSFeevaleContext Create()
        {
            return new SOSFeevaleContext();
        }
        
        public DbSet<Estabelecimento> Estabelecimento { get; set; }
        public DbSet<EstabelecimentoComentario> EstabelecimentoComentario { get; set; }
        public DbSet<EstabelecimentoVoto> EstabelecimentoVoto { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ProdutoComentario> ProdutoComentario { get; set; }
        public DbSet<ProdutoVoto> ProdutoVoto { get; set; }
        public DbSet<TipoProduto> TipoProduto { get; set; }
        public DbSet<Promocao> Promocao { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            modelBuilder.Entity<Usuario>()
                .ToTable("Usuario", "dbo").Property(p => p.UserName).HasColumnName("Usuario");

            modelBuilder.Entity<Usuario>()
                .ToTable("Usuario", "dbo").Property(p => p.PasswordHash).HasColumnName("Senha");

            modelBuilder.Entity<Usuario>()
                .ToTable("Usuario", "dbo").Property(p => p.Email).HasColumnName("Email");

            modelBuilder.Entity<IdentityRole>()
                .ToTable("Perfil");

            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UsuarioPerfil");

            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UsuarioClaim");

            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UsuarioLogin");

            //modelBuilder.Entity<IdentityUser>()
            //    .ToTable("Usuario", "dbo").Ignore(p => p.AccessFailedCount);

            //modelBuilder.Entity<IdentityRole>()
            //    .ToTable("Perfil").Property(p => p.Id).HasColumnName("IdPerfil");

            //modelBuilder.Entity<IdentityRole>()
            //    .ToTable("Perfil").Property(p => p.Name).HasColumnName("Descricao");

            //modelBuilder.Entity<IdentityUserRole>()
            //    .ToTable("Usuario_Perfil").Property(p => p.UserId).HasColumnName("IdUsuario");

            //modelBuilder.Entity<IdentityUserRole>()
            //    .ToTable("Usuario_Perfil").Property(p => p.RoleId).HasColumnName("IdPerfil");

            //modelBuilder.Entity<IdentityUser>()
            //    .Ignore(p => p.Claims);

            //modelBuilder.Entity<IdentityUser>()
            //    .Ignore(p => p.Logins);


            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<IdentityUserClaim>().HasKey(r => new { r.Id });
            //modelBuilder.Ignore<IdentityUserLogin>();
            //modelBuilder.Ignore<IdentityUserRole>();
            //modelBuilder.Ignore<IdentityRole>();
            //modelBuilder.Ignore<IdentityUserClaim>();
        }
    }
}
