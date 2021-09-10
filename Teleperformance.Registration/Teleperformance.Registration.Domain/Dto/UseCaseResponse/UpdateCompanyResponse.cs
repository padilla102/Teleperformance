
using Teleperformance.Registration.Domain.Entities;
using Teleperformance.Registration.Domain.Ports;

namespace Teleperformance.Registration.Domain.Dto.UseCaseResponse
{
    public class UpdateCompanyResponse : UseCaseResponseMessage
    {
        public Company Company { get; }
        public Error Error { get; }
        public UpdateCompanyResponse(Error error, bool success = false, string message = null) : base(success, message)
        {
            Error = error;
        }

        public UpdateCompanyResponse(Company company, bool success = false, string message = null) : base(success, message)
        {
            Company = company;
        }
    }
}
