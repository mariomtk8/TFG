using RecetasRedondas.Models;
using System.Security.Claims;
namespace RecetasRedondas.Data;
public interface IAuthService
{
    //Auth

    string GenerateJwtToken(Usuario usuario);
    public bool HasAccessToResource(ClaimsPrincipal user, int resourceOwnerId);
}