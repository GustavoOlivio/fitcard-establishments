using FiTCARD.Establishments.Model.Estabelecimentos;
using FiTCARD.Establishments.Service.Categorias;
using FiTCARD.Establishments.Service.Estabelecimentos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FiTCARD.Establishments.Web.Controllers
{
    [Route("api/[controller]")]
    public class EstabelecimentosController : Controller
    {
        private readonly IEstabelecimentosService estabelecimentosService;
        private readonly ICategoriasService categoriasService;

        public EstabelecimentosController(IEstabelecimentosService estabelecimentosService, ICategoriasService categoriasService)
        {
            this.estabelecimentosService = estabelecimentosService;
            this.categoriasService = categoriasService;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("Index"), HttpGet]
        public IActionResult Index()
        {
            var resultado = estabelecimentosService.GetList();

            return View(resultado);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("Inserir"), HttpGet]
        public IActionResult Inserir()
        {
            var categorias = categoriasService.GetList();

            return View(categorias);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("Editar"), HttpGet]
        public IActionResult Editar(int id)
        {
            var estabelecimentos = estabelecimentosService.Get(id);
            ViewBag.Estados = categoriasService.GetEstados();

            return View(estabelecimentos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var resultado = estabelecimentosService.Get(id);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var resultado = estabelecimentosService.GetList();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] EstabelecimentosModel estabelecimentos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    estabelecimentosService.Update(estabelecimentos);

                    return Ok(estabelecimentos);
                }
                else
                    return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody] EstabelecimentosModel estabelecimentos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    estabelecimentos.Id = estabelecimentosService.Insert(estabelecimentos);

                    return Ok(estabelecimentos);
                }
                else
                    return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                estabelecimentosService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}