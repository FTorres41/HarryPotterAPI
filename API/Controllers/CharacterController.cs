using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HarryPotter.API.Requests;
using HarryPotter.Service.Interface;

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
        [HttpPost]
        [Route("insert")]
        public JsonResult InsertCharacter(string name, string role, string patronus, string school, string house)
        {
            _characterService.InsertCharacter(name, role, patronus, school, house);
            return Json("Personagem criado com sucesso");
        }
    }
}