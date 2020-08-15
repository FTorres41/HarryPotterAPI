using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HarryPotter.API.Requests;
using HarryPotter.Service.Interface;
using HarryPotter.Model.Requests;

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
        public JsonResult GetCharacters([FromQuery]string house, [FromQuery] string patronus, [FromQuery] string school, [FromQuery] string role)
        {
            var result = _characterService.GetCharacters(house, role, patronus, school);
            return Json(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("insert")]
        public JsonResult InsertCharacter([FromBody]CreateCharacterRequest request)
        {
            _characterService.InsertCharacter(request.Name, request.Role, request.Patronus, request.House);
            return Json("Personagem criado com sucesso");
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("update")]
        public JsonResult UpdateCharacter([FromBody] UpdateCharacterRequest request)
        {
            _characterService.UpdateCharacter(request.Id, request.Name, request.Role, request.Patronus, request.School, request.House);
            return Json("Personagem atualizado com sucesso");
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("delete/{id}")]
        public JsonResult DeleteCharacter([FromRoute]string id)
        {
            _characterService.DeleteCharacter(id);
            return Json("Personagem excluído com sucesso");
        }
    }
}