using PeliculaCFHN.EntidadeDeNegocio;

namespace PeliculaCFHN.WebAPI.Auth
{
    public interface IJwtAuthenticationService
    {
        String Authenticate(Usuario pUsuario);
    }
}
