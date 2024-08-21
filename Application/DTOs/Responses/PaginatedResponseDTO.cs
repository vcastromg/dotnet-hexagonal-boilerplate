namespace Application.DTOs.Responses;

public class PaginatedResponseDTO<T>
{
    public int TotalCount { get; set; }
    public IEnumerable<T> Items { get; set; } = [];
}