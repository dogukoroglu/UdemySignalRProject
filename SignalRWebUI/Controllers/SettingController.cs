using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
	public class SettingController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		public SettingController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var loginUser = await _userManager.FindByNameAsync(User.Identity.Name);
			UserEditDto userEditDto = new UserEditDto();
			userEditDto.Name = loginUser.Name;
			userEditDto.Surname = loginUser.Surname;
			userEditDto.Username = loginUser.UserName;
			userEditDto.Mail = loginUser.Email;
			return View(userEditDto);
		}

		[HttpPost]
		public async Task<IActionResult> Index(UserEditDto userEditDto)
		{
			if(userEditDto.Password == userEditDto.ConfirmPassword)
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				user.Name = userEditDto.Name;
				user.Surname = userEditDto.Surname;
				user.UserName = userEditDto.Username;
				user.Email = userEditDto.Mail;
				user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditDto.Password);
				await _userManager.UpdateAsync(user);
				return RedirectToAction("Index", "Category");
			}
			return View();
		}
	}
}
