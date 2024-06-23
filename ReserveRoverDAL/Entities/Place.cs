using NpgsqlTypes;

namespace ReserveRoverDAL.Entities;

public class Place
{
    public int Id { get; set; }

    public string ManagerId { get; set; } = null!;

    public int CityId { get; set; }
    
    public string MainImageUrl { get; set; } = null!;

    public string Title { get; set; } = null!;

    public TimeOnly OpensAt { get; set; }

    public TimeOnly ClosesAt { get; set; }

    public decimal? AvgMark { get; set; }
    
    public int Popularity { get; set; }

    public decimal AvgBill { get; set; }

    public string Address { get; set; } = null!;
    
    public short ImagesCount { get; set; }
    
    public DateTime SubmissionDateTime { get; set; }

    public DateOnly? PublicDate { get; set; }

    public short ModerationStatus { get; set; }
    
    public NpgsqlTsVector SearchVector { get; set; }
    
    public virtual PlaceDescription PlaceDescription { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual Location? Location { get; set; }

    public virtual ICollection<Moderation> Moderations { get; } = new List<Moderation>();

    public virtual ICollection<PlaceImage> PlaceImages { get; } = new List<PlaceImage>();

    public virtual ICollection<PlacePaymentMethod> PlacePaymentMethods { get; } = new List<PlacePaymentMethod>();

    public virtual ICollection<Review> Reviews { get; } = new List<Review>();

    public virtual ICollection<TableSet> TableSets { get; } = new List<TableSet>();
}
