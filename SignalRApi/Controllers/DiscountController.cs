using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DiscountController : ControllerBase
	{
		private readonly IDiscountService _discountService;
		private readonly IMapper _mapper;

		public DiscountController(IDiscountService discountService, IMapper mapper)
		{
			_discountService = discountService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult DiscountList()
		{
			var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
		{
			_discountService.TAdd(new Discount()
			{
				DiscountAmount = createDiscountDto.DiscountAmount,
				DiscountDescription = createDiscountDto.DiscountDescription,
				DiscountImageUrl = createDiscountDto.DiscountImageUrl,
				DiscountTitle = createDiscountDto.DiscountTitle
			});
			return Ok("İndirim Bilgisi Başarılı Bir Şekilde Eklendi!");
		}

		[HttpDelete]
		public IActionResult DeleteDiscount(int id)
		{
			var value = _discountService.TGetByID(id);
			_discountService.TDelete(value);
			return Ok("İnidirim Bilgisi Başarılı Bir Şekilde Silindi!");
		}

		[HttpPut]
		public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
		{
			_discountService.TUpdate(new Discount()
			{
				DiscountID = updateDiscountDto.DiscountID,
				DiscountAmount = updateDiscountDto.DiscountAmount,
				DiscountDescription = updateDiscountDto.DiscountDescription,
				DiscountImageUrl = updateDiscountDto.DiscountImageUrl,
				DiscountTitle = updateDiscountDto.DiscountTitle
			});
			return Ok("İndirim Bilgisi Başarılı Bir Şekilde Güncellendi!");
		}

		[HttpGet("GetDiscount")]
		public IActionResult GetDiscount(int id)
		{
			var value = _discountService.TGetByID(id);
			return Ok(value);
		}
	}
}
