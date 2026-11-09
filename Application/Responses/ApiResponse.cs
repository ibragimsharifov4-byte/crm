using System.Net;

namespace Application.Responses;

public class ApiResponse<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; } = null!;
    public T? Data { get; set; }

    public ApiResponse(HttpStatusCode code , string message , T data)
    {
        StatusCode = code;
        Message = message;
        Data = data;
    }
}
