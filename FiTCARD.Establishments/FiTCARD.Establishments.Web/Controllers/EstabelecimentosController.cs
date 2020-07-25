using FiTCARD.Establishments.Model.Estabelecimentos;
using FiTCARD.Establishments.Service.Estabelecimentos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FiTCARD.Establishments.Web.Controllers
{
    [Route("api/[controller]")]
    public class EstabelecimentosController : Controller
    {
        private readonly IEstabelecimentosService estabelecimentosService;

        public EstabelecimentosController(IEstabelecimentosService estabelecimentosService)
        {
            this.estabelecimentosService = estabelecimentosService;
        }

        [Route("GetList"), HttpGet]
        public IActionResult GetList()
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

        [Route("Update"), HttpPost]
        public IActionResult Update([FromBody] EstabelecimentosModel estabelecimentos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    estabelecimentosService.Update(estabelecimentos);

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
        public IActionResult Insert([FromBody] EstabelecimentosModel estabelecimentos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var categoriaid = estabelecimentosService.Insert(estabelecimentos);

                    return Ok(categoriaid);
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