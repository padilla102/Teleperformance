using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teleperformance.Registration.Domain.Dto;
using Teleperformance.Registration.Domain.Dto.GatewayResponses.Repositories;
using Teleperformance.Registration.Domain.Dto.UseCaseRequests;
using Teleperformance.Registration.Domain.Entities;
using Teleperformance.Registration.Domain.Ports.Gateways.Repositories;

namespace Teleperformance.Registration.Infrastruture.Data.Repositories
{
    public class CompanyRepository : EfRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
        public async Task<CreateCompanyResponse> Create(RegisterCompanyRequest request)
        {
            try
            {
                var company = new Company
                {
                    IdentificationType = request.IdentificationType,
                    IdentificationNumber = request.IdentificationNumber,
                    CompanyName = request.CompanyName,
                    FirstName = request.FirstName,
                    SecondName = request.SecondName,
                    FirstLastname = request.FirstLastname,
                    SecondLastname = request.SecondLastname,
                    Email = request.Email
                };
                _appDbContext.Companies.Add(company);

                await _appDbContext.SaveChangesAsync();

                return new CreateCompanyResponse(company.Id.ToString(), true, new Error("0", ""));
            }
            catch (Exception e)
            {
                return new CreateCompanyResponse("", false, new Error(e.TargetSite.Name, e.Message));
            }
            
        }

        public async Task<FindCompanyResponse> FindByIdentification(string identificationNumber)
        {
            var company = await _appDbContext.Companies.FirstOrDefaultAsync(c => c.IdentificationNumber == identificationNumber);
            return new FindCompanyResponse(company, true, new Error("0", ""));
        }

        public async Task<UpdateCompanyResponse> Update(UpdateCompanyRequest request)
        {
            try
            {
                var company = await _appDbContext.Companies.FirstOrDefaultAsync(c => c.Id == request.Id).ConfigureAwait(false);

                //company.IdentificationType = request.Company.IdentificationType,
                //company.IdentificationNumber = request.Company.IdentificationNumber,
                company.CompanyName = request.Company.CompanyName;
                company.FirstName = request.Company.FirstName;
                company.SecondName = request.Company.SecondName;
                company.FirstLastname = request.Company.FirstLastname;
                company.SecondLastname = request.Company.SecondLastname;
                company.Email = request.Company.Email;

                await _appDbContext.SaveChangesAsync().ConfigureAwait(false);

                return new UpdateCompanyResponse(company, true, new Error("0", ""));
            }
            catch (Exception e)
            {
                return new UpdateCompanyResponse(request.Company, false, new Error(e.TargetSite.Name, e.Message));
            }
        }
    }
}
