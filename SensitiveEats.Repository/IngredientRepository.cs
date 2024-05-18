using Dapper;
using SensitiveEats.DataAccess;
using SensitiveEats.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SensitiveEats.Repository
{
    public interface IIngredientRepository
    {
        public Task<GeneralResponse<List<IngredientResponseModel>>> GetAllIngredient(int userId);
        public Task<GeneralResponse<IngredientResponseModel>> AddIngredient(int userId, IngredientRequestModel model);
        public Task<GeneralResponse<IngredientResponseModel>> UpdateIngredient(int userId, int ingredientId, IngredientRequestModel model);
        public Task<GeneralResponse<IngredientResponseModel>> DeleteIngredient(int userId, int IngredientId);

    }
    public class IngredientRepository : IIngredientRepository
    {
        private readonly SensitiveEatsDbContext _context;
        public IngredientRepository(SensitiveEatsDbContext context)
        {
            _context = context;
        }


        public async Task<GeneralResponse<List<IngredientResponseModel>>> GetAllIngredient(int userId)
        {
            string query = "get_all_ingredient";
            using (IDbConnection connection = _context.CreateConnection())
            {
                connection.Open();
                try
                {
                    DynamicParameters parameters = new DynamicParameters();
                    var allIngredients = await connection.QueryAsync<IngredientResponseModel>(sql: query, param: parameters, commandType: CommandType.StoredProcedure);
                    var ingredientList = allIngredients.ToList();
                    return new GeneralResponse<List<IngredientResponseModel>>
                    {
                        IsSuccess = true,
                        Message = "Success",
                        Data = ingredientList
                    };
                }
                catch (Exception ex)
                {
                    return null;
                }
                connection.Close();
            }
        }

        public async Task<GeneralResponse<IngredientResponseModel>> AddIngredient(int userId, IngredientRequestModel model)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                connection.Open();
                try
                {
                    string query = "add_ingredient";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@IngredientName", model.IngredientName, DbType.String);
                    var dbResponse = await connection.QueryFirstOrDefault(sql: query, param: parameters, commandType: CommandType.StoredProcedure);
                    var ingredient = new GeneralResponse<IngredientResponseModel>
                    {
                        IsSuccess = true,
                        Message = "success",
                        Data = dbResponse
                    };
                    return ingredient;

                }
                catch (Exception ex)
                {
                    return null;
                }

                connection.Close();
            }
        }

        public async Task<GeneralResponse<IngredientResponseModel>> UpdateIngredient(int userId, int ingredientId, IngredientRequestModel model)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                connection.Open();
                try
                {
                    string query = "update_ingredient";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@IngredientId", ingredientId, DbType.Int32);
                    parameters.Add("@IngredientName", model.IngredientName, DbType.String);
                    var updatedIngredient = await connection.QueryFirstOrDefaultAsync(sql: query, param: parameters, commandType: CommandType.StoredProcedure);
                    return updatedIngredient; 
                }
                catch (Exception ex)
                {
                    return null;
                }
                connection.Close();
            }

        }
        public async Task<GeneralResponse<IngredientResponseModel>> DeleteIngredient(int userId, int IngredientId)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                connection.Open();
                try
                {
                    string query = "delete_ingredient";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@IngredientId", IngredientId, DbType.Int32);
                    var deletedIngredient = await connection.QueryFirstOrDefaultAsync(sql: query, param: parameters, commandType: CommandType.StoredProcedure);
                    return deletedIngredient; 
                }
                catch (Exception ex)
                {
                    return null;
                }
                connection.Close();
            }
        }
    }
}
