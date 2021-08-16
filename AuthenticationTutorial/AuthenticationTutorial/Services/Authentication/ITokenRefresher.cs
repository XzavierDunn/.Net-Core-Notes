using AuthenticationTutorial.Models;

namespace AuthenticationTutorial.Services.Authentication
{
    public interface ITokenRefresher
    {
        AuthenticationResponse Refresh(RefreshCred refreshCred);
    }
}