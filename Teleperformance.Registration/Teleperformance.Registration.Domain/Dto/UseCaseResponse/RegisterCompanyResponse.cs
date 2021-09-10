using System.Collections.Generic;
using Teleperformance.Registration.Domain.Ports;

namespace Teleperformance.Registration.Domain.Dto.UseCaseResponse
{
    public class RegisterCompanyResponse : UseCaseResponseMessage
    {
        public string Id { get; }
        public IEnumerable<string> Errors { get; }

        public RegisterCompanyResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RegisterCompanyResponse(string id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}
