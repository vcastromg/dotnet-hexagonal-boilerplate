namespace Domain;

public class MenuItem : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Unit { get; set; }
    public decimal Price { get; set; }

    public IEnumerable<Order> Orders { get; set; }
}