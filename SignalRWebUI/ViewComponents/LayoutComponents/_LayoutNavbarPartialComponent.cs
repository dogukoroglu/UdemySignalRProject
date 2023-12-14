using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;

namespace SignalRWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutNavbarPartialComponent : ViewComponent
	{
		private readonly UserManager<AppUser> _userManager;
		public _LayoutNavbarPartialComponent(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var loginUser = await _userManager.FindByNameAsync(User.Identity.Name);
			ViewBag.userUsername = loginUser.UserName;
			ViewBag.userName = loginUser.Name;
			ViewBag.userEmailAddress = loginUser.Email;
			return View();
		}
	}
}
