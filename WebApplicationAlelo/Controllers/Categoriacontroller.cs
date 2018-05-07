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
    public class Categoriacontroller : Controller
    {
        // GET: Categoriacontroller
        //Host web API REST Service base url
        [HttpGet]
        public async Task<ActionResult> ListarCategoria()
        {
            List<Categoria> EmpInfo = new List<Categoria>();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://unusualdev.com/api/Lists/listTypes/");

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("api/Lists/GetAlllistTypes");

                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        EmpInfo = JsonConvert.DeserializeObject<List<Categoria>>(EmpResponse);
                    }

                    return View(EmpInfo);
                }
                catch (Exception erro)
                {
                    TempData.Add("Erro", erro.Message);
                    return View();
                }
            }
        }

        [HttpGet]
        public async Task<ActionResult> ListarDetalhada(int id)
        {
            List<CategoriaLista> EmpInfo = new List<CategoriaLista>();
            using (var client = new HttpClient())
            {
                try
                {
                //client.BaseAddress = new Uri(BaseUrlList);
                //client.BaseAddress = new Uri(string.Format(BaseUrlList, 2));
                client.BaseAddress = new Uri(string.Format("http://unusualdev.com/api/Lists/byTypeId/" + id + "/"));

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Lists/GetAllbyTypeId");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    EmpInfo = JsonConvert.DeserializeObject<List<CategoriaLista>>(EmpResponse);
                }

                return View(EmpInfo);
                }
                catch (Exception erro)
                {
                    TempData.Add("Erro", erro.Message);
                    return View();
                }
            }
        }
        public ActionResult NovaLista()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NovaLista(FormCollection dados)
        {
            try
            {
                var novoCadastro = new CategoriaLista();

                novoCadastro.TypeId = Convert.ToInt32(dados["TypeId"]);
                novoCadastro.Name = dados["Name"];
                novoCadastro.Status = Convert.ToInt32(dados["Status"]);

                var mensag = "TypeId = " + novoCadastro.TypeId.ToString() + " | Name = " + novoCadastro.Name.ToString() + " | Status = " + novoCadastro.Status.ToString();

                TempData.Add("Sucesso", "Cadastro realizado com sucesso! " + mensag.ToString());

                return View("NovaLista");
            }
            catch (Exception erro)
            {
                TempData.Add("Erro", erro.Message);
                return View();
            }
        }
        /*
        [HttpPost]
        public ActionResult Cadastrar(FormCollection dados)
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