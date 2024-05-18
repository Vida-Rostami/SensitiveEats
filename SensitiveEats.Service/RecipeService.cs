using SensitiveEats.Domain;
using SensitiveEats.Validation;

namespace SensitiveEats.Service
{
    public interface IRecipeService
    {
        public Task<GeneralResponse<List<RecipeResponseModel>>> GetAllRecipe(int userId);
        public Task<GeneralResponse<RecipeResponseModel>> GetRecipe(int recipeId, int userId);
    }
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeValidation _recipeValidation;

        public RecipeService(IRecipeValidation recipeValidation)
        {
            _recipeValidation = recipeValidation;
        }

        public async Task<GeneralResponse<List<RecipeResponseModel>>> GetAllRecipe(int userId)
        {
            return await _recipeValidation.GetAllRecipe(userId);
        }

        public async Task<GeneralResponse<RecipeResponseModel>> GetRecipe(int recipeId, int userId)
        {
            return await _recipeValidation.GetRecipe(recipeId, userId);
        }
    }
}
