using System.Threading.Tasks;
using Teleperformance.Registration.Domain.Dto.UseCaseRequests;
using Teleperformance.Registration.Domain.Dto.UseCaseResponse;
using Teleperformance.Registration.Domain.Ports;
using Teleperformance.Registration.Domain.Ports.Gateways.Repositories;
using Teleperformance.Registration.Domain.Ports.UseCases;

namespace Teleperformance.Registration.Domain.UseCase
{
    public class FindByIdentificationCompanyUseCase : IFindByIdentificationCompanyUseCase
    {
        private readonly ICompanyRepository _companyRepository;

        public FindByIdentificationCompanyUseCase(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<bool> Handle(FindByIdentificationCompanyRequest message, IOutputPort<FindByIdentificationCompanyResponse> outputPort)
        {
            var response = await _companyRepository.FindByIdentification(message.IdentificationNumber);
            outputPort.Handle(response.Success ? new FindByIdentificationCompanyResponse(response.Company, true) : 
                new FindByIdentificationCompanyResponse(response.Error));
            return response.Success;
        }
    }
}
