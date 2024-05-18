using SensitiveEats.Domain;
using SensitiveEats.Validation;

namespace SensitiveEats.Service
{
    public interface ISensitiveIngredientsService
    {
        public Task<GeneralResponse<List<SensitiveIngredientResponseModel>>> GetAllSensitiveIngredient(int userId);

        public Task<GeneralResponse<SensitiveIngredientResponseModel>> AddSensitiveIngredients(int userId, SensitiveIngredientRequestModel model);
        public Task<GeneralResponse<SensitiveIngredientResponseModel>> DeleteSensitiveIngredients(int userId, int sensitiveIngredientId);
    }
    public class SensitiveIngredientsService : ISensitiveIngredientsService
    {
        private readonly ISensitiveIngredientsValidation _sensitiveIngredients;

        public SensitiveIngredientsService(ISensitiveIngredientsValidation sensitiveIngredients)
        {
            _sensitiveIngredients = sensitiveIngredients;
        }

        public async Task<GeneralResponse<List<SensitiveIngredientResponseModel>>> GetAllSensitiveIngredient(int userId)
        {
            return await _sensitiveIngredients.GetAllSensitiveIngredient(userId);
        }
        public async Task<GeneralResponse<SensitiveIngredientResponseModel>> AddSensitiveIngredients(int userId, SensitiveIngredientRequestModel model)
        {
            return await _sensitiveIngredients.AddSensitiveIngredients(userId, model);
        }

        public async Task<GeneralResponse<SensitiveIngredientResponseModel>> DeleteSensitiveIngredients(int userId, int sensitiveIngredientId)
        {
            return await _sensitiveIngredients.DeleteSensitiveIngredients(userId, sensitiveIngredientId);
        }

    }
}
