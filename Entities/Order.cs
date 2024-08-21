namespace Domain;

public class Order : BaseEntity
{
    public DateTime PlacedAt { get; set; }
    public DateTime CheckOut { get; set; }
    public string? Comment { get; set; }
    public string? DeliveryAddress { get; set; }

    public IEnumerable<MenuItem> Items { get; set; }
    public AppUser PlacedBy { get; set; }
}