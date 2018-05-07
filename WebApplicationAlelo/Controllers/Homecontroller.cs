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
    public class Homecontroller : Controller
    {
        // GET: Homecontroller
        //Host web API REST Service base url
        string Baseurl = "http://unusualdev.com/api/Lists/listTypes/";
        public async Task<ActionResult> Index()
        {
            List<Categoria> EmpInfo = new List<Categoria>();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(Baseurl);

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
    }
}
