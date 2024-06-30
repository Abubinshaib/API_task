using Nohitatu_task.DTO.Input;
using Nohitatu_task.DTO.Output;

namespace Nohitatu_task.Services
{
    public interface IUser
    {
        Task<ApiResDTO> SaveUser(ApiUserReqDTO reqdto);

        Task<ApiResDTO> UpdateUser(int id,ApiUserReqDTO reqdto);

        Task<ApiResDTO> GetAllUsers();

        Task<ApiResDTO> GetUserById(int id);

        Task<ApiResDTO> DeleteUser(int id);

    }
}
