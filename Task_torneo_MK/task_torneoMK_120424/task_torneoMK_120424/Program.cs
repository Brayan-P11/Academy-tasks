
using Microsoft.EntityFrameworkCore;
using task_torneoMK_120424.Models;
using task_torneoMK_120424.Repos;
using task_torneoMK_120424.Services;

namespace task_torneoMK_120424
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Importanti per la configurazione di Context e Repository
            builder.Services.AddDbContext<TorneoContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));

            builder.Services.AddScoped<IRepo<Utente>, UtenteRepo>();
            builder.Services.AddScoped<UtenteService>();

            builder.Services.AddScoped<IRepo<Squadra>, SquadraRepo>();
            builder.Services.AddScoped<SquadraService>();

            builder.Services.AddScoped<IRepo<Personaggio>, PersonaggioRepo>();
            builder.Services.AddScoped<PersonaggioService>();

            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
