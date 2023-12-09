﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BookingDto;
using System.Net.Http;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BookTableController : Controller
	{
        private readonly IHttpClientFactory _httpClientFactory;
        public BookTableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
		public IActionResult Index()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7245/api/Booking", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            return View();
        }
    }
}
