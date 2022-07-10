using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insoft.Models
{
    public class CitaGuardarViewModel
    {
        

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El Estado es obligatorio")]
        public string Estado { get; set; }
    }
}
