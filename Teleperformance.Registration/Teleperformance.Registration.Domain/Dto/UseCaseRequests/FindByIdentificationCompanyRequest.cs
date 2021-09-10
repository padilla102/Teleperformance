using Teleperformance.Registration.Domain.Ports;

namespace Teleperformance.Registration.Domain.Dto.UseCaseRequests
{
    public class FindByIdentificationCompanyRequest : IUseCaseRequest<FindByIdentificationCompanyResponse>
    {
        public string IdentificationNumber { get; set; }
        public FindByIdentificationCompanyRequest(string identificationNumber)
        {
            IdentificationNumber = identificationNumber;
        }
    }
}
