namespace ReserveRoverBLL.DTO.Responses;

public class PlaceTimeOfferResponse : IEquatable<PlaceTimeOfferResponse>
{
    public int TableSetId { get; set; }
    
    public TimeOnly OfferedStartTime { get; set; }

    public TimeOnly OfferedEndTime { get; set; }
    
    public bool Equals(PlaceTimeOfferResponse? other)
    {
        if (other == null)
            return false;
        
        return OfferedStartTime == other.OfferedStartTime && OfferedEndTime == other.OfferedEndTime;
    }
    
    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + OfferedStartTime.GetHashCode();
            hash = hash * 23 + OfferedEndTime.GetHashCode();
            return hash;
        }
    }
}