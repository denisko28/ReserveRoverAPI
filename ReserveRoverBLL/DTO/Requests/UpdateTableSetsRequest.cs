namespace ReserveRoverBLL.DTO.Requests;

public class UpdateTableSetsRequest
{
    public int PlaceId { get; set; }
    
    public IEnumerable<TableSetUpdateRequest> TableSets { get; set; }

    public class TableSetUpdateRequest
    {
        public int Id { get; set; }

        public short TableCapacity { get; set; }

        public short TablesNum { get; set; }
    }
}