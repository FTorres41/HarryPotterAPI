using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HarryPotter.API.Requests;
using HarryPotter.Service.Interface;
using HarryPotter.Model.Requests;
using System.Threading.Tasks;
using HarryPotter.Util;

namespace HarryPotter.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Character")]
    public class CharacterController : Controller
    {
        protected readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("")]
        public ActionResult GetCharacters([FromQuery]string house, [FromQuery] string patronus, [FromQuery] string school, [FromQuery] string role)
        {
            var result = _characterService.GetCharacters(house, role, patronus, school);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("insert")]
        public ActionResult InsertCharacter([FromBody]CreateCharacterRequest request)
        {
            request.Validate();

            if (request.Invalid)
                return BadRequest($"Favor informar valores válidos para: {ErrorHelper.GetErrors(request)}");

            _characterService.InsertCharacter(request.Name, request.Role, request.Patronus, request.House);
            
            return Ok();
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("update")]
        public ActionResult UpdateCharacter([FromBody] UpdateCharacterRequest request)
        {
            request.Validate();

            if (request.Invalid)
                return BadRequest($"Favor informar valores válidos para: {ErrorHelper.GetErrors(request)}");

            _characterService.UpdateCharacter(request.Id, request.Name, request.Role, request.Patronus, request.House);

            return Ok();
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult DeleteCharacter([FromRoute]string id)
        {
            var result = _characterService.DeleteCharacter(id);

            return Ok(result);
        }
    }
}