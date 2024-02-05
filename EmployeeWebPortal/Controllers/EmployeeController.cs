using DotNetMVCCore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Json.Serialization;

namespace DotNetMVCCore.Controllers
{
    public class EmployeeController : Controller
    {
        Uri baseurl = new Uri("https://localhost:7085/api");

        private readonly HttpClient _httpClient;

        public EmployeeController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseurl;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<EmployeeModelView> EmployeeList = new List<EmployeeModelView>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Employee/Get").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                EmployeeList = JsonConvert.DeserializeObject<List<EmployeeModelView>>(data);
            }

            return View(EmployeeList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeModelView model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "/Employee/Post", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Employee Created!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["SuccessMessage"] = ex.Message;
                return View();
            }

            return View();
        }
    }
}
