using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Features.Commands.Products.Delete.Temporarily;
using KovserHedieyyeler.Application.Repositories.Abstractions.Products;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Delete.Permanently.RemoveProducts
{
    public class RemovePermanentlyProductCommandHandler : IRequestHandler<RemovePermanentlyProductCommandRequest, RemovePermanentlyProductCommandResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        readonly IProductPropertyWriteRepository _productPropertyWriteRepository;
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        readonly IProductCommentWriteRepository _productCommentWriteRepository;

        public RemovePermanentlyProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IProductPropertyWriteRepository productPropertyWriteRepository, IProductImageFileWriteRepository productImageFileWriteRepository, IProductCommentWriteRepository productCommentWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _productPropertyWriteRepository = productPropertyWriteRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _productCommentWriteRepository = productCommentWriteRepository;
        }

        public async Task<RemovePermanentlyProductCommandResponse> Handle(RemovePermanentlyProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = await _productReadRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, true);
            if (product == null) throw new ProductNotFoundException();
            foreach (var image in product.Images)
            {
                _productImageFileWriteRepository.RemovePermanently(image);
            }
            foreach (var property in product.Properties)
            {
                _productPropertyWriteRepository.RemovePermanently(property);
            }
            foreach (var comment in product.Comments)
            {
                _productCommentWriteRepository.RemovePermanently(comment);
            }
            _productWriteRepository.RemovePermanently(product);
            await _productWriteRepository.SaveAsync();
            return new RemovePermanentlyProductCommandResponse
            {
                Message = "Məhsul uğurla silinmişdir!"
            };
        }
    }
}
