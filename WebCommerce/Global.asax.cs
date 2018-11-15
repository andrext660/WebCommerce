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
            var user = userManager.FindByName("teste@unit.com.br");
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!userManager.IsInRole(user.Id, "View"))
            {
                userManager.AddToRole(user.Id, "View");
            }



            if (!userManager.IsInRole(user.Id, "Create"))
            {
                userManager.AddToRole(user.Id, "Create");
            }


            if (!userManager.IsInRole(user.Id, "Edit"))
            {
                userManager.AddToRole(user.Id, "Edit");
            }


            if (!userManager.IsInRole(user.Id, "Delete"))
            {
                userManager.AddToRole(user.Id, "Delete");
            }

        }

        private void CreateSuperUser(ApplicationDbContext db)
        {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
 
            //Conta do Super Usuário
            var user = userManager.FindByName("teste@unit.com.br");

            if (user == null)
            {
                user = new ApplicationUser
                {

                    //Usuário Master
                    UserName = "teste@unit.com.br",
                    Email = "teste@unit.com.br"
                };

                userManager.Create(user, "@Unit1234");
            }
          
        }


        //Criar as Funções
        private void CreateRoles(ApplicationDbContext db)
        {

            //Conexão que serve para gerar os métodos de criação/edicao/
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));


            if (!roleManager.RoleExists("Create"))
            {
                roleManager.Create(new IdentityRole("Create"));
            }

            if (!roleManager.RoleExists("Edit"))
            {
                roleManager.Create(new IdentityRole("Edit"));
            }

            if (!roleManager.RoleExists("Delete"))
            {
                roleManager.Create(new IdentityRole("Delete"));
            }

            if (!roleManager.RoleExists("View"))
            {
                roleManager.Create(new IdentityRole("View"));
            }

        }



    }
}
