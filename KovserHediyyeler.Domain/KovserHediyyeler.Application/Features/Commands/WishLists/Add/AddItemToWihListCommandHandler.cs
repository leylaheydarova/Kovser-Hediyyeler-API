using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.DTOs.WishLists;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WishLists.Add
{
    public class AddItemToWihListCommandHandler : IRequestHandler<AddItemToWihListCommandRequest, AddItemToWihListCommandResponse>
    {
        readonly IWishListService _service;

        public AddItemToWihListCommandHandler(IWishListService service)
        {
            _service = service;
        }

        public async Task<AddItemToWihListCommandResponse> Handle(AddItemToWihListCommandRequest request, CancellationToken cancellationToken)
        {
            var isAdded = await _service.AddItemToWishListAsync(request.Dto.CustomerId, request.Dto.ProductId);
            var dto = new WishListPostResultDto()
            {
                IsAdded = isAdded
            };
            if (isAdded)
            {

                dto.Message = "Məhsul sevilənlər siyahısına uğurla əlavə olundu!";
            }
            else
            {
                dto.Message = "Məhsul artıq sevilənlər siyahısında var.";
            }

            return new AddItemToWihListCommandResponse
            {
                Dto = dto
            };
        }
    }
}
