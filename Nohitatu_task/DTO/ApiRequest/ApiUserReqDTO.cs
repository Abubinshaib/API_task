using System.Runtime.CompilerServices;

namespace Nohitatu_task.DTO.Input
{
    public class ApiUserReqDTO
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailID { get; set; }

        public string Gender { get; set; }

        internal string InsertQuery()
        {
            string query = $"Insert into User_Details(FullName,PhoneNumber,Email,Gender) Values('{this.Name}','{this.PhoneNumber}','{this.EmailID}','{this.Gender}');";
            return query;
        }

        internal static string GetAllUsersQuery()
        {
            string query = "Select FullName, PhoneNumber, Email, Gender  From User_Details;";
            return query;
        }

        internal static string GetUserByIdQuery(int id)
        {
            string query = $"Select FullName, PhoneNumber, Email, Gender  From User_Details Where Id = {id};";
            return query;
        }

        internal static string DeleteUserByIdQuery(int id)
        {
            string query = $"Delete From User_Details Where Id = {id};";
            return query;
        }

        internal string UpdateUserByIdQuery(int id)
        {
            string query = $"Update User_Details Set FullName = '{this.Name}',PhoneNumber='{this.PhoneNumber}',Email='{this.EmailID}',Gender='{this.Gender}'  Where Id = {id};";
            return query;
        }

    }
}
