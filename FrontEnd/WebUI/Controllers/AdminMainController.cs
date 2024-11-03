using Dto.AdminUser;
using Dto.StockDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Controllers
{
    public class AdminMainController : Controller
    {
        IHttpClientFactory _httpClientFactory;

        public AdminMainController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SeeAllUser()
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7072/api/Users");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values= JsonConvert.DeserializeObject<List<GetAllUserDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> Stock()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7072/api/BloodStocks");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetAllStock>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
