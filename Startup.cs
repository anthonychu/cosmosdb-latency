using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace cosmosdb_latency
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var policy = new ConnectionPolicy ();
            var documentClient = new DocumentClient(new Uri(Configuration["CosmosDB:Uri"]), 
                Configuration["CosmosDB:Key"], policy);
            documentClient.OpenAsync().Wait();
            documentClient.CreateDatabaseIfNotExistsAsync(new Database { Id = "test" }).Wait();
            documentClient.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("test"), 
                new DocumentCollection { Id = "test" }, 
                new RequestOptions{ OfferThroughput = 400 });

            services.AddSingleton<IDocumentClient>(documentClient);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
