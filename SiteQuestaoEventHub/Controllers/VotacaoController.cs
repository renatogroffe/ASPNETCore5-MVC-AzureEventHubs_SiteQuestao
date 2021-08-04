using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SiteQuestaoEventHub.EventHubs;

namespace SiteQuestaoEventHub.Controllers
{
    public class VotacaoController : Controller
    {
        private readonly ILogger<VotacaoController> _logger;
        private readonly VotacaoProducer _producer;

        public VotacaoController(ILogger<VotacaoController> logger,
            VotacaoProducer producer)
        {
            _logger = logger;
            _producer = producer;
        }

        public async Task<IActionResult> VotoDotNet()
        {
            return await ProcessarVoto(".NET");
        }

        public async Task<IActionResult> VotoAzureFunctions()
        {
            return await ProcessarVoto("Azure Functions");
        }

        public async Task<IActionResult> VotoASPNETCore()
        {
            return await ProcessarVoto("ASP.NET Core");
        }

        public async Task<IActionResult> VotoPowerShell()
        {
            return await ProcessarVoto("PowerShell");
        }

        private async Task<IActionResult> ProcessarVoto(string tecnologia)
        {
            _logger.LogInformation($"Processando voto para a tecnologia: {tecnologia}");
            await _producer.Send(tecnologia);
            _logger.LogInformation($"Informações sobre o voto '{tecnologia}' enviadas para o Azure Event Hubs!");

            TempData["Voto"] = tecnologia;
            return RedirectToAction("Index", "Home");
        }
    }
}