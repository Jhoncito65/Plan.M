using System;
using System.ComponentModel.DataAnnotations;

namespace Trabajo.Api.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        
        public string Nam_Employe { get; set; }

      
        public string Las_Employe { get; set; }

       
        public string Pos_Employe { get; set; }

        public DateTime Dat_Employe { get; set; } = DateTime.Now;
    }
}
