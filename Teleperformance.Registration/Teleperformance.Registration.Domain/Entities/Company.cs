using Teleperformance.Registration.Domain.Shared;

namespace Teleperformance.Registration.Domain.Entities
{
    public class Company : BaseEntity
    {
        public int IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string  SecondName { get; set; }
        public string FirstLastname { get; set; }
        public string SecondLastname { get; set; }
        public string Email { get; set; }
    }
}
