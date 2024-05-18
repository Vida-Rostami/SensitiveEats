using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SensitiveEats.Domain;
using SensitiveEats.Service;

namespace SensitiveEats.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        [Route("GetAllRecipe")]
        public async Task<GeneralResponse<List<RecipeResponseModel>>> GetAllRecipe(int userId)
        {
            return await _recipeService.GetAllRecipe(userId);
        }

        [HttpGet]
        [Route("GetRecipe")]
        public async Task<GeneralResponse<RecipeResponseModel>> GetRecipe(int recipeId, int userId)
        {
            return await _recipeService.GetRecipe(recipeId, userId);
        }
    }
}
