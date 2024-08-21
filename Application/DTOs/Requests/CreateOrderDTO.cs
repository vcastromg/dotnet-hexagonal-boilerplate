namespace Application.DTOs.Requests;

public class CreateOrderDto
{
    public string? Comment { get; set; }
    public string? DeliveryAddress { get; set; }
    public long[] MenuItemIds { get; set; }
}