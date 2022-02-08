using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Approval.Tests.Integration
{
    public static class HttpExtensions
    {
        public static async Task<T> Deserialize<T>(this HttpResponseMessage? response)
            => JsonConvert.DeserializeObject<T>(await response!.Content.ReadAsStringAsync())!;
    }
}
