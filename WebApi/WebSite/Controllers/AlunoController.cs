using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class AlunoController : Controller
    {
        HttpClient cliente = new HttpClient();
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Consultar()
        {

         
            
            var resultado= await cliente.GetAsync("https://localhost:44355/api/aluno");
            List<AlunoDTO> alunos = JsonConvert.DeserializeObject<List<AlunoDTO>>(resultado.Content.ReadAsStringAsync().Result);
            return View(alunos);
        }

        [HttpPost]
        public async Task<ActionResult> excluirAluno(int id)
        {
            try
            {

                //var json = JsonConvert.SerializeObject(refund);
                //var conteudo = new StringContent(json, Encoding.UTF8, "application/json");
                //var resposta = await cliente.PostAsync(URL_INSERE_REEMBOLSO, conteudo);

                string url = string.Format("https://localhost:44355/api/aluno/DeleteById/{0}", id);
                var resposta = await cliente.DeleteAsync(url);

                if (resposta.StatusCode == HttpStatusCode.OK)
                {
                    return Json(new
                    {
                        Status = true,
                        Mensagem = "Aluno excluido com sucesso"
                    });
                }
                else
                    throw new Exception(resposta.Content.ReadAsStringAsync().Result);

            }
           
            catch (Exception ex)
            {
                return Json(new { Status = false, Mensagem = ex.Message });
            }
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
      
        public IActionResult CadastrarAluno(AlunoDTO aluno)
        {
            try
            {
                throw new Exception("erro para cadastrar");
              
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return RedirectToAction("Cadastrar");
            }
            
        }
        [HttpPost]
        public ActionResult CadastrarAlunoAjax(AlunoDTO aluno)
        {
            string mensagem = "";
            try
            {
                if (string.IsNullOrEmpty(aluno.nome))
                {
                    mensagem += "-é necessário informar o nome   " ;
                }
                if (string.IsNullOrEmpty(aluno.sobrenome))
                {
                    mensagem += "-é necessário informar o sobrenome   " ;
                }
                if (string.IsNullOrEmpty(aluno.email))
                {
                    mensagem +=  "-é necessário informar o email   ";
                }
                if (!aluno.dt_nascimento.HasValue)
                {
                    mensagem += "-é necessário informar a data de nascimento   ";
                }

                if (!string.IsNullOrEmpty(mensagem))
                {
                    throw new Exception(mensagem);
                }

                return Json(new
                {
                    Status = true,
                    Mensagem = "Aluno cadastrado com sucesso"
                });
            }
            catch (Exception ex )
            {

                return Json(new
                {
                    Status = false,
                    Mensagem = ex.Message
                });
            }
        
           
        }
    }
}
