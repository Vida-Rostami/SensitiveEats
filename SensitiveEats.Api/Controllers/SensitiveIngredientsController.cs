using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SensitiveEats.Domain;
using SensitiveEats.Service;

namespace SensitiveEats.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensitiveIngredientsController : ControllerBase
    {
        private readonly ISensitiveIngredientsService _sensitiveIngredientsService;

        public SensitiveIngredientsController(ISensitiveIngredientsService sensitiveIngredientsService)
        {
            _sensitiveIngredientsService = sensitiveIngredientsService;
        }
        [HttpGet]
        [Route("GetAllSensitiveIngredient")]
        public async Task<GeneralResponse<List<SensitiveIngredientResponseModel>>> GetAllSensitiveIngredient(int userId)
        {
            return await _sensitiveIngredientsService.GetAllSensitiveIngredient(userId);
        }


        [HttpPost]
        [Route("AddSensitiveIngredients")]
        public async Task<GeneralResponse<SensitiveIngredientResponseModel>> AddSensitiveIngredients(int userId, SensitiveIngredientRequestModel model)
        {
            return await _sensitiveIngredientsService.AddSensitiveIngredients(userId, model);
        }

        [HttpDelete]
        [Route("DeleteSensitiveIngredients")]
        public async Task<GeneralResponse<SensitiveIngredientResponseModel>> DeleteSensitiveIngredients(int userId, int sensitiveIngredientId)
        {
            return await _sensitiveIngredientsService.DeleteSensitiveIngredients(userId, sensitiveIngredientId);
        }
    }
}
