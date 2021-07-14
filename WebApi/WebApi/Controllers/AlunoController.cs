using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel.Interfaces.Domains;
using DomainModel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/aluno")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IDomainAluno _domAluno;

        public AlunoController(IDomainAluno domAluno)
        {
            _domAluno = domAluno;
        }
        [HttpGet]
        //[Route("GetTeste")]
        public ActionResult<List<AlunoDTO>> Get()
        {
            try
            {
                return Ok(_domAluno.GetAll());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteById/{Id}")]
        public IActionResult DeleteById(int Id)
        {
            try
            {
                _domAluno.deleteById(Id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
       // [Route("DeleteById/{Id}")]
        public IActionResult Post(AlunoDTO aluno)
        {
            try
            {
                _domAluno.salvarAluno(aluno);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetById/{Id}")]
        public ActionResult<AlunoDTO> GetById(int Id)
        {
            try
            {
                return Ok(_domAluno.GetById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        // [Route("DeleteById/{Id}")]
        public IActionResult Put(AlunoDTO aluno)
        {
            try
            {
                _domAluno.AlterarAluno(aluno);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
