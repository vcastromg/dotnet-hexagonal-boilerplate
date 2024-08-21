using Application.Repositories;
using AutoMapper;
using Domain;
using Infra.Adapters;

namespace Infra.RepositoriesImp;

public class OrderRepositoryImp(ApplicationDbContext applicationDbContext, IMapper mapper)
    : BaseRepositoryImp<Order>(applicationDbContext, mapper), OrderRepository;