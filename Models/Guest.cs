using System.ComponentModel.DataAnnotations;

namespace KutseApp.Models
{
    public class Guest
    {
        public int Id { get; set; }
        
        [Display(Name="Nimi")]
        [Required(ErrorMessage = "Sisesta nimi")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Sisesta e-post")]
        [RegularExpression(@".+\@.+\..+", ErrorMessage = "Valesti sisestatud e-mail")]
        [Display(Name = "E-post")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Sisesta telefoninumber")]
        [RegularExpression(@"\+372.+", ErrorMessage = "Numbri alguses peab olema +372")]
        [Display(Name = "Telefoninumber")]
        public string Phone { get; set; }
        
        [Required(ErrorMessage = "Sisesta oma valik")]
        [Display(Name = "Osaleb?")]
        public bool? WillAttend { get; set; }
    }
}