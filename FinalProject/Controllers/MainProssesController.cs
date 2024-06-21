using FinalProject.DTO;
using FinalProject.Store;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Interfaces;


namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainProssesController : ControllerBase
    {
        private readonly IMainProsses mp;
        public MainProssesController(IMainProsses mp)
        {
            this.mp = mp;
        }
        [HttpGet]
        public ActionResult<List<ResultDto>> Get(string id)
        {
            var finalyResult = mp.FuncRun(id);
            return finalyResult;
        }
    }
}
