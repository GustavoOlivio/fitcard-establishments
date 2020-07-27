using FiTCARD.Establishments.Model.Categorias;
using FiTCARD.Establishments.Service.Categorias;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpGet]
        public IActionResult Index()
        {
            var resultado = categoriasService.GetList();

            return View(resultado);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("Inserir")]
        public IActionResult Inserir()
        {
            return View();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("Editar")]
        public IActionResult Editar(int id)
        {
            var categoria = categoriasService.Get(id);

            return View(categoria);
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var resultado = categoriasService.Get(id);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Update"), HttpPut]
        public IActionResult Update([FromBody] CategoriasModel categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoriasService.Update(categoria);
                    return Ok();
                }
                else
                    return BadRequest(ModelState);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Insert"), HttpPost]
        public IActionResult Insert([FromBody] CategoriasModel categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var categoriaid = categoriasService.Insert(categoria);

                    return Ok(categoria);
                }
                else
                    return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Delete"), HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                categoriasService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}