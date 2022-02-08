using System.Threading.Tasks;
using Xunit;

namespace Approval.Tests.Integration
{
    public class DynamicControllerTests : IntegrationTests
    {
        public DynamicControllerTests(AppFactory appFactory) : base(appFactory)
        {
        }

        [Fact]
        public async Task Should_Get_Tony_Montana()
            => await Client.GetAsync("/dynamic")
                .Verify();
    }
}
