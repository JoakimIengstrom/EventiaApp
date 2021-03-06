using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "UserAttendee, UserAdmin")]
    public class OrganizerRequestModel : PageModel
    {
        private readonly UserManager<EventiaUser> _userManager;
        private readonly UserService _userService;

        public OrganizerRequestModel(UserManager<EventiaUser> userManager, UserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        public void OnGet() {}

        public async Task OnPost()
        {
            var activeUser = _userManager.GetUserId(User);
            await _userService.RequestToBeAnOrganizer(activeUser);

        }
    }
}
