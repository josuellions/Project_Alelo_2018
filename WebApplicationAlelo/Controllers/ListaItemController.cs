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
    public class ListaItemController : Controller
    {
        // GET: ListaItem
        [HttpGet]
        public async Task<ActionResult> ListarItens()
        {
            List<ListaItens> EmpInfo = new List<ListaItens>();


            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://unusualdev.com/api/Lists/getListById/");
                //client.BaseAddress = new Uri(string.Format("http://unusualdev.com/api/Lists/byTypeId/" + id + "/"));

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Lists/getListById");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //EmpInfo = JsonConvert.DeserializeObject<List<ListaItens>>(EmpResponse);
                }
            }
            return View(EmpInfo);

        }
    }
}