using Teleperformance.Registration.Domain.Entities;
using Teleperformance.Registration.Domain.Ports;

namespace Teleperformance.Registration.Domain.Dto.UseCaseRequests
{
    public class FindByIdentificationCompanyResponse : UseCaseResponseMessage
    {
        public Company Company { get; }
        public Error Error { get; }
        public FindByIdentificationCompanyResponse(Error error, bool success = false, string message = null) : base(success, message)
        {
            Error = error;
        }

        public FindByIdentificationCompanyResponse(Company company, bool success = false, string message = null) : base(success, message)
        {
            Company = company;
        }
    }
}
