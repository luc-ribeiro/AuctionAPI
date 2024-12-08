using DotnetAuction.API.Entities;

namespace DotnetAuction.API.Contracts;

public interface IOfferRepository
{
    void Add(Offer offer);
}
