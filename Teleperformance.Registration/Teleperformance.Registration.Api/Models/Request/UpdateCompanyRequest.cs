using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teleperformance.Registration.Api.Models.Request
{
    public class UpdateCompanyRequest
    {
        public int Id { get; set; }
        public Domain.Entities.Company Company { get; set; }
    }
}
