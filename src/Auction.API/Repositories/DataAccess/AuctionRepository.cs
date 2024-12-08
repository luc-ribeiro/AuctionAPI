using DotnetAuction.API.Contracts;
using DotnetAuction.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetAuction.API.Repositories.DataAccess;

public class AuctionRepository : IAuctionRepository
{
    private readonly DotnetAuctionDbContext _dbContext;

    public AuctionRepository(DotnetAuctionDbContext dbContext) => _dbContext = dbContext;

    public Auction? GetCurrent()
    {
        var today = DateTime.UtcNow;

        return _dbContext
           .Auctions
           .Include(auction => auction.Items)
           .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
    }
}
