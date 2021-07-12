using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel.Interfaces.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DomainModel.Model;

namespace WebApi.Controllers
{
    [Route("api/Teste")]
    [ApiController]
    public class Teste : ControllerBase
    {
        private readonly IDomainTeste _domTeste;

        public Teste(IDomainTeste domTeste)
        {
            _domTeste = domTeste;
        }
        [HttpGet]
        //[Route("GetTeste")]
        public ActionResult<TesteDTO> Get()
        {
            try
            {
                return Ok(_domTeste.GetTeste());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        //[Route("GetTeste")]
        public IActionResult Post(TesteDTO teste)
        {
            try
            {
                return Ok(teste);
                //return Ok(_domTeste.GetTeste());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
