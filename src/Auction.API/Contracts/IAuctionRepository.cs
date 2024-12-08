using DotnetAuction.API.Entities;

namespace DotnetAuction.API.Contracts;

public interface IAuctionRepository
{
    Auction? GetCurrent();
}
