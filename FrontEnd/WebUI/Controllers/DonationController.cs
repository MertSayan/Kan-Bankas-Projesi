using Dto.DonationDtos;
using Dto.RegisterDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace WebUI.Controllers
{
    public class DonationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DonationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            var userId = userIdClaim.Value;

            var userNameClaim = User.Claims.FirstOrDefault(x => x.Type == "UserNameSurname");
            var userName = userNameClaim.Value;

            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7072/api/Users/id?id=" + userId);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                
                var value=JsonConvert.DeserializeObject<CreateDonationDto>(jsonData);
                value.NameSurname = userName;
                return View(value);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateDonationDto createDonationDto)
        {
            var userblood = User.Claims.FirstOrDefault(x => x.Type == "BloodTypeId");
            var blood = userblood.Value;
            int bloodTypeId = blood switch
            {
                "A Rh+" => 1,
                "B Rh+" => 2,
                "AB Rh+" => 3,
                "0 Rh+" => 4,
                "A Rh-" => 5,
                "B Rh-" => 6,
                "AB Rh-" => 7,
                "0 Rh-" => 8,
            };

            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            var userId = userIdClaim.Value;

            createDonationDto.UserId = Convert.ToInt32(userId);
            createDonationDto.BloodTypeId = bloodTypeId;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createDonationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7072/api/Donations", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "MainPage");
            }
            return View();
        }
    }
}
