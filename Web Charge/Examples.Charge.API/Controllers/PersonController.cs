using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : BaseController
    {
        private IPersonFacade _personFacade;

        public PersonController(IPersonFacade personFacade)
        {
            this._personFacade = personFacade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonResponse>> Get()
        {
            return await _personFacade.FindAllAsync();
        }

    }
}
