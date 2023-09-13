using School.Domain.Enums;

namespace School.Domain.Entities;
public class ResultResponse<T>
{
    public EStatusCode StatusCode { get; set; }
    public string? ErrorMessage { get; set; }
    public T? Data { get; set; }
}
