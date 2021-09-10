using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Teleperformance.Registration.Api.Presenters;
using Teleperformance.Registration.Domain.Dto.UseCaseRequests;
using Teleperformance.Registration.Domain.Ports.UseCases;

namespace Teleperformance.Registration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IRegisterCompanyUseCase _registerCompanyUseCase;
        private readonly IFindByIdentificationCompanyUseCase _FindByIdentificationCompanyUseCase;
        private readonly IUpdateCompanyUseCase _updateCompanyUseCase;


        private readonly RegisterCompanyPresenter _registerCompanyPresenter;
        private readonly UpdateCompanyPresenter _updateCompanyPresenter;
        private readonly FindByIdentificationCompanyPresenter _findByIdentificationCompanyPresenter;

        public CompanyController(
            IRegisterCompanyUseCase registerCompanyUseCase, 
            IFindByIdentificationCompanyUseCase findByIdentificationCompanyUseCase,
            IUpdateCompanyUseCase updateCompanyUseCase,
            RegisterCompanyPresenter registerCompanyPresenter,
            UpdateCompanyPresenter updateCompanyPresenter,
            FindByIdentificationCompanyPresenter findByIdentificationCompanyPresenter
        )
        {
            _FindByIdentificationCompanyUseCase = findByIdentificationCompanyUseCase;
            _registerCompanyUseCase = registerCompanyUseCase;
            _updateCompanyUseCase = updateCompanyUseCase;

            _findByIdentificationCompanyPresenter = findByIdentificationCompanyPresenter;
            _registerCompanyPresenter = registerCompanyPresenter;
            _updateCompanyPresenter = updateCompanyPresenter;

        }

        [HttpGet]
        public async Task<ActionResult> FindByIdentification(string identificationNumber)
        {
            await _FindByIdentificationCompanyUseCase.Handle(new FindByIdentificationCompanyRequest(identificationNumber), _findByIdentificationCompanyPresenter);
            return _findByIdentificationCompanyPresenter.ContentResult;
        }

        // POST api/company
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Models.Request.RegisterCompanyRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _registerCompanyUseCase.Handle(new RegisterCompanyRequest(
                request.IdentificationType,
                request.IdentificationNumber,
                request.CompanyName,
                request.FirstName,
                request.SecondName,
                request.FirstLastname,
                request.SecondLastname,
                request.Email), _registerCompanyPresenter);

            return _registerCompanyPresenter.ContentResult;
        }
        
        [HttpPatch]
        public async Task<ActionResult> Update([FromBody] Models.Request.UpdateCompanyRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _updateCompanyUseCase.Handle(new UpdateCompanyRequest(
                request.Id,
                request.Company
            ), _updateCompanyPresenter);

            return _updateCompanyPresenter.ContentResult;
        }
    }
}
