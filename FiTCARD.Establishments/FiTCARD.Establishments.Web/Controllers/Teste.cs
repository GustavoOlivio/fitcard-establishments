using Microsoft.AspNetCore.Mvc;

namespace FiTCARD.Establishments.Web.Controllers
{
    /// <summary>
    /// Test Controller
    /// </summary>
    [Route("api/[controller]")]
    public class Teste : Controller
    {
        /// <summary>
        /// Test
        /// </summary>
        /// <returns></returns>
        [Route("Index"), HttpPost]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}