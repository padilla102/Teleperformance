using System.Collections.Generic;
using Teleperformance.Registration.Domain.Ports;

namespace Teleperformance.Registration.Domain.Dto.UseCaseResponse
{
    public class RegisterCompanyResponse : UseCaseResponseMessage
    {
        public string Id { get; }
        public Error Error { get; }

        public RegisterCompanyResponse(Error error, bool success = false, string message = null) : base(success, message)
        {
            Error = error;
        }

        public RegisterCompanyResponse(string id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}
