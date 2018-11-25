using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebCommerce.Models;

namespace WebCommerce
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            ApplicationDbContext db = new ApplicationDbContext();
            CreateRoles(db);
            CreateSuperUser(db);
            AddPermissaoSuperUser(db);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }





        private void AddPermissaoSuperUser(ApplicationDbContext db)
        {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName("admin@unit.br");
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));


            if (!userManager.IsInRole(user.Id, "Admin"))
            {
                userManager.AddToRole(user.Id, "Admin");
            }

        }

        private void CreateSuperUser(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
 
            //Conta do Super Usuário
            var user = userManager.FindByName("admin@unit.br");

            if (user == null)
            {
                user = new ApplicationUser
                {

                    //Usuário Master
                    UserName = "admin@unit.br",
                    Email = "admin@unit.br"
                };

                userManager.Create(user, "123456");
            }
          
        }

        //Criar as Funções
        private void CreateRoles(ApplicationDbContext db)
        {

            //Conexão que serve para gerar os métodos de criação/edicao/
            //Roles Padrão do Sistema, se quiser adicionar mais algum tipo de permissão é so seguir o modelo abaixo e especificar o "nome" da Role.
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));


            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }

            
            if (!roleManager.RoleExists("Usuario"))
            {
                roleManager.Create(new IdentityRole("Usuario"));
            }

        }



    }
}
