namespace Task_Management_App_V2.DTO
{
    public class GeneralResponseInternalDTO
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }

        public GeneralResponseInternalDTO(bool status, string message)
        {
            this.Status = status;
            this.Message = message;
        }

        public GeneralResponseInternalDTO(bool status, string message, object data)
        {
            this.Status = status;
            this.Message = message;
            this.Data = data;
        }
    }
}
