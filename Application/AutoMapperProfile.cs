using Application.DTOs;
using AutoMapper;
using Domain;

namespace Application;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Order, OrderCardPreviewDTO>();
    }
}