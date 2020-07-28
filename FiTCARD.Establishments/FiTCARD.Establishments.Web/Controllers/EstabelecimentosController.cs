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

        [HttpGet]
        public IActionResult Index()
        {
            var resultado = estabelecimentosService.GetList();

            return View(resultado);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("Inserir")]
        public IActionResult Inserir()
        {
            var categorias = categoriasService.GetList();

            return View(categorias);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("Editar")]
        public IActionResult Editar(int id)
        {
            var estabelecimentos = estabelecimentosService.Get(id);
            ViewBag.Estados = categoriasService.GetEstados();

            return View(estabelecimentos);
        }

        [Route("Get"), HttpGet]
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

        [Route("Update"), HttpPut]
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

        [Route("Insert"), HttpPost]
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

        [Route("Delete"), HttpDelete]
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