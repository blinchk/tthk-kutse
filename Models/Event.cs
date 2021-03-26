using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KutseApp.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Display(Name = "Nimi")]
        public string Title { get; set; }
        [Display(Name = "Kuupäev")]
        public DateTime Date { get; set; }
    }
}
