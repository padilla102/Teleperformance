using Teleperformance.Registration.Domain.Dto.UseCaseResponse;
using Teleperformance.Registration.Domain.Ports;

namespace Teleperformance.Registration.Domain.Dto.UseCaseRequests
{
    public class RegisterCompanyRequest : IUseCaseRequest<RegisterCompanyResponse>
    {
        public int IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstLastname { get; set; }
        public string SecondLastname { get; set; }
        public string Email { get; set; }
        public bool SendMessage { get; set; }
        public bool SendEmail { get; set; }

        public RegisterCompanyRequest(
            int identificationType,
            string identificationNumber,
            string companyName,
            string firstName,
            string secondName,
            string firstLastname,
            string secondLastname,
            string email,
            bool sendMessage,
            bool sendEmail)
        {
            IdentificationType = identificationType;
            IdentificationNumber = identificationNumber;
            CompanyName = companyName;
            FirstName = firstName;
            SecondName = secondName;
            FirstLastname = firstLastname;
            SecondLastname = secondLastname;
            Email = email;
            SendMessage = sendMessage;
            SendEmail = sendEmail;
        }
    }
}
