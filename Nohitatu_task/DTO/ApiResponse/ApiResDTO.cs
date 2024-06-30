namespace Nohitatu_task.DTO.Output
{
    public class ApiResDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        // Constructor to set Success and Message
        public ApiResDTO(bool success = true, string message = null)
        {
            Success = success;
            Message = message;
            Data = null; // Default data is null
        }

        // Constructor to set Data
        public ApiResDTO(object data)
        {
            Success = true; // Success is true by default when data is provided
            Message = null; // Message is null by default when data is provided
            Data = data;
        }
    }
}
