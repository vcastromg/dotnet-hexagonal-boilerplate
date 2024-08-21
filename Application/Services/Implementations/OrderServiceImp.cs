using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Repositories;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Implementations;

public class OrderServiceImp(
    OrderRepository orderRepository,
    UserManager<AppUser> userManager,
    MenuItemRepository menuItemRepository)
    : OrderService
{
    public void Order(CreateOrderDto dto)
    {
        var menuItems = menuItemRepository.GetMenuItemsByIds(dto.MenuItemIds);
        var currentUser = new AppUser(); // Get the current logged-in user
        var newOrder = new Order
        {
            Comment = dto.Comment,
            DeliveryAddress = dto.DeliveryAddress,
            PlacedAt = DateTime.Now,
            Items = menuItems,
            PlacedBy = currentUser
        };

        orderRepository.Add(newOrder);
        orderRepository.SaveChanges();
    }

    public IEnumerable<Order> ListAll()
    {
        return orderRepository.GetAll();
    }

    public IEnumerable<Order> GetOrderCards()
    {
        throw new NotImplementedException();
    }

    public PaginatedResponseDTO<Order> GetOrders(PaginatedRequestDTO pagination)
    {
        return orderRepository.Get(pagination);
    }
}