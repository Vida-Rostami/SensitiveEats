
using SensitiveEats.DataAccess;
using SensitiveEats.Repository;
using SensitiveEats.Service;
using SensitiveEats.Validation;

namespace SensitiveEats.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.UseUrls("http://*:5000");
            builder.Services.AddHealthChecks();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            IConfigurationBuilder Cbuilder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            IConfigurationRoot Configs = Cbuilder.Build();

            builder.Services.Configure<SensitiveEatsDbModel>(Configs.GetSection("ConnectionStrings"));
            builder.Services.AddSingleton<SensitiveEatsDbContext>();
            builder.Services.AddSingleton<IRecipeRepository, RecipeRepository>();
            builder.Services.AddSingleton<IRecipeValidation, RecipeValidation>();
            builder.Services.AddSingleton<IRecipeService, RecipeService>();
            builder.Services.AddSingleton<ISensitiveIngredientsRepository, SensitiveIngredientsRepository>();
            builder.Services.AddSingleton<ISensitiveIngredientsValidation, SensitiveIngredientsValidation>();
            builder.Services.AddSingleton<ISensitiveIngredientsService, SensitiveIngredientsService>();
            builder.Services.AddSingleton<IIngredientRepository, IngredientRepository>();
            builder.Services.AddSingleton<IIngredientService, IngredientService>();
            builder.Services.AddSingleton<IIngredientValidation, IngredientValidation>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.MapHealthChecks("/health");

            app.MapControllers();

            app.Run();
        }
    }
}
