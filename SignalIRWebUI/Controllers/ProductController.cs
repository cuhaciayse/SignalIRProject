using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalIRWebUI.Dtos.CategoryDtos;
using SignalIRWebUI.Dtos.ProductDtos;
using System.Net.Http;
using System.Text;

namespace SignalIRWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Product/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData); 
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Category");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> values2 = (from x in values
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                            }).ToList(); 
            ViewBag .v = values2;
            return View();  
        }

        [HttpPost]  
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            createProductDto.ProductStatus = true;
            var client= _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);  
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7254/api/Category", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteProduct (int id)
        {
            var client= _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7254/api/Category");
			if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();  

		}

		[HttpGet]
		public async Task<IActionResult> UpdateProduct(int id)
		{

			var client1 = _httpClientFactory.CreateClient();
			var responseMessage1 = await client1.GetAsync("https://localhost:7254/api/Category");
			var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
			var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1);
			List<SelectListItem> values2 = (from x in values1
											select new SelectListItem
											{
												Text = x.CategoryName,
												Value = x.CategoryID.ToString()
											}).ToList();
			ViewBag.v = values2;


			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7254/api/Product/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProduct)
        {
            updateProduct.ProductStatus = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProduct);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7254/api/Product/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");   
            }
            return View();
        }
	}
}
