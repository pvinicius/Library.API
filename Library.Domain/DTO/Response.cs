namespace Library.Domain.DTO
{
    public class Response<TEntity>
    {
        public Response()
        {

        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
