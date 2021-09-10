using System.Linq;
using System.Threading.Tasks;
using Teleperformance.Registration.Domain.Dto.UseCaseRequests;
using Teleperformance.Registration.Domain.Dto.UseCaseResponse;
using Teleperformance.Registration.Domain.Ports;
using Teleperformance.Registration.Domain.Ports.Gateways.Repositories;
using Teleperformance.Registration.Domain.Ports.UseCases;

namespace Teleperformance.Registration.Domain.UseCase
{
    public class RegistrerCompanyUseCase : IRegisterCompanyUseCase
    {
        private readonly ICompanyRepository _companyRepository;

        public RegistrerCompanyUseCase(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<bool> Handle(RegisterCompanyRequest message, IOutputPort<RegisterCompanyResponse> outputPort)
        {
            var response = await _companyRepository.Create(message);
            outputPort.Handle(response.Success ? new RegisterCompanyResponse(response.Id, true) : new RegisterCompanyResponse(response.Error.Description));
            return response.Success;
        }
    }
}
