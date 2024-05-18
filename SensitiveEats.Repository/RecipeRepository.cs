using Dapper;
using SensitiveEats.DataAccess;
using SensitiveEats.Domain;
using System.Collections.Generic;
using System.Data;

namespace SensitiveEats.Repository
{
    public interface IRecipeRepository
    {
        public Task<GeneralResponse<List<RecipeResponseModel>>> GetAllRecipe(int userId);
        public Task<GeneralResponse<RecipeResponseModel>> GetRecipe(int recipeId, int userId);
        // public Task<GeneralResponse<RecipeResponseModel>> AddRecipe(int recipeId, int userId);
        // public Task<GeneralResponse<RecipeResponseModel>> DeleteRecipe(int recipeId, int userId);
    }
    public class RecipeRepository : IRecipeRepository
    {
        private readonly SensitiveEatsDbContext _context;

        public RecipeRepository(SensitiveEatsDbContext context)
        {
            _context = context;
        }

        public async Task<GeneralResponse<List<RecipeResponseModel>>> GetAllRecipe(int userId)
        {

            string query = "get_recipe_for_user";
            using (IDbConnection connection = _context.CreateConnection())
            {
                connection.Open();
                try
                {
                    DynamicParameters parameters = new DynamicParameters();
                    var allRecipe = await connection.QueryAsync<RecipeResponseModel>(sql: query, param: parameters, commandType: CommandType.StoredProcedure);

                    return new GeneralResponse<List<RecipeResponseModel>>
                    {
                        IsSuccess = true,
                        Message = "Success",
                        Data = allRecipe.ToList()
                    };
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

        }
        public async Task<GeneralResponse<RecipeResponseModel>> GetRecipe(int recipeId, int userId)
        {
            string query = "get_recipe_for_user";
            using (IDbConnection connection = _context.CreateConnection())
            {
                connection.Open();
               // var recipe = new GeneralResponse<RecipeResponseModel>();

                try
                {
                    DynamicParameters parameters = new DynamicParameters();
                    var recipe =  connection.QueryFirstOrDefault<GeneralResponse<RecipeResponseModel>>(sql: query, param: parameters, commandType: CommandType.StoredProcedure);
                    return recipe;
                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }
    }



}