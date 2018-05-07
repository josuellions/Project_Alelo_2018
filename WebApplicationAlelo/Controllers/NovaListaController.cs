using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using alelo.model.web;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebApplicationAlelo.Controllers
{
    public class NovaListaController : Controller
    {
        // GET: NovaLista
        public ActionResult NovaLista()
        {
            return View();
        }
        /*
        [HttpPost]
        public ActionResult Cadastrar( FormCollection dados)
        {
            try
            {
                var novoCadastro = new CategoriaLista();

                novoCadastro.TypeId = Convert.ToInt32(dados["novalista"]);
                novoCadastro.Name = dados["Name"];
                novoCadastro.Status = Convert.ToInt32(dados["Status"]);

                var mensag = novoCadastro.TypeId.ToString() + novoCadastro.Name.ToString() + novoCadastro.Status.ToString();

                TempData.Add("Sucesso", "Cadastro realizado com sucesso!" + mensag.ToString());

                return View("Cadastrar");
            }
            catch (Exception erro)
            {
                TempData.Add("Erro", erro.Message);
                return View("Cadastrar");
            }
           

        }
        */
    }
}