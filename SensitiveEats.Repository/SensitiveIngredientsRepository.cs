using Dapper;
using SensitiveEats.DataAccess;
using SensitiveEats.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensitiveEats.Repository
{
    public interface ISensitiveIngredientsRepository
    {
        public Task<GeneralResponse<List<SensitiveIngredientResponseModel>>> GetAllSensitiveIngredient(int userId);
        public Task<GeneralResponse<SensitiveIngredientResponseModel>> AddSensitiveIngredients(int userId, SensitiveIngredientRequestModel model);
        public Task<GeneralResponse<SensitiveIngredientResponseModel>> DeleteSensitiveIngredients(int userId, int sensitiveIngredientId);
    }
    public class SensitiveIngredientsRepository : ISensitiveIngredientsRepository
    {
        private readonly SensitiveEatsDbContext _context;

        public SensitiveIngredientsRepository(SensitiveEatsDbContext context)
        {
           _context = context;
        }

        public async Task<GeneralResponse<List<SensitiveIngredientResponseModel>>> GetAllSensitiveIngredient(int userId)
        {
            string query = "get_all_sensitive_ingredient";
            using (IDbConnection connection = _context.CreateConnection())
            {
                connection.Open();
                try
                {
                    DynamicParameters parameters = new DynamicParameters();
                    var allSensitiveIngredients = await connection.QueryAsync<SensitiveIngredientResponseModel>(sql: query, param: parameters, commandType: CommandType.StoredProcedure);
                    var sensitiveIngredientList = allSensitiveIngredients.ToList();
                    return new GeneralResponse<List<SensitiveIngredientResponseModel>>
                    {
                        IsSuccess = true,
                        Message = "Success",
                        Data = sensitiveIngredientList
                    };
                }
                catch (Exception ex)
                {
                    return null;
                }
                connection.Close();
            }
        }
        public async Task<GeneralResponse<SensitiveIngredientResponseModel>> AddSensitiveIngredients(int userId, SensitiveIngredientRequestModel model)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                connection.Open();
                try
                {
                    string query = "add_sensitive_ingredient";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@userId", userId, DbType.Int32);
                    parameters.Add("@SensitiveIngredientId", userId, DbType.Int32);
                    parameters.Add("@SensitiveIngredientName", userId, DbType.String);
                    var dbResponse = await connection.QueryFirstOrDefault(sql: query, param: parameters, commandType: CommandType.StoredProcedure);
                    var sensitiveIngredient = new GeneralResponse<SensitiveIngredientResponseModel>
                    {
                        IsSuccess = true,
                        Message = "success",
                        Data = dbResponse
                    };
                    return sensitiveIngredient;

                }
                catch (Exception ex)
                {
                    return null;
                }

                connection.Close();
            }
        }

        public async Task<GeneralResponse<SensitiveIngredientResponseModel>> DeleteSensitiveIngredients(int userId, int sensitiveIngredientId)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                connection.Open();
                try
                {
                    string query = "delete_sensitive_ingredient";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@SensitiveIngredientId", sensitiveIngredientId, DbType.Int32);
                    parameters.Add("@userId", userId, DbType.Int32);
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
