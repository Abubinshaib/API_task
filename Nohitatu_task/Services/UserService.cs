using Microsoft.OpenApi.Validations;
using Nohitatu_task.DTO.Input;
using Nohitatu_task.DTO.Output;
using Nohitatu_task.Validator;
using System.Data;
using System.Data.SqlClient;

namespace Nohitatu_task.Services
{
    public class UserService : IUser
    {

        private readonly string _connectionString;

        public UserService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<ApiResDTO> DeleteUser(int id)
        {
            string ValidationMessage;
            SqlConnection conn = null; // Declare SqlConnection variable outside of using block

            try
            {

                    conn = new SqlConnection(_connectionString);
                    SqlCommand cmd = new SqlCommand(ApiUserReqDTO.DeleteUserByIdQuery(id), conn)
                    {
                        CommandType = CommandType.Text
                    };

                    await conn.OpenAsync();

                    // ExecuteNonQueryAsync returns an integer representing the number of rows affected
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();

                    return new ApiResDTO(true, $"{rowsAffected} user(s) deleted successfully.");
                
            }
            catch (Exception ex)
            {
                return new ApiResDTO(false, $"Error Deleting user: {ex.Message}");
            }
            finally
            {
                // Ensure connection is closed in all cases
                conn?.Close();
            }
        }


        public async Task<ApiResDTO> GetAllUsers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(ApiUserReqDTO.GetAllUsersQuery(), conn)
                    {
                        CommandType = CommandType.Text
                    };

                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        List<ApiUserReqDTO> users = new List<ApiUserReqDTO>();

                        while (await reader.ReadAsync())
                        {
                            ApiUserReqDTO user = new ApiUserReqDTO
                            {
                                Name = reader.GetString(0),
                                PhoneNumber = reader.GetString(1),
                                EmailID = reader.GetString(2),
                                Gender = reader.GetString(3)
                            };

                            users.Add(user);
                        }

                        return new ApiResDTO(users);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ApiResDTO(false, $"Error retrieving users: {ex.Message}");
            }
        }



        public async Task<ApiResDTO> GetUserById(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(ApiUserReqDTO.GetUserByIdQuery(id), conn)
                    {
                        CommandType = CommandType.Text
                    };

                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        ApiUserReqDTO user = new ApiUserReqDTO();

                        while (await reader.ReadAsync())
                        {
                            user = new ApiUserReqDTO
                            {
                                Name = reader.GetString(0),
                                PhoneNumber = reader.GetString(1),
                                EmailID = reader.GetString(2),
                                Gender = reader.GetString(3)
                            };


                        }

                        return new ApiResDTO(user);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ApiResDTO(false, $"Error retrieving users: {ex.Message}");
            }
        }

        public async Task<ApiResDTO> SaveUser(ApiUserReqDTO reqdto)
        {
            string ValidationMessage;
            SqlConnection conn = null; // Declare SqlConnection variable outside of using block

            try
            {
                ValidationMessage = ApiValidation.UserValidator(reqdto);
                if (ValidationMessage == null)
                {
                    conn = new SqlConnection(_connectionString);
                    SqlCommand cmd = new SqlCommand(reqdto.InsertQuery(), conn)
                    {
                        CommandType = CommandType.Text
                    };

                    await conn.OpenAsync();

                    // ExecuteNonQueryAsync returns an integer representing the number of rows affected
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();

                     return new ApiResDTO(true, $"{rowsAffected} user(s) created successfully.");
                }

                    return new ApiResDTO(false, ValidationMessage);
            }
            catch (Exception ex)
            {
                    return new ApiResDTO(false, $"Error saving user: {ex.Message}");
            }
            finally
            {
                // Ensure connection is closed in all cases
                conn?.Close();
            }
        }


        public async Task<ApiResDTO> UpdateUser(int id, ApiUserReqDTO reqdto)
        {
            string ValidationMessage;
            SqlConnection conn = null; // Declare SqlConnection variable outside of using block

            try
            {
                ValidationMessage = ApiValidation.UserValidator(reqdto);
                if (ValidationMessage == null)
                {
                    conn = new SqlConnection(_connectionString);
                    SqlCommand cmd = new SqlCommand(reqdto.UpdateUserByIdQuery(id), conn)
                    {
                        CommandType = CommandType.Text
                    };

                    await conn.OpenAsync();

                    // ExecuteNonQueryAsync returns an integer representing the number of rows affected
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();

                    return new ApiResDTO(true, $"{rowsAffected} user(s) updated successfully.");
                }

                return new ApiResDTO(false, ValidationMessage);
            }
            catch (Exception ex)
            {
                return new ApiResDTO(false, $"Error updating user: {ex.Message}");
            }
            finally
            {
                // Ensure connection is closed in all cases
                conn?.Close();
            }
        }
    }
}
