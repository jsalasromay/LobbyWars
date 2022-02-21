using LobbyWars.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace LobbyWars.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OperationController : Controller
    {
        private IOperationService _operationService;
        public OperationController(IOperationService operationService)
        {
            _operationService = operationService;
        }
        [HttpGet]
        public string GetWinnerParty(string partyOne, string partyTwo)
        {
            return  _operationService.GetWinnerParty(partyOne, partyTwo);
        }
    }
}
