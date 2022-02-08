using Approval.Web;
using AutoMapper;

namespace Approval.Tests.Unit
{
    public class MappingTests
    {
        protected readonly IMapper Mapper;

        protected MappingTests()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<MapperProfile>(); });
            Mapper = config.CreateMapper();
        }
    }
}
