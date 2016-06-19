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
            : base("NolletoConnection")
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
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            Relationships(modelBuilder);

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

        private void Relationships(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                    .HasRequired<TipoProduto>(s => s.TipoProduto)
                    .WithMany(s => s.Produtos)
                    .HasForeignKey(s => s.IdTipoProduto);

            modelBuilder.Entity<Produto>()
                    .HasRequired<Estabelecimento>(s => s.Estabelecimento)
                    .WithMany(s => s.Produtos)
                    .HasForeignKey(s => s.IdEstabelecimento);

            modelBuilder.Entity<EstabelecimentoComentario>()
                    .HasRequired<Estabelecimento>(s => s.Estabelecimento)
                    .WithMany(s => s.Comentarios)
                    .HasForeignKey(s => s.IdEstabelecimento);

            modelBuilder.Entity<EstabelecimentoComentario>()
                    .HasRequired<Usuario>(s => s.Usuario)
                    .WithMany(s => s.EstabelecimentoComentarios)
                    .HasForeignKey(s => s.IdUsuario);

            modelBuilder.Entity<EstabelecimentoVoto>()
                    .HasRequired<Estabelecimento>(s => s.Estabelecimento)
                    .WithMany(s => s.Votos)
                    .HasForeignKey(s => s.IdEstabelecimento);

            modelBuilder.Entity<EstabelecimentoVoto>()
                    .HasRequired<Usuario>(s => s.Usuario)
                    .WithMany(s => s.EstabelecimentoVotos)
                    .HasForeignKey(s => s.IdUsuario);

            modelBuilder.Entity<ProdutoComentario>()
                    .HasRequired<Produto>(s => s.Produto)
                    .WithMany(s => s.ProdutoComentarios)
                    .HasForeignKey(s => s.IdProduto);

            modelBuilder.Entity<ProdutoComentario>()
                    .HasRequired<Usuario>(s => s.Usuario)
                    .WithMany(s => s.ProdutoComentarios)
                    .HasForeignKey(s => s.IdUsuario);

            modelBuilder.Entity<ProdutoVoto>()
                    .HasRequired<Produto>(s => s.Produto)
                    .WithMany(s => s.ProdutoVotos)
                    .HasForeignKey(s => s.IdProduto);

            modelBuilder.Entity<ProdutoVoto>()
                    .HasRequired<Usuario>(s => s.Usuario)
                    .WithMany(s => s.ProdutoVotos)
                    .HasForeignKey(s => s.IdUsuario);

            modelBuilder.Entity<Promocao>()
                    .HasRequired<Estabelecimento>(s => s.Estabelecimento)
                    .WithMany(s => s.Promocoes)
                    .HasForeignKey(s => s.IdEstabelecimento);

            modelBuilder.Entity<Promocao>()
                    .HasRequired<Produto>(s => s.Produto)
                    .WithMany(s => s.Promocoes)
                    .HasForeignKey(s => s.IdProduto);
        }
    }
}
