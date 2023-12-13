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
				DiscountTitle = createDiscountDto.DiscountTitle,
				DiscountStatus = false
			});
			return Ok("İndirim Bilgisi Başarılı Bir Şekilde Eklendi!");
		}

		[HttpDelete("{id}")]
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
				DiscountTitle = updateDiscountDto.DiscountTitle,
				DiscountStatus = false
			});
			return Ok("İndirim Bilgisi Başarılı Bir Şekilde Güncellendi!");
		}

		[HttpGet("{id}")]
		public IActionResult GetDiscount(int id)
		{
			var value = _discountService.TGetByID(id);
			return Ok(value);
		}

		[HttpGet("ChangeStatusTrue/{id}")]
		public IActionResult ChangeStatusTrue(int id)
		{
			_discountService.TChangeStatusToTrue(id);
			return Ok("Ürün İndirimi Aktif Hale Getirildi!");
		}

		[HttpGet("ChangeStatusFalse/{id}")]
		public IActionResult ChangeStatusFalse(int id)
		{
			_discountService.TChangeStatusToFalse(id);
			return Ok("Ürün İndirimi Pasif Hale Getirildi!");
		}

		[HttpGet("GetListByStatusTrue")]
		public IActionResult GetListByStatusTrue()
		{
			return Ok(_discountService.TGetListByStatusTrue());
		}
	}
}
