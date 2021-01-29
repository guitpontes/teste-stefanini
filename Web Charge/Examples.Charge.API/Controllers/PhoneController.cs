using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/phones")]
    [ApiController]
    public class PhoneController : BaseController
    {
        private IPhoneFacade _phoneFacade;

        public PhoneController(IPhoneFacade phoneFacade)
        {
            this._phoneFacade = phoneFacade;
        }

        [HttpGet]
        public ActionResult<Task<IEnumerable<PhoneResponse>>> Get()
        {            
            return Ok(_phoneFacade.FindAllAsync().Result);
        }

        /// <summary>
        /// Inserir telefones
        /// </summary>
        /// <param name="request">Contém parametros para inserção</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<PhoneResponse> Post([FromBody]PhoneRequest request)
        {
            return Ok(_phoneFacade.Insert(request));
        }
        /// <summary>
        /// Excluir telefones
        /// </summary>
        /// <param name="request">Contém parametros para exclusão</param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult Delete([FromQuery] PhoneRequest request)
        {
            _phoneFacade.Delete(request);

            return Ok();
        }

        [HttpPut()]
        public ActionResult<PhoneResponse> Put([FromQuery] PhoneRequest oldPhone, [FromBody] PhoneEditRequest request)
        {
            return Ok(_phoneFacade.Put(oldPhone, request));
        }

        [HttpGet("types")]
        public ActionResult<IEnumerable<PhoneTypeResponse>> GetTypes()
        {
            return Ok(_phoneFacade.GetTypes());
        }

    }
}
