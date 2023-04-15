namespace ReserveRoverBLL.DTO.Requests;

public abstract class BasePaginationRequest
{
    public int pageNumber { get; set; }
    public int pageSize { get; set; }
}