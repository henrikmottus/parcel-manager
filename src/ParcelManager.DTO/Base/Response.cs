using ParcelManager.DTO.Enums;

namespace ParcelManager.DTO.Base
{
    public class Response<T>
    {
        public ResponseStatuses Status { get; set; }
        public string Message { get; set; } = "";
        public T Data { get; set; } = default!;
    }
}