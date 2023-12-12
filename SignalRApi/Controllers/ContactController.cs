using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IContactService _contactService;
		private readonly IMapper _mapper;

		public ContactController(IContactService contactService, IMapper mapper)
		{
			_contactService = contactService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ContactList()
		{
			var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateContact(CreateContactDto createContactDto)
		{
			_contactService.TAdd(new Contact()
			{
				ContactLocation = createContactDto.ContactLocation,
				ContactMail = createContactDto.ContactMail,
				ContactPhone = createContactDto.ContactPhone,
				FooterDescription = createContactDto.FooterDescription,
				FooterTitle = createContactDto.FooterTitle,
				OpenDays = createContactDto.OpenDays,
				OpenDaysDescription = createContactDto.OpenDaysDescription,
				OpenHours = createContactDto.OpenHours
			});
			return Ok("İletişim Bilgisi Başarılı Bir Şekilde Eklendi!");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteContact(int id)
		{
			var value = _contactService.TGetByID(id);
			_contactService.TDelete(value);
			return Ok("İletişim Bilgisi Başarılı Bir Şekilde Silindi!");
		}

		[HttpPut]
		public IActionResult UpdateContact(UpdateContactDto updateContactDto)
		{
			_contactService.TUpdate(new Contact()
			{
				ContactID = updateContactDto.ContactID,
				ContactLocation = updateContactDto.ContactLocation,
				ContactMail = updateContactDto.ContactMail,
				ContactPhone = updateContactDto.ContactPhone,
				FooterDescription = updateContactDto.FooterDescription,
				FooterTitle = updateContactDto.FooterTitle,
				OpenDays = updateContactDto.OpenDays,
				OpenDaysDescription = updateContactDto.OpenDaysDescription,
				OpenHours = updateContactDto.OpenHours
			});
			return Ok("İletişim Bilgisi Başarılı Bir Şekilde Güncellendi!");
		}

		[HttpGet("{id}")]
		public IActionResult GetContact(int id)
		{
			var value = _contactService.TGetByID(id);
			return Ok(value);
		}
	}
}
