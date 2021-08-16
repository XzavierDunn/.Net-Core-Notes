using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationTutorial.Services.Authentication
{
    public interface IRefreshTokenGenerator
    {
        string GenerateToken();
    }
}
