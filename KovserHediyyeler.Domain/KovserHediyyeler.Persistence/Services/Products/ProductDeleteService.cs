using KovserHediyyeler.Application.Abstractions.Products;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;

namespace KovserHediyyeler.Persistence.Services.Products
{
    public class ProductDeleteService : IProductDeleteService
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        readonly IProductImageFileReadRepository _productImageFileReadRepository;
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        readonly IProductPropertyReadRepository _productPropertyReadRepository;
        readonly IProductPropertyWriteRepository _productPropertyWriteRepository;
        readonly IProductColorReadRepository _productColorReadRepository;
        readonly IProductColorWriteRepository _productColorWriteRepository;
        readonly IProductSizeReadRepository _productSizeReadRepository;
        readonly IProductSizeWriteRepository _productSizeWriteRepository;
        readonly IProductShopWriteRepository _productShopWriteRepository;

        public ProductDeleteService(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IProductImageFileReadRepository productImageFileReadRepository, IProductImageFileWriteRepository productImageFileWriteRepository, IProductPropertyReadRepository productPropertyReadRepository, IProductPropertyWriteRepository productPropertyWriteRepository, IProductColorReadRepository productColorReadRepository, IProductColorWriteRepository productColorWriteRepository, IProductSizeReadRepository productSizeReadRepository, IProductSizeWriteRepository productSizeWriteRepository, IProductShopWriteRepository productShopWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _productImageFileReadRepository = productImageFileReadRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _productPropertyReadRepository = productPropertyReadRepository;
            _productPropertyWriteRepository = productPropertyWriteRepository;
            _productColorReadRepository = productColorReadRepository;
            _productColorWriteRepository = productColorWriteRepository;
            _productSizeReadRepository = productSizeReadRepository;
            _productSizeWriteRepository = productSizeWriteRepository;
            _productShopWriteRepository = productShopWriteRepository;
        }

        public async Task DeleteTemporarilyProductAsync(string id)
        {
            Product product = await _productReadRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == id, true, "Properties");
            if (product == null) throw new NotFoundException("mağaza");
            foreach (var property in product.Properties)
            {
                _productPropertyWriteRepository.DeleteTemporarily(property);
            }
            //foreach (var comment in product.Comments)
            //{
            //    _productCommentWriteRepository.DeleteTemporarily(comment);
            //}
            _productWriteRepository.DeleteTemporarily(product);
            await _productPropertyWriteRepository.SaveAsync();
            await _productWriteRepository.SaveAsync();
        }

        public async Task RecoverProductDataAsync(string id)
        {
            Product product = await _productReadRepository.GetWhereAsync(x => x.isDeleted && x.ID.ToString() == id, true, "Properties");
            if (product == null) throw new NotFoundException("məhsul");

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
            await _productPropertyWriteRepository.SaveAsync();
        }

        public async Task RemovePermanentlyProductAsync(string id)
        {
            Product product = await _productReadRepository.GetWhereAsync(p => p.ID.ToString() == id, true, "Images", "Properties");

            if (product == null) throw new NotFoundException("məhsul");
            foreach (var image in product.Images)
            {
                _productImageFileWriteRepository.RemovePermanently(image);
            }
            foreach (var property in product.Properties)
            {
                _productPropertyWriteRepository.RemovePermanently(property);
            }
            //foreach (var comment in product.Comments)
            //{
            //    _productCommentWriteRepository.RemovePermanently(comment);
            //}
            _productWriteRepository.RemovePermanently(product);
            await _productWriteRepository.SaveAsync();
        }

        public async Task RemovePermanentlyProductImageFileAsync(string id)
        {
            ProductImageFile image = await _productImageFileReadRepository.GetWhereAsync(x => x.ID.ToString() == id, true);
            if (image == null) throw new NotFoundException("məhsul şəkli");
            _productImageFileWriteRepository.RemovePermanently(image);
            await _productImageFileWriteRepository.SaveAsync();
        }

        public async Task RemovePermanentlyProductPropertyAsync(string id)
        {
            ProductProperty property = await _productPropertyReadRepository.GetWhereAsync(x => x.ID.ToString() == id, true);
            if (property == null) throw new NotFoundException("məhsul xüsusiyyəti");
            _productPropertyWriteRepository.RemovePermanently(property);
            await _productPropertyWriteRepository.SaveAsync();
        }

        public async Task RemovePermanentlyProductShopAsync(string prodcutId, string shopId)
        {
            await _productShopWriteRepository.RemovePermanentlyProductShopAsync(prodcutId, shopId);
        }

        public async Task RemovePermanentlyProductColorAsync(string id)
        {
            var color = await _productColorReadRepository.GetWhereAsync(c => c.ID.ToString() == id && !c.isDeleted, true);
            if (color == null) throw new NotFoundException("rəng");
            _productColorWriteRepository.RemovePermanently(color);
            await _productColorWriteRepository.SaveAsync();
        }

        public async Task RemovePermanentlyProductSizeAsync(string id)
        {
            var size = await _productSizeReadRepository.GetWhereAsync(s => s.ID.ToString() == id && !s.isDeleted, true);
            if (size == null) throw new NotFoundException("ölçü");
            _productSizeWriteRepository.RemovePermanently(size);
            await _productSizeWriteRepository.SaveAsync();
        }
    }
}
