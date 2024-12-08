using DotnetAuction.API.Communication.Requests;
using DotnetAuction.API.Filters;
using DotnetAuction.API.UseCases.Offers.CreateOffer;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAuction.API.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : DotnetAuctionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer(
        [FromRoute] int itemId,
        [FromBody] RequestCreateOfferJson request,
        [FromServices] CreateOfferUseCase useCase)
    {
        var id = useCase.Execute(itemId, request);

        return Created(string.Empty, id);
    }
}
