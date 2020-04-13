using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
//using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Payment.Application;
using Payment.Domain;
using Payment.Domain.Jwttoken;

//using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Payment.Infra.FireBase;

namespace Payment
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration config )
        {
            Configuration = config;
        }
        
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();



            var key = Encoding.ASCII.GetBytes(Jwttoken.Secret);

            services.AddAuthentication
                (x =>
                 {
                     x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                     x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                 }
                ).AddJwtBearer(x =>
                  {
                      x.RequireHttpsMetadata = false;
                      x.SaveToken = true;
                      x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                      {
                          ValidateIssuerSigningKey = true,
                          IssuerSigningKey = new SymmetricSecurityKey(key),
                          ValidateIssuer = false,
                          ValidateAudience = false
                      };
                          
                  }); 



            services.AddDbContext<PaymentDataContext>(
                 options => options.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=BDPayment;Integrated Security=True")
                 );




            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",

                    new OpenApiInfo

                    {

                        Title = "Pagamento On_line - GerenciaNet",

                        Version = "v1",

                        Description = "Exemplo de API REST criada com o ASP.NET Core 3.0 para consulta Pagamento online",

                        Contact = new OpenApiContact

                        {

                            Name = "Junior Santana",

                            Url = new Uri("https://github.com/renatogroffe")

                        }

                    });
            });

            services.AddMvc(option => option.EnableEndpointRouting = false).
                            SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
                            

            services.AddDomain();
            services.AddInfra();
            services.AddApplication();
            
        
        } 

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(
                x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                );

            app.UseAuthorization();
            app.UseAuthorization();

            app.UseMvc();
            app.UseSwagger();

            app.UseSwaggerUI(c=> {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment V1"); 
                           });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        
        }
    }
}
