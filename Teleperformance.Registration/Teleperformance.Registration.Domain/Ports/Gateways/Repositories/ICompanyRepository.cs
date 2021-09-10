using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Teleperformance.Registration.Domain.Entities;
using Teleperformance.Registration.Domain.Dto.GatewayResponses.Repositories;
using Teleperformance.Registration.Domain.Dto.UseCaseRequests;

namespace Teleperformance.Registration.Domain.Ports.Gateways.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<CreateCompanyResponse> Create(RegisterCompanyRequest request); 
        Task<UpdateCompanyResponse> Update(UpdateCompanyRequest request);
        Task<FindCompanyResponse> FindByIdentification(string IdentificationNumber);

    }
}
