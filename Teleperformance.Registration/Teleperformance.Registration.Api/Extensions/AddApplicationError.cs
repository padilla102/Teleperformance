using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;


namespace Teleperformance.Registration.Api.Extensions
{
    public static class ResponseExtensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", RemoveAllNonPrintableCharacters(message));
            // CORS
            response.Headers.Add("access-control-expose-headers", "Application-Error");
        }

        public static string RemoveAllNonPrintableCharacters(string target)
        {
            return Regex.Replace(target, @"\p{C}+", string.Empty);
        }
    }
}
