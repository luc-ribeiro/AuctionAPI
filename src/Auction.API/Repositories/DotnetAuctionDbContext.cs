using DotnetAuction.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetAuction.API.Repositories;

public class DotnetAuctionDbContext : DbContext
{
    public DotnetAuctionDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }
}
