using LojinhaServer.Models;
using MongoDB.Driver;
using LojinhaServer.Repositories;

namespace LojinhaServer.Extensions;

//static: podem ser usados estaciados, ou seja, mexer no sistema sem mexer no obj
public static class ServicesExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            // criar uma politica
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                //add os metodos
                        .AllowAnyMethod()
                // add qualquer cabeçario
                        .AllowAnyHeader()
            );
        });
    }
    
    // configuração de acesso do banco de dados
    public static void ConfigureMongoDBSettings(
     this IServiceCollection services, IConfiguration config)
    {
        services.Configure<MongoDBSettings>(
            config.GetSection("MongoDBSettings")
        );

        services.AddSingleton<IMongoDatabase>(options =>
        {
            var settings = config.GetSection("MongoDBSettings").Get<MongoDBSettings>();
            var client = new MongoClient(settings.ConnectionString);
            return client.GetDatabase(settings.DatabaseName);
        });
    }
    public static void ConfigureProductRepository(this IServiceCollection services)
    {
        services.AddSingleton<IProductRepository, ProductRepository>();
    }
}

// Cors  acessa os dados do mongo e utiliza para o api, 
// caso contrario ele bloqueia acesso