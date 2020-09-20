using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Servico;
using Aplicacao.Servico.Interfaces;
using Dominio.Interfaces;
using Dominio.Repositorio;
using Dominio.Servicos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositorio.Entidades;
using SistemaVenda.DAL;


namespace SistemaVenda
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            

            //TODO: Fica por enquanto, pois o projeto ainda n�o foi completamente migrado para o padr�o DDD
            services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("MyStock")));

            //A principio ser� definitiva
            services.AddDbContext<Repositorio.Contexto.ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MyStock")));


            //Padr�o de projeto Singleton (Design Patterns) basicamente ir� conter apenas umas inst�ncia, ou seja, n�o vai criar mais de uma inst�ncia quando n�o precisa mudar
            //N�o � muito indicado usar, pois cria uma unica sess�o, assim se outro usu�rio se logasse iria replicar o nome do usu�rio na aplica��o que esto usando
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddHttpContextAccessor();
            services.AddSession();


            //Servi�os Aplica��o
            services.AddScoped<IServicoAplicacaoCategoria, ServicoAplicacaoCategoria>();

            //Dom�nio
            services.AddScoped<IServicoCategoria, ServicoCategoria>();

            //Repositorio
            services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error/Index");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
