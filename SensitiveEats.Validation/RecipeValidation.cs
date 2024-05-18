using SensitiveEats.Domain;
using SensitiveEats.Repository;

namespace SensitiveEats.Validation
{
    public interface IRecipeValidation
    {
        public Task<GeneralResponse<List<RecipeResponseModel>>> GetAllRecipe(int userId);
        public Task<GeneralResponse<RecipeResponseModel>> GetRecipe(int recipeId, int userId);
    }
    public class RecipeValidation : IRecipeValidation
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeValidation(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<GeneralResponse<List<RecipeResponseModel>>> GetAllRecipe(int userId)
        {
            if (userId == 0)
            {
                return new GeneralResponse<List<RecipeResponseModel>>
                {
                    IsSuccess = false,
                    Message = "لطفا ابتدا وارد حساب کاربری خود شوید."
                };
            }
            var allRecipes = await _recipeRepository.GetAllRecipe(userId);
            return new GeneralResponse<List<RecipeResponseModel>>
            {
                IsSuccess = true,
                Message = "",
                Data = allRecipes.Data.ToList()
            };
        }

        public async Task<GeneralResponse<RecipeResponseModel>> GetRecipe(int recipeId, int userId)
        {
            if (userId == 0)
            {
                return new GeneralResponse<RecipeResponseModel>
                {
                    IsSuccess = false,
                    Message = "لطفا ابتدا وارد حساب کاربری خود شوید."
                };
            }
            var recipe = await _recipeRepository.GetRecipe(recipeId, userId);
            return new GeneralResponse<RecipeResponseModel>
            {
                IsSuccess = true,
                Message = "Success",
                Data = new RecipeResponseModel
                {
                    RecipeId = recipe.Data.RecipeId,
                    RecipeTitle = recipe.Data.RecipeTitle,
                    RecipeDescription = recipe.Data.RecipeDescription
                }
            };
        }
    }
}