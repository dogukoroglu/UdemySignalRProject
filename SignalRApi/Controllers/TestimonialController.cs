﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialController : ControllerBase
	{
		private readonly ITestimonialService _testimonialService;
		private readonly IMapper _mapper;

		public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
		{
			_testimonialService = testimonialService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult TestimonialList()
		{
			var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
		{
			_testimonialService.TAdd(new Testimonial()
			{
				TestimonialComment = createTestimonialDto.TestimonialComment,
				TestimonialImageUrl = createTestimonialDto.TestimonialImageUrl,
				TestimonialName = createTestimonialDto.TestimonialName,
				TestimonialStatus = createTestimonialDto.TestimonialStatus,
				TestimonialTitle = createTestimonialDto.TestimonialTitle
			});
			return Ok("Müşteri Yorum Bilgisi Başarılı Bir Şekilde Eklendi!");
		}

		[HttpDelete]
		public IActionResult DeleteTestimonial(int id)
		{
			var value = _testimonialService.TGetByID(id);
			_testimonialService.TDelete(value);
			return Ok("Müşteri Yorum Bilgisi Başarılı Bir Şekilde Silindi!");
		}

		[HttpPut]
		public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
		{
			_testimonialService.TUpdate(new Testimonial()
			{
				TestimonialID = updateTestimonialDto.TestimonialID,
				TestimonialComment = updateTestimonialDto.TestimonialComment,
				TestimonialImageUrl = updateTestimonialDto.TestimonialImageUrl,
				TestimonialName = updateTestimonialDto.TestimonialName,
				TestimonialStatus = updateTestimonialDto.TestimonialStatus,
				TestimonialTitle = updateTestimonialDto.TestimonialTitle
			});
			return Ok("Müşteri Yorum Bilgisi Başarılı Bir Şekilde Güncellendi!");
		}

		[HttpGet("GetTestimonial")]
		public IActionResult GetTestimonial(int id)
		{
			var value = _testimonialService.TGetByID(id);
			return Ok(value);
		}
	}
}
