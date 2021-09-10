
using System.Net;
using Teleperformance.Registration.Api.Serialization;
using Teleperformance.Registration.Domain.Dto.UseCaseRequests;
using Teleperformance.Registration.Domain.Ports;

namespace Teleperformance.Registration.Api.Presenters
{
    public class FindByIdentificationCompanyPresenter : IOutputPort<FindByIdentificationCompanyResponse>
    {
        public JsonContentResult ContentResult { get; }
        public FindByIdentificationCompanyPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        public void Handle(FindByIdentificationCompanyResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
