using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Domain;

namespace Application.Services;

public interface OrderService
{
    void Order(CreateOrderDto dto);
    IEnumerable<Order> ListAll();
    IEnumerable<Order> GetOrderCards();
    PaginatedResponseDTO<Order> GetOrders(PaginatedRequestDTO pagination);
}