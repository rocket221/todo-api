using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TodoList.Repository;
using TodoList.Services;
using TodoList.Validators;

namespace TodoList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "ASP.NET Core Web API for ToDo items management",
                });
            });

            builder.Services.ConfigureOptions<JwtOptionsSetup>();
            builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();
            builder.Services.AddDbContext<TodoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TodoDatabase")));

            builder.Services.AddTransient<IJwtProvider, JwtProvider>();

            builder.Services.RegisterServices();
            builder.Services.RegisterValidators();
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.UseMiddleware<ExceptionMiddleware>();


            app.Run();
        }
    }
}