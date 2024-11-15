using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Delete.Temporarily
{
    public class DeleteTemporarilyProductCommandHandler : IRequestHandler<DeleteTemporarilyProductCommandRequest, DeleteTemporarilyProductCommandResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        readonly IProductPropertyWriteRepository _productPropertyWriteRepository;
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        //readonly IProductCommentWriteRepository _productCommentWriteRepository;

        public DeleteTemporarilyProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IProductPropertyWriteRepository productPropertyWriteRepository, IProductImageFileWriteRepository productImageFileWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _productPropertyWriteRepository = productPropertyWriteRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;
        }

        public async Task<DeleteTemporarilyProductCommandResponse> Handle(DeleteTemporarilyProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = await _productReadRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, true);
            if (product == null) throw new ProductNotFoundException();
            foreach (var image in product.Images)
            {
                _productImageFileWriteRepository.DeleteTemporarily(image);
            }
            foreach (var property in product.Properties)
            {
                _productPropertyWriteRepository.DeleteTemporarily(property);
            }
            //foreach (var comment in product.Comments)
            //{
            //    _productCommentWriteRepository.DeleteTemporarily(comment);
            //}
            _productWriteRepository.DeleteTemporarily(product);
            await _productWriteRepository.SaveAsync();
            return new DeleteTemporarilyProductCommandResponse
            {
                Message = "Məhsul müvəqqəti silinmişdir!"
            };
        }
    }
}
