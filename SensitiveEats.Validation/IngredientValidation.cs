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
    public interface IIngredientValidation
    {
        public Task<GeneralResponse<List<IngredientResponseModel>>> GetAllIngredient(int userId);
        public Task<GeneralResponse<IngredientResponseModel>> AddIngredient(int userId, IngredientRequestModel model);
        public Task<GeneralResponse<IngredientResponseModel>> UpdateIngredient(int userId, int ingredientId , IngredientRequestModel model);
        public Task<GeneralResponse<IngredientResponseModel>> DeleteIngredient(int userId, int IngredientId);
    }
    public class IngredientValidation : IIngredientValidation
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientValidation(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }
        public async Task<GeneralResponse<List<IngredientResponseModel>>>  GetAllIngredient(int userId)
        {
            if(userId == 0)
            {
                return new GeneralResponse<List<IngredientResponseModel>>
                {
                    IsSuccess = false,
                    Message = "لطفا ابتدا وارد حساب کاربری خود شوید."
                
                };
            }
            var allIngredient = await _ingredientRepository.GetAllIngredient(userId);
            return new GeneralResponse<List<IngredientResponseModel>>
            {
                IsSuccess = true,
                Message = "Success",
                Data = allIngredient.Data.ToList()
            };
        }
        public async Task<GeneralResponse<IngredientResponseModel>> AddIngredient(int userId, IngredientRequestModel model)
        {
            if (userId == 0)
            {
                return new GeneralResponse<IngredientResponseModel>
                {
                    IsSuccess = false,
                    Message = "لطفا ابتدا وارد حساب کاربری خود شوید."

                };
            }
            var ingredient = await _ingredientRepository.AddIngredient(userId, model);
            return new GeneralResponse<IngredientResponseModel>
            {
                IsSuccess = true,
                Message = "ماده غذایی با موفقیت اضافه گردید.",
                Data = ingredient.Data
            };
        }
        public async Task<GeneralResponse<IngredientResponseModel>> UpdateIngredient(int userId, int ingredientId, IngredientRequestModel model)
        {
            if (userId == 0)
            {
                return new GeneralResponse<IngredientResponseModel>
                {
                    IsSuccess = false,
                    Message = "لطفا ابتدا وارد حساب کاربری خود شوید."
                };
            }
            var ingredient = await _ingredientRepository.UpdateIngredient(userId,ingredientId, model);
            return new GeneralResponse<IngredientResponseModel>
            {
                IsSuccess = true,
                Message = "ماده غاذیی با موفقیت به روزرسانی گردید.",
                Data = ingredient.Data
            };
        }
        public async Task<GeneralResponse<IngredientResponseModel>> DeleteIngredient(int userId, int IngredientId)
        {
            if (userId == 0)
            {
                return new GeneralResponse<IngredientResponseModel>
                {
                    IsSuccess = false,
                    Message = "لطفا ابتدا وارد حساب کاربری خود شوید."

                };
            }
            var ingredient = await _ingredientRepository.DeleteIngredient(userId, IngredientId);
            return new GeneralResponse<IngredientResponseModel>
            {
                IsSuccess = true,
                Message = "ماده غذایی با موفقیت حذف گردید.",
                Data = ingredient.Data
            };
        }


    }
}
