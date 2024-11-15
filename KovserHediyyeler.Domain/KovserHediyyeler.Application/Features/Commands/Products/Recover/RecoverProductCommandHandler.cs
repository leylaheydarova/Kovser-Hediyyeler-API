using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Recover
{
    public class RecoverProductCommandHandler : IRequestHandler<RecoverProductCommandRequest, RecoverProductCommandResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        readonly IProductPropertyWriteRepository _productPropertyWriteRepository;
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        // readonly IProductCommentWriteRepository _productCommentWriteRepository;

        public RecoverProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IProductPropertyWriteRepository productPropertyWriteRepository, IProductImageFileWriteRepository productImageFileWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _productPropertyWriteRepository = productPropertyWriteRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;

        }

        public async Task<RecoverProductCommandResponse> Handle(RecoverProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = await _productReadRepository.GetWhereAsync(x => x.isDeleted && x.ID.ToString() == request.Id, true);
            if (product == null) throw new ProductNotFoundException();
            foreach (var image in product.Images)
            {
                _productImageFileWriteRepository.RecoverData(image);
            }
            foreach (var property in product.Properties)
            {
                _productPropertyWriteRepository.RecoverData(property);
            }
            //foreach (var comment in product.Comments)
            //{
            //    _productCommentWriteRepository.RecoverData(comment);
            //}
            _productWriteRepository.RecoverData(product);
            await _productWriteRepository.SaveAsync();
            return new RecoverProductCommandResponse
            {
                Message = "Məhsul məlumatları uğurla bərpa edilmişdir!"
            };
        }
    }
}
