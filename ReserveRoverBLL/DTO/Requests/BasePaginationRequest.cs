namespace ReserveRoverBLL.DTO.Requests;

public abstract class BasePaginationRequest
{
    public int PageNumber { get; set; }
    
    public int PageSize { get; set; }
}