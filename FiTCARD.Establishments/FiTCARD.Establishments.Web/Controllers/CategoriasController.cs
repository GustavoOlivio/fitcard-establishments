using FiTCARD.Establishments.Service.Categorias;
using Microsoft.AspNetCore.Mvc;

namespace FiTCARD.Establishments.Web.Controllers
{
    [Route("api/[controller]")]
    public class CategoriasController : Controller
    {
        private readonly ICategoriasService categoriasService;

        public CategoriasController(ICategoriasService categoriasService)
        {
            this.categoriasService = categoriasService;
        }

        [Route("Index"), HttpPost]
        public IActionResult Index()
        {
            var resultado = categoriasService.GetList();
            return View();
        }
    }
}