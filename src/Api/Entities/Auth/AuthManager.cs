using Api.Entities.Default;

namespace Api.Entities.Auth
{
    public class AuthManager : DefaultManager
    {
        private readonly Repository<User> _userRes;

        protected AuthManager(AuthContext authContext) : base(authContext)
        {
            _userRes = new Repository<User>(authContext);
        }
    }
}
