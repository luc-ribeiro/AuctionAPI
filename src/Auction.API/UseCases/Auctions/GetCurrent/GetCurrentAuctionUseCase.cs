using DotnetAuction.API.Entities;
using DotnetAuction.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DotnetAuction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    public Auction? Execute()
    {
        var repository = new DotnetAuctionDbContext();

        var today = DateTime.UtcNow;

        return repository
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
    }
}
