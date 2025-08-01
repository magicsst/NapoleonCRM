using System.ComponentModel.DataAnnotations;

namespace NapoleonCRM.Shared.Models;

public class ApplicationUserWithRolesDto : ApplicationUserDto
{
    public List<string>? Roles { get; set; }
}
