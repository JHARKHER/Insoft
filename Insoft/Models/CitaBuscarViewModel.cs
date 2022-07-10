using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insoft.Models
{
    public class CitaBuscarViewModel
    {
        [Required (ErrorMessage = "El campo placa es obligatorio")]
        public string Placa { get; set; }

       
    }
}
