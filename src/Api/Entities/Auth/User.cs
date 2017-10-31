using Api.Entities.Default;
using System;
using System.Security.Principal;

namespace Api.Entities.Auth
{
    public class User : DefaultEntity, IIdentity
    {
        public string Email { get; set; }
        public string Name { get; set; }

        public string AuthenticationType => throw new NotImplementedException();
        public bool IsAuthenticated => false;
    }
}