namespace ReserveRoverBLL.DTO.Requests;

public class AddPlaceTableSetsRequest
{
    public int PlaceId { get; set; }
    
    public IEnumerable<TableSetRequest> TableSets { get; set; }

    public class TableSetRequest
    {
        public short TableCapacity { get; set; }
        
        public short TablesNum { get; set; }
    }
}