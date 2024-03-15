﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalIRWebUI.Dtos.NotificationDtos;
using System.Net.Http;
using System.Text;

namespace SignalIRWebUI.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Notification");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsonData);
                return View(values);    
            }
            return View();
        }

        [HttpGet]   
        public IActionResult CreateNotification()
        {
            return View();
        }
        [HttpPost]  
        public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createNotificationDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7254/api/Notification", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteNotification(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7254/api/Notification/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNotification(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7254/api/Notification/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateNotificationDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateNotificationDto);  
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7254/api/Notification/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

     
		public async Task<IActionResult> NotificationStatusChangeToTrue(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync($"https://localhost:7254/api/Notification/NotificationStatusChangeToTrue/{id}");
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> NotificationStatusChangeToFalse(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync($"https://localhost:7254/api/Notification/NotificationStatusChangeToFalse/{id}");
			return RedirectToAction("Index");
		}
	}
}
