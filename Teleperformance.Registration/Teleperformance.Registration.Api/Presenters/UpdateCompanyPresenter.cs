using System.Net;
using Teleperformance.Registration.Domain.Ports;
using Teleperformance.Registration.Api.Serialization;
using Teleperformance.Registration.Domain.Dto.UseCaseResponse;

namespace Teleperformance.Registration.Api.Presenters
{
    public class UpdateCompanyPresenter : IOutputPort<UpdateCompanyResponse>
    {
        public JsonContentResult ContentResult { get; }
        public UpdateCompanyPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        public void Handle(UpdateCompanyResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
