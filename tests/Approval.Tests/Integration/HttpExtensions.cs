using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using VerifyTests;
using static VerifyXunit.Verifier;

namespace Approval.Tests.Integration
{
    public static class HttpExtensions
    {
        public static async Task<T> Deserialize<T>(this HttpResponseMessage? response)
            => JsonConvert.DeserializeObject<T>(await response!.Content.ReadAsStringAsync())!;

        public static async Task Verify(
            this Task<HttpResponseMessage> call,
            Action<SerializationSettings>? settings = null,
            HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var result = await call;
            result.StatusCode.Should().Be(expectedStatusCode);

            VerifyJson(await result.Content.ReadAsStringAsync())
                .WithSettings(settings);
        }
    }
}
