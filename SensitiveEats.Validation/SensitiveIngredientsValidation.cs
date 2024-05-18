using SensitiveEats.Domain;
using SensitiveEats.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SensitiveEats.Validation
{
    public interface ISensitiveIngredientsValidation
    {
        public Task<GeneralResponse<List<SensitiveIngredientResponseModel>>> GetAllSensitiveIngredient(int userId);
        public Task<GeneralResponse<SensitiveIngredientResponseModel>> AddSensitiveIngredients(int userId, SensitiveIngredientRequestModel model);
        public Task<GeneralResponse<SensitiveIngredientResponseModel>> DeleteSensitiveIngredients(int userId, int sensitiveIngredientId);
    }
    public class SensitiveIngredientsValidation : ISensitiveIngredientsValidation
    {
        private readonly ISensitiveIngredientsRepository _sensitiveIngredientsRepository;

        public SensitiveIngredientsValidation(ISensitiveIngredientsRepository sensitiveIngredientsRepository)
        {
            _sensitiveIngredientsRepository = sensitiveIngredientsRepository;
        }

        public async Task<GeneralResponse<List<SensitiveIngredientResponseModel>>> GetAllSensitiveIngredient(int userId)
        {
            if (userId == 0)
            {
                return new GeneralResponse<List<SensitiveIngredientResponseModel>>
                {
                    IsSuccess = false,
                    Message = "لطفا ابتدا وارد حساب کاربری خود شوید."
                };
            }
            var allSensitiveIngredients = await _sensitiveIngredientsRepository.GetAllSensitiveIngredient(userId);
            return new GeneralResponse<List<SensitiveIngredientResponseModel>>
            {
                IsSuccess = true,
                Message = "ماده غذایی موردد نظر به لیست حساسیت‌زاها افزوده شد.",
                Data = allSensitiveIngredients.Data.ToList()
            };

        }
        public async Task<GeneralResponse<SensitiveIngredientResponseModel>> AddSensitiveIngredients(int userId, SensitiveIngredientRequestModel model)
        {
            if (userId == 0)
            {
                return new GeneralResponse<SensitiveIngredientResponseModel>
                {
                    IsSuccess = false,
                    Message = "لطفا ابتدا وارد حساب کاربری خود شوید."
                };
            }
            var sensitiveIngredients = await _sensitiveIngredientsRepository.AddSensitiveIngredients(userId, model);
            return new GeneralResponse<SensitiveIngredientResponseModel>
            {
                IsSuccess = true,
                Message = "ماده غذایی موردد نظر به لیست حساسیت‌زاها افزوده شد.",
                Data = new SensitiveIngredientResponseModel
                {
                    SensitiveIngredientId = sensitiveIngredients.Data.SensitiveIngredientId,
                    SensitiveIngredientName = sensitiveIngredients.Data.SensitiveIngredientName
                }
            };
        }

        public async Task<GeneralResponse<SensitiveIngredientResponseModel>> DeleteSensitiveIngredients(int userId, int sensitiveIngredientId)
        {
            if (userId == 0)
            {
                return new GeneralResponse<SensitiveIngredientResponseModel>
                {
                    IsSuccess = false,
                    Message = "لطفا ابتدا وارد حساب کاربری خود شوید."
                };
            }
            var sensitiveIngredients = await _sensitiveIngredientsRepository.DeleteSensitiveIngredients(userId, sensitiveIngredientId);
            return new GeneralResponse<SensitiveIngredientResponseModel>
            { 
                IsSuccess = true, 
                Message = "ماده غذایی مورد نظر از لیست حساسیت‌زاها حذف گردید.",
                Data = new SensitiveIngredientResponseModel
                {
                    SensitiveIngredientId = sensitiveIngredients.Data.SensitiveIngredientId,
                    SensitiveIngredientName = sensitiveIngredients.Data.SensitiveIngredientName
                }
                 
            };

        }

    }
}
