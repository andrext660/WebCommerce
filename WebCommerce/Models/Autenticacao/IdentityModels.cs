﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebCommerce.Models.Classes;
using WebCommerce.Models.DatabaseSeed;

namespace WebCommerce.Models
{
    // É possível adicionar dados do perfil do usuário adicionando mais propriedades na sua classe ApplicationUser, visite https://go.microsoft.com/fwlink/?LinkID=317594 para obter mais informações.
    public class ApplicationUser : IdentityUser
    {

        public Cliente Cliente { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Observe que o authenticationType deve corresponder àquele definido em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Adicionar declarações de usuário personalizado aqui
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new ClinicaDataBaseSeed());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<WebCommerce.Models.Classes.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<WebCommerce.Models.Classes.Categoria> Categorias { get; set; }

        public System.Data.Entity.DbSet<WebCommerce.Models.Classes.Produto> Produtoes { get; set; }

        public System.Data.Entity.DbSet<WebCommerce.Models.Classes.Promocao> Promocaos { get; set; }

        public System.Data.Entity.DbSet<WebCommerce.Models.Classes.Endereco> Enderecoes { get; set; }


        public System.Data.Entity.DbSet<WebCommerce.Models.Classes.Venda> Vendas { get; set; }

        public System.Data.Entity.DbSet<WebCommerce.Models.Classes.Cupom> Cupoms { get; set; }
    }
}