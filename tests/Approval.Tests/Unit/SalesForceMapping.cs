using System.Linq;
using Approval.Shared.ReadModels;
using Approval.Web;
using AutoMapper;
using FluentAssertions;
using FluentAssertions.Extensions;
using Xunit;

namespace Approval.Tests.Unit;

public class SalesForceMapping : MappingTests
{
    private IndividualParty MapAlCaponeToIndividualParty() 
        => Mapper.Map<IndividualParty>(DataBuilder.AlCapone());

    [Fact]
    public void Map_PersonAccount_To_IndividualParty()
    {
        var party = MapAlCaponeToIndividualParty();

        party.Gender.Should().Be(Gender.Male);
        party.Title.Should().Be("Mr.");
        party.BirthCity.Should().Be("Brooklyn");
        party.BirthDate.Should().Be(25.January(1899));
        party.FirstName.Should().Be("Al");
        party.LastName.Should().Be("Capone");
        party.MiddleName.Should().Be("");
        party.PepMep.Should().BeFalse();
        party.Documents.Should().HaveCount(1);

        var document = party.Documents.ElementAt(0);
        document.Number.Should().Be("89898*3234");
        document.DocumentType.Should().Be("ID CARD");
        document.ExpirationDate.Should().Be(5.January(2000));
    }
}
