using Application.DTOs.Requests;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalArchitecture.Controllers;

[ApiController]
[Route("/api/order")]
public class OrderController(OrderService orderService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetOrders([FromQuery] PaginatedRequestDTO pagination)
    {
        return Ok(orderService.GetOrders(pagination));
    }

    [HttpGet("all")]
    public IActionResult GetOrders()
    {
        return Ok(orderService.ListAll());
    }

    [HttpPost]
    public IActionResult Order(CreateOrderDto dto)
    {
        orderService.Order(dto);
        return Created();
    }
}