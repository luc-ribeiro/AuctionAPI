using Bogus;
using DotnetAuction.API.Communication.Requests;
using DotnetAuction.API.Contracts;
using DotnetAuction.API.Entities;
using DotnetAuction.API.Services;
using DotnetAuction.API.UseCases.Offers.CreateOffer;
using FluentAssertions;
using Moq;

namespace UseCases.Test.Auctions.GetCurrent;

public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId)
    {
        var request = new Faker<RequestCreateOfferJson>()
            .RuleFor(request => request.Price, f => f.Random.Decimal(1, 700))
            .Generate();

        var offerRepository = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        loggedUser.Setup(i => i.User()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

        var act = () => useCase.Execute(itemId, request);

        act.Should().NotThrow();
    }
}
