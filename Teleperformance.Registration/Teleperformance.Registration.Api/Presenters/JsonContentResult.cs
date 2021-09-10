using Microsoft.AspNetCore.Mvc;

namespace Teleperformance.Registration.Api.Presenters
{
    public class JsonContentResult : ContentResult
    {
        public JsonContentResult()
        {
            ContentType = "application/json";
        }
    }
}
