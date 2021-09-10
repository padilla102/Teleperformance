
namespace Teleperformance.Registration.Domain.Dto.GatewayResponses.Repositories
{
    public class CreateCompanyResponse : BaseGatewayResponse
    {
        public string Id { get; set; }

        public CreateCompanyResponse(string id, bool success = false, Error error = null) : base(success, error)
        {
            Id = id;
        }
    }
}
