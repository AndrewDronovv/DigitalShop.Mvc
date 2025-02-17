using Microsoft.AspNetCore.Identity;

namespace DigitalShop.Mvc.Models;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; }
}
