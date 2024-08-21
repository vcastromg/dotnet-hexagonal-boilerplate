namespace Domain;

public class Review : BaseEntity
{
    public ushort Rate { get; set; }
    public string Comments { get; set; }

    public Order Order { get; set; }
}