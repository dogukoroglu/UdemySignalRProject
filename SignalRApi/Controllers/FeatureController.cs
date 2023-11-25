using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeatureController : ControllerBase
	{
		private readonly IFeatureService _featureService;
		private readonly IMapper _mapper;

		public FeatureController(IFeatureService featureService, IMapper mapper)
		{
			_featureService = featureService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult FeatureList()
		{
			var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
		{
			_featureService.TAdd(new Feature()
			{
				FeatureDescription1 = createFeatureDto.FeatureDescription1,
				FeatureDescription2 = createFeatureDto.FeatureDescription2,
				FeatureDescription3 = createFeatureDto.FeatureDescription3,
				FeatureTitle1 = createFeatureDto.FeatureTitle1,
				FeatureTitle2 = createFeatureDto.FeatureTitle2,
				FeatureTitle3 = createFeatureDto.FeatureTitle3
			});
			return Ok("Öne Çıkan Bilgisi Başarılı Bir Şekilde Eklendi!");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteFeature(int id)
		{
			var value = _featureService.TGetByID(id);
			_featureService.TDelete(value);
			return Ok("Öne Çıkan Bilgisi Başarılı Bir Şekilde Silindi!");
		}

		[HttpPut]
		public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
		{
			_featureService.TUpdate(new Feature()
			{
				FeatureID = updateFeatureDto.FeatureID,
				FeatureDescription1 = updateFeatureDto.FeatureDescription1,
				FeatureDescription2 = updateFeatureDto.FeatureDescription2,
				FeatureDescription3 = updateFeatureDto.FeatureDescription3,
				FeatureTitle1 = updateFeatureDto.FeatureTitle1,
				FeatureTitle2 = updateFeatureDto.FeatureTitle2,
				FeatureTitle3 = updateFeatureDto.FeatureTitle3
			});
			return Ok("Öne Çıkan Bilgisi Başarılı Bir Şekilde Güncellendi!");
		}

		[HttpGet("{id}")]
		public IActionResult GetFeature(int id)
		{
			var value = _featureService.TGetByID(id);
			return Ok(value);
		}
	}
}
