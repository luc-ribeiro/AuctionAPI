using Bogus;
using DotnetAuction.API.Contracts;
using DotnetAuction.API.Entities;
using DotnetAuction.API.Enums;
using DotnetAuction.API.UseCases.Auctions.GetCurrent;
using FluentAssertions;
using Moq;

namespace UseCases.Test.Auctions.GetCurrent;

public class GetCurrentAuctionUseCaseTest
{
    [Fact]
    public void Success()
    {
        var entity = new Faker<Auction>()
            .RuleFor(auction => auction.Id, faker => faker.Random.Number(1, 10))
            .RuleFor(auction => auction.Name, faker => faker.Lorem.Word())
            .RuleFor(auction => auction.Starts, f => f.Date.Past())
            .RuleFor(auction => auction.Ends, f => f.Date.Future())
            .RuleFor(auction => auction.Items, (f, auction) => new List<Item>
            {
                new Item
                {
                    Id = f.Random.Number(1, 10),
                    Name = f.Commerce.ProductName(),
                    Brand = f.Commerce.Department(),
                    BasePrice = f.Random.Decimal(50, 1000),
                    Condition = f.PickRandom<Condition>(),
                    AuctionId = auction.Id
                }
            }).Generate();

        var auctionRepository = new Mock<IAuctionRepository>();
        auctionRepository.Setup(i => i.GetCurrent()).Returns(entity);

        var useCase = new GetCurrentAuctionUseCase(auctionRepository.Object);

        var auction = useCase.Execute();

        auction.Should().NotBeNull();
        auction!.Id.Should().Be(entity.Id);
        auction.Name.Should().Be(entity.Name);
    }
}
