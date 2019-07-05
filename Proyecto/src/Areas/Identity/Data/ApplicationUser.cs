using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Areas.Identity.Data
{
    /// <summary>
    /// Representa un usuario de la aplicacion, esta clase hereda de IdentityUser, 
    /// son clases de manejo de usuarios para ABM/login del sistema
    /// 
    /// Principios:
    /// Liskov, polimorfismo 
    /// Un ApplicationUser es un IdentityUser, esto le permite a esta clase comportarse como un IdentityUser.
    /// SRP
    /// Las responsabilidades de un usuario de la aplicacion estan unicamente encapsuladas en esta clase 
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [PersonalData]
        public DateTime BirthDate { get; set; }
        
        // Es necesario tener acceso a IdentityManager para poder buscar el rol de este usuario; esta propiedad se asigna cada vez que se
        // cambia el rol usando IdentityManager para poder buscar por rol después cuando no hay acceso a IdentityManager. La propiedad
        // puede ser null para los usuarios que todavía no tienen un rol asignado.
        public string Role { get;private set; }

        // El IdentityManager que se recibe como argumento no se usa en el método; sólo fuera a que el rol del usuario sea cambiado cuando
        // existe en el contexto una instancia válida de IdentityManager.
        public void AssignRole(UserManager<ApplicationUser> identityManager, string role)
        {
            if (identityManager == null)
            {
                throw new ArgumentNullException("identityManager");
            }

            this.Role = role;
        }
    
    }
}