namespace ReserveRoverBLL.DTO.Requests;

public class SetPlaceTableSetsRequest
{
    public IEnumerable<TableSetRequest> TableSets { get; set; }
    
    public IEnumerable<int> IdsToDelete { get; set; }

    public class TableSetRequest
    {
        public int? Id { get; set; }
        
        public int PlaceId { get; set; }
        
        public short TableCapacity { get; set; }
        
        public short TablesNum { get; set; }
    }
}