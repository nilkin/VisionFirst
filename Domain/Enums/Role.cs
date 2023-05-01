using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Domain.Enums
{
    public enum Role:byte
    {
        [Display(Name = "Admin")]
        Admin = 1,
        [Display(Name = "User")]
        User
    }

}
