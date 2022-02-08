using System.Net.Http;
using VerifyXunit;
using Xunit;

namespace Approval.Tests.Integration
{
    [UsesVerify]
    public class IntegrationTests : IClassFixture<AppFactory>
    {
        protected readonly HttpClient Client;

        protected IntegrationTests(AppFactory appFactory)
            => Client = appFactory.CreateClient();
    }
}
