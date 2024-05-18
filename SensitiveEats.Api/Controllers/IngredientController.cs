using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SensitiveEats.Domain;
using SensitiveEats.Service;

namespace SensitiveEats.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        [Route("GetAllIngredient")]
        public async Task<GeneralResponse<List<IngredientResponseModel>>> GetAllIngredient(int userId)
        {
            return await _ingredientService.GetAllIngredient(userId);
        }

        [HttpPost]
        [Route("AddIngredient")]
        public async Task<GeneralResponse<IngredientResponseModel>> AddIngredient(int userId, IngredientRequestModel model)
        {
            return await _ingredientService.AddIngredient(userId, model);
        }

        [HttpPut]
        [Route("UpdateIngredient")]
        public async Task<GeneralResponse<IngredientResponseModel>> UpdateIngredient(int userId, int ingredientId, IngredientRequestModel model)
        {
            return await _ingredientService.UpdateIngredient(userId, ingredientId, model);
        }

        [HttpDelete]
        [Route("DeleteIngredient")]
        public async Task<GeneralResponse<IngredientResponseModel>> DeleteIngredient(int userId, int IngredientId)
        {
            return await _ingredientService.DeleteIngredient(userId, IngredientId);
        }
    }
}
