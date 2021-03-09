using System.ComponentModel.DataAnnotations;

namespace KutseApp.Models
{
    public class Guest
    {
        [Required(ErrorMessage = "Sisesta nimi")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Sisesta e-post")]
        [RegularExpression(@".+\@.+\..+", ErrorMessage = "Valesti sisestatud e-mail")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Sisesta telefoninumber")]
        [RegularExpression(@"\+372.+", ErrorMessage = "Numbri alguses peab olema +372")]
        public string Phone { get; set; }
        
        [Required(ErrorMessage = "Sisesta oma valik")]
        public bool? WillAttend { get; set; }
    }
}