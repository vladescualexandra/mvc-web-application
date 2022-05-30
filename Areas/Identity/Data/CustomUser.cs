using Microsoft.AspNetCore.Identity;

namespace mvc_web_application.Areas.Identity.Data
{
	public class CustomUser : IdentityUser
	{
		[PersonalData]
		public string? Team { get; set; }
	}
}
