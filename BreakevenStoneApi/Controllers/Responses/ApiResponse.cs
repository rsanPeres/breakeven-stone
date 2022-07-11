namespace BreakevenStoneApi.Controllers.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Messages { get; set; }

    }
}