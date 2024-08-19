using MediatR;
using WebApplication2.Domain;
using WebApplication2.Infrastructure.Persistence;

namespace WebApplication2.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<Unit>
    {
        public string Description { get; set; } = default!;
        public double Price { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly MyAppDbContext _context;

        public CreateProductCommandHandler(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = new Product
            {
                Description = request.Description,
                Price = request.Price
            };

            _context.Products.Add(newProduct);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }

}
