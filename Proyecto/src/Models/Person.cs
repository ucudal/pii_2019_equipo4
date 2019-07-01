using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Proyecto.Models
{
    /*
    Principios
    Principio de sustitución de Liskov:por cada objeto de la clase Person 
    hay un objeto Technician y otro objeto Client.
    Open/Closed: abierta a la modificacion y cerrada a la modificacion

     Person: Clase abstracta, Technician y Client heredan de ella */
    public class Person
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}