using System;
using Proyecto.Areas.Identity.Data;
namespace Proyecto.Models
{
   
    /// <summary>
    /// Los Clientes de Ignis que representan los dueños de los proyectos. 
    /// 
    /// Principios:
    /// Liskov, polimorfismo 
    /// Un cliente puede ser usado como ApplicationUser y/o IdentityUser, 
    /// ya que Client es un ApplicationUser y ApplicationUser es un IdentityUser,
    /// esto le permite al cliente comportarse como cualquiera de estas.
    /// SRP
    /// Las responsabilidades de un cliente estan unicamente encapsuladas en la clase Client
    /// </summary>
    public class Client : ApplicationUser
    {
        

    }
}