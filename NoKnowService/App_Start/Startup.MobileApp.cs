using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using NoKnowService.DataObjects;
using NoKnowService.Models;
using Owin;

namespace NoKnowService
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
            config.EnableSystemDiagnosticsTracing();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new NoKnowInitializer());

            // To prevent Entity Framework from modifying your database schema, use a null database initializer
            // Database.SetInitializer<NoKnowContext>(null);

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // This middleware is intended to be used locally for debugging. By default, HostName will
                // only have a value when running in an App Service application.
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }
            app.UseWebApi(config);
        }
    }

    public class NoKnowInitializer : CreateDatabaseIfNotExists<NoKnowContext>
    {
        protected override void Seed(NoKnowContext context)
        {
            List<TodoItem> todoItems = new List<TodoItem>
            {
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
            };

            foreach (TodoItem todoItem in todoItems)
            {
                context.Set<TodoItem>().Add(todoItem);
            }

            List<AccountEntity> accountItems = new List<AccountEntity>
            {
                new AccountEntity { Id = Guid.NewGuid().ToString(), Email = "First item", Password = "First item", Username = "First item" },
             };

            foreach (AccountEntity acccountEntity in accountItems)
            {
                context.Set<AccountEntity>().Add(acccountEntity);
            }

            List<AreaConfigurationEntity> areaItems = new List<AreaConfigurationEntity>
            {
                new AreaConfigurationEntity { Id = Guid.NewGuid().ToString(), KantonId = "First item", GemeindeId = "First item", AccountId = "First item" },
            };

            foreach (AreaConfigurationEntity areaConfigurationEntity in areaItems)
            {
                context.Set<AreaConfigurationEntity>().Add(areaConfigurationEntity);
            }


            List<KantonEntity> kantonItems = new List<KantonEntity>
            {
                new KantonEntity { Id = Guid.NewGuid().ToString(),  Bezeichnung= "First item"},
            };

            foreach (KantonEntity kantonEntity in kantonItems)
            {
                context.Set<KantonEntity>().Add(kantonEntity);
            }

            List<GemeindeEntity> gemeindeItems = new List<GemeindeEntity>
            {
                new GemeindeEntity() { Id = Guid.NewGuid().ToString(), Bezeichnung = "First item", KantonId = "First item"},
            };

            foreach (AreaConfigurationEntity areaConfigurationEntity in areaItems)
            {
                context.Set<AreaConfigurationEntity>().Add(areaConfigurationEntity);
            }
            base.Seed(context);
        }
    }
}

