using Approval.Shared.ReadModels;
using Approval.Shared.SalesForce;
using AutoMapper;

namespace Approval.Web.Services
{
    public class IndividualPartyService
    {
        private readonly IMapper _mapper;

        public IndividualPartyService(IMapper mapper) => _mapper = mapper;

        public async Task<IEnumerable<IndividualParty>> GetAllIndividualPartiesAsync()
        {
            var accounts = new[] {DataBuilder.AlCapone(), DataBuilder.Mesrine()};
            return await Task.FromResult(_mapper.Map<PersonAccount[], IEnumerable<IndividualParty>>(accounts));
        }
    }
}
