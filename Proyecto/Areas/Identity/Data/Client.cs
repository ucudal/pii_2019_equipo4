using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Proyecto 
{
    public class Client : IdentityUser
    {
        public int ClientID {get;set;}
        
        //requerimientos para el titulo
        [StringLength(60, MinimumLength = 0)]
        [Required]
        public string ClientTitle{get;set;}

        //requerimientos para la descripción
        [StringLength(9, MinimumLength = 0)]
        [Required]
        public int ClientPhone{get;set;}

        [StringLength(120, MinimumLength = 0)]
        [Required]
        public string ClientAddress{get;set;}

    }
}