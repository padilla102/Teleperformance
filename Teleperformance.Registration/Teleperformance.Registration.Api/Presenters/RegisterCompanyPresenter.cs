using System.Net;
using Teleperformance.Registration.Domain.Ports;
using Teleperformance.Registration.Api.Serialization;
using Teleperformance.Registration.Domain.Dto.UseCaseResponse;

namespace Teleperformance.Registration.Api.Presenters
{
    public class RegisterCompanyPresenter : IOutputPort<RegisterCompanyResponse>
    {
        public JsonContentResult ContentResult { get; }
        public RegisterCompanyPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        public void Handle(RegisterCompanyResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
