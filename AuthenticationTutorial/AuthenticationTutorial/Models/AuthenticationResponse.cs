using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationTutorial.Models
{
    public class AuthenticationResponse
    {
        public string token { get; set; }
        public string refreshToken { get; set; }
    }
}
