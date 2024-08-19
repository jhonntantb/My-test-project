using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Infrastructure.Persistence;

namespace WebApplication2.Features.Products.Queries
{
    public class GetProductsQuery : IRequest<List<GetProductsQueryResponse>>
    {
    }

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<GetProductsQueryResponse>>
    {
        private readonly MyAppDbContext _context;
        public GetProductsQueryHandler(MyAppDbContext context)
        {
            _context = context;
        }

        public Task<List<GetProductsQueryResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken) 
        {
            return _context.Products
                .AsNoTracking()
                .Select(x => new GetProductsQueryResponse
                {
                    ProductId = x.ProductId,
                    Description = x.Description,
                    Price = x.Price,
                })
                .ToListAsync();
        }
    }
    public class GetProductsQueryResponse
    {
        public int ProductId { get; set; }
        public string Description { get; set; } = default!;
        public double Price { get; set; }
    }
}
