using System.Collections.Generic;

namespace Teleperformance.Registration.Domain.Dto.GatewayResponses
{
    public class BaseGatewayResponse
    {
        public bool Success { get; }
        public Error Error { get; }

        protected BaseGatewayResponse(bool success = false, Error error = null)
        {
            Success = success;
            Error = error;
        }
    }
}
