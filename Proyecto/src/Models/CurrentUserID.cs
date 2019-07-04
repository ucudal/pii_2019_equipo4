using Proyecto;
using Proyecto.Areas.Identity.Data;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Proyecto.Models
{
    /*Esta clase permite obtener el ID del usuario que esta en la pagina
     */
    public static class CurrentUserID
    {
        public static string GetUserID(this ClaimsPrincipal user)
        {
            if(!user.Identity.IsAuthenticated)
            {
                return null;
            }
            ClaimsPrincipal currentUser = user;
            return currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

    }
}