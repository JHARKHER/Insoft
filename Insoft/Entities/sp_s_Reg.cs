using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insoft.Entities
{
    public class sp_s_Reg
    {

        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(22)")]
        public string Placa { get; set; }

        public DateTime Fecha { get; set; }     

        [Column(TypeName = "varchar(22)")]
        public string Estado { get; set; }

        

      
    }

}
