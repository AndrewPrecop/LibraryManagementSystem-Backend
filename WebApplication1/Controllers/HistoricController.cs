using Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricController : ControllerBase
    {
        private readonly IHistoricRepository historicRepository;

        public HistoricController(IHistoricRepository historicRepository)
        {
            this.historicRepository = historicRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var historic = historicRepository.GetAll();

            return Ok(historic);
        }
    }
}
