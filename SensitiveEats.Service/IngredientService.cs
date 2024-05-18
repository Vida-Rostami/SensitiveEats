using SensitiveEats.Domain;
using SensitiveEats.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensitiveEats.Service
{
    public interface IIngredientService
    {
        public Task<GeneralResponse<List<IngredientResponseModel>>> GetAllIngredient(int userId);
        public Task<GeneralResponse<IngredientResponseModel>> AddIngredient(int userId, IngredientRequestModel model);
        public Task<GeneralResponse<IngredientResponseModel>> UpdateIngredient(int userId, int ingredientId, IngredientRequestModel model);
        public Task<GeneralResponse<IngredientResponseModel>> DeleteIngredient(int userId, int IngredientId);
    }
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientValidation _ingredientValidation;

        public IngredientService(IIngredientValidation ingredientValidation)
        {
           _ingredientValidation = ingredientValidation;
        }

        public async Task<GeneralResponse<IngredientResponseModel>> AddIngredient(int userId, IngredientRequestModel model)
        {         
           return await _ingredientValidation.AddIngredient(userId, model);
        }
        public async Task<GeneralResponse<IngredientResponseModel>> DeleteIngredient(int userId, int IngredientId)
        {
            return await _ingredientValidation.DeleteIngredient(userId, IngredientId);
        }   
        public async Task<GeneralResponse<List<IngredientResponseModel>>> GetAllIngredient(int userId)
        {
            return await _ingredientValidation.GetAllIngredient(userId);
        }
        public async Task<GeneralResponse<IngredientResponseModel>> UpdateIngredient(int userId, int ingredientId, IngredientRequestModel model)
        {
            return await _ingredientValidation.UpdateIngredient(userId, ingredientId, model);
        }
    }
}
