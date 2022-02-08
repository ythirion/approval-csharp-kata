using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Approval.Shared.ReadModels;
using FluentAssertions;
using FluentAssertions.Extensions;
using Xunit;

namespace Approval.Tests.Integration
{
    public class PartiesControllerTests : IntegrationTests
    {
        public PartiesControllerTests(AppFactory appFactory) : base(appFactory)
        {
        }

        [Fact]
        public async Task Should_Retrieve_Capone_And_Mesrine()
        {
            var response = await Client.GetAsync("/parties");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var parties = await response.Deserialize<IndividualParty[]>();

            parties.Should().HaveCount(2);
            AssertCapone(parties[0]);
            AssertMesrine(parties[1]);
        }

        [Fact]
        public async Task Should_Retrieve_Capone_And_Mesrine_With_Verify()
            => await Client.GetAsync("/parties")
                .Verify(_ => _.DontScrubDateTimes());

        private void AssertCapone(IndividualParty capone)
        {
            capone.Gender.Should().Be(Gender.Male);
            capone.Title.Should().Be("Mr.");
            capone.BirthCity.Should().Be("Brooklyn");
            capone.BirthDate.Should().Be(25.January(1899));
            capone.FirstName.Should().Be("Al");
            capone.LastName.Should().Be("Capone");
            capone.MiddleName.Should().Be("");
            capone.PepMep.Should().BeFalse();
            capone.Documents.Should().HaveCount(1);

            var document = capone.Documents.ElementAt(0);
            document.Number.Should().Be("89898*3234");
            document.DocumentType.Should().Be("ID CARD");
            document.ExpirationDate.Should().Be(5.January(2000));
        }

        private void AssertMesrine(IndividualParty mesrine)
        {
            mesrine.Gender.Should().Be(Gender.Male);
            mesrine.Title.Should().Be("Mr.");
            mesrine.BirthCity.Should().Be("Clichy");
            mesrine.BirthDate.Should().Be(28.December(1936));
            mesrine.FirstName.Should().Be("Jacques");
            mesrine.LastName.Should().Be("Mesrine");
            mesrine.MiddleName.Should().Be("");
            mesrine.PepMep.Should().BeTrue();
            mesrine.Documents.Should().HaveCount(2);

            var idCard = mesrine.Documents.ElementAt(0);
            idCard.Number.Should().Be("89AJQND8579");
            idCard.DocumentType.Should().Be("ID CARD");
            idCard.ExpirationDate.Should().Be(30.September(2020));

            var passport = mesrine.Documents.ElementAt(1);
            passport.Number.Should().Be("Not a number");
            passport.DocumentType.Should().Be("FAKE PASSPORT");
            passport.ExpirationDate.Should().Be(23.December(1990));
        }
    }
}
