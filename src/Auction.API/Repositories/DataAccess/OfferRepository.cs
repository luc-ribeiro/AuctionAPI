using DotnetAuction.API.Contracts;
using DotnetAuction.API.Entities;

namespace DotnetAuction.API.Repositories.DataAccess;

public class OfferRepository : IOfferRepository
{
    private readonly DotnetAuctionDbContext _dbContext;

    public OfferRepository(DotnetAuctionDbContext dbContext) => _dbContext = dbContext;

    public void Add(Offer offer)
    {
        _dbContext.Offers.Add(offer);

        _dbContext.SaveChanges();
    }
}
