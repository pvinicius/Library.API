using System;
namespace Library.Domain.DTO
{
    public class Response<TEntity>
    {
        public Response()
        {

        }

        public bool Success { get; set; }
        public string Messsage { get; set; }
        public object Data { get; set; }
    }
}
