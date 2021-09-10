using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teleperformance.Registration.Api.Models.Request
{
    public class RegisterCompanyRequest
    {        
        public int IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstLastname { get; set; }
        public string SecondLastname { get; set; }
        public string Email { get; set; }
    }
}
