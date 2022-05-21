using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Linq;
using TringleApi.Api.Data.Context;
using TringleApi.Api.Services.Account;
using TringleApi.Api.Services.Deposit;
using TringleApi.Api.Services.Payment;
using TringleApi.Api.Services.User;
using TringleApi.Api.Services.Withdraw;

namespace TringleApi.Api
{
    public class Startup
    {

        public IConfigurationRoot Configuration { get; }
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                             .SetBasePath(env.ContentRootPath)
                             .AddJsonFile("appsettings.json", reloadOnChange: true, optional: true)
                             .AddJsonFile($"appsettings.{env.EnvironmentName}.json", reloadOnChange: true, optional: true)
                             .AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("TringleApi"));

            //services.AddDbContext<DataContext>(options =>
            //{
            //    options.UseNpgsql(Configuration["ConnectionStrings:Conn"]);
            //});

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Swagger on ASP.Net Core",
                    Version = "1.0.0",
                    Description = "Backend API Projesi (Asp.Net Core 3.1)"
                });
                c.ResolveConflictingActions(x => x.First());

            });

            services.AddAutoMapper(typeof(Startup));
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });


            services.AddTransient<IDepositRepository, DepositRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IWithdrawRepository, WithdrawRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("../swagger/v1/swagger.json", "MY API V1");
                    c.RoutePrefix = "swagger";
                });
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
