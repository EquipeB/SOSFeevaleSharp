namespace Database.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;

    internal sealed class Configuration : DbMigrationsConfiguration<SOSFeevaleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SOSFeevaleContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            
            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                CriarRolesPerfils(context);
                var store = new UserStore<Usuario>(context);
                var manager = new UserManager<Usuario>(store);
                var user = new Usuario
                {
                    UserName = "admin"
                };

                manager.Create(user, "adm123");
                manager.AddToRole(user.Id, "Admin");
                context.SaveChanges();
            }

            context.Estabelecimento.AddOrUpdate(
                e => e.IdEstabelecimento,
                new Estabelecimento() { IdEstabelecimento = 1, Nome = "Tiririca", Produtos = ProdutosTiririca(context) },
                new Estabelecimento() { IdEstabelecimento = 2, Nome = "Quicker", Produtos = ProdutosQuicker(context) },
                new Estabelecimento() { IdEstabelecimento = 3, Nome = "Alimentare", Produtos = ProdutosAlimentare(context) }
            );

            context.SaveChanges();
        }

        private Produto[] ProdutosTiririca(SOSFeevaleContext context)
        {
            Produto[] produtos = new Produto[]
            {
                new Produto() { IdProduto = 1, Nome = "Baguete de Frango", Ativo = true, Descricao = "Delicioso baguete de frango", Preco = (decimal)6.5 },
                new Produto() { IdProduto = 2, Nome = "Pão de queijo", Ativo = true, Descricao = "Pão de queijo tentação", Preco = (decimal)2.5 },
                new Produto() { IdProduto = 3, Nome = "Pizza de Coração", Ativo = true, Descricao = "Mini pizza", Preco = 5 },
                new Produto() { IdProduto = 4, Nome = "Baguete de Salame", Ativo = true, Descricao = "Delicioso baguete de salaminho", Preco = (decimal)6.5 },
                new Produto() { IdProduto = 5, Nome = "Pizza de Chocolate", Ativo = true, Descricao = "Mini pizza", Preco = 5 },
                new Produto() { IdProduto = 6, Nome = "Pizza de Calabraza", Ativo = true, Descricao = "Mini pizza", Preco = 5 },
            };

            context.Produto.AddOrUpdate(
                p => p.IdProduto,
                produtos[0],
                produtos[1],
                produtos[2],
                produtos[3],
                produtos[4],
                produtos[5]
            );

            context.SaveChanges();
            return produtos;
        }

        private Produto[] ProdutosQuicker(SOSFeevaleContext context)
        {
            Produto[] produtos = new Produto[]
            {
                new Produto() { IdProduto = 7, Nome = "Pão de Batata", Ativo = true, Descricao = "Pão de bataaaaaataaaa", Preco = (decimal)3.5 },
                new Produto() { IdProduto = 8, Nome = "Pão de Batata com Catupiry", Ativo = true, Descricao = "Pão de bataaaaaataaaa... catupiryy", Preco = (decimal)3.5 },
                new Produto() { IdProduto = 9, Nome = "Pastel de Carne", Ativo = true, Descricao = "Pastel de Carne fora da validade", Preco = (decimal)4.5 },
                new Produto() { IdProduto = 10, Nome = "Pastel de Frango", Ativo = true, Descricao = "Pastel de Catupiry superrrrr delicioso", Preco = (decimal)4.5 },
                new Produto() { IdProduto = 11, Nome = "Enroladinho", Ativo = true, Descricao = "Enroladinho diliça", Preco = 2 },
            };

            context.Produto.AddOrUpdate(
                p => p.IdProduto,
                produtos[0],
                produtos[1],
                produtos[2],
                produtos[3],
                produtos[4]
            );

            context.SaveChanges();
            return produtos;
        }

        private Produto[] ProdutosAlimentare(SOSFeevaleContext context)
        {
            Produto[] produtos = new Produto[]
            {
                new Produto() { IdProduto = 12, Nome = "Bolo de Queijo", Ativo = true, Descricao = "#gigante", Preco = (decimal)4.5 },
                new Produto() { IdProduto = 13, Nome = "Crepe Romeu e Julieta", Ativo = true, Descricao = "Crepe melhor do mundo... ou não", Preco = 4 },
                new Produto() { IdProduto = 14, Nome = "Pastel de Vento", Ativo = true, Descricao = "Acabou, pois o vento levou #Trocadilho", Preco = (decimal)4.5 },
                new Produto() { IdProduto = 15, Nome = "Enroladinho", Ativo = true, Descricao = "Melhor que do Quicker", Preco = 5 },
            };

            context.Produto.AddOrUpdate(
                p => p.IdProduto,
                produtos[0],
                produtos[1],
                produtos[2],
                produtos[3]
            );

            context.SaveChanges();
            return produtos;
        }

        private void CriarRolesPerfils(SOSFeevaleContext context)
        {
            var nomes = new string[] {
                "Admin",
                "User",
                "Company"
            };

            foreach (var nome in nomes)
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = nome };

                manager.Create(role);
            }

            context.SaveChanges();
        }
    }
}
