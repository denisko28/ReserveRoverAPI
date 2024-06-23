namespace ReserveRoverDAL.Entities;

public class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Place> Places { get; } = new List<Place>();
}
