﻿using FiTCARD.Establishments.Model.Categorias;
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

        
        [Route("GetList"), HttpGet]
        public IActionResult GetList()
        {
            try
            {
                var resultado = categoriasService.GetList();

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
                var resultado = categoriasService.Get(id);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [Route("Update"), HttpPost]
        public IActionResult Update([FromBody]CategoriasModel categoria)
        {
            try
            {
                categoriasService.Update(categoria);

                return Ok();
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
                var categoriaid = categoriasService.Insert(categoria);

                return Ok(categoriaid);
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