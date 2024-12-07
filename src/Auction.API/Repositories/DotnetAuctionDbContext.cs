using DotnetAuction.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetAuction.API.Repositories;

public class DotnetAuctionDbContext : DbContext
{
    public DbSet<Auction> Auctions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=L:\\Workspace\\AuctionAPI\\AuctionDB.db");
    }
}
