using Microsoft.AspNetCore.Identity;

namespace DigitalShop.Models;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; }
}
