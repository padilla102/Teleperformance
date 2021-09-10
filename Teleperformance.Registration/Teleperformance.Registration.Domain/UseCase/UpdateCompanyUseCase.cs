
using System.Threading.Tasks;
using Teleperformance.Registration.Domain.Dto.UseCaseRequests;
using Teleperformance.Registration.Domain.Dto.UseCaseResponse;
using Teleperformance.Registration.Domain.Ports;
using Teleperformance.Registration.Domain.Ports.Gateways.Repositories;
using Teleperformance.Registration.Domain.Ports.UseCases;

namespace Teleperformance.Registration.Domain.UseCase
{
    public class UpdateCompanyUseCase : IUpdateCompanyUseCase
    {
        private readonly ICompanyRepository _companyRepository;

        public UpdateCompanyUseCase(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<bool> Handle(UpdateCompanyRequest message, IOutputPort<UpdateCompanyResponse> outputPort)
        {
            var response = await _companyRepository.Update(message);
            outputPort.Handle(response.Success ? new UpdateCompanyResponse(response.Company, true) : new UpdateCompanyResponse(response.Error));
            return response.Success;
        }
    }
}
