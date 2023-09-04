using UnityEngine;

namespace RexScripts
{
    public class UnityLogin : ILogin
    {
        protected override void Login()
        {
            Social.localUser.Authenticate(success =>
            {
                var loginResult = success
                    ? new LoginResult
                    {
                        IsSuccess = true,
                        UserProfile = new UserProfile(Social.localUser.id, Social.localUser.userName)
                    }
                    : new LoginResult
                    {
                        IsSuccess = false,
                        Message = "Login Unity Social failed."
                    };

                LoginManager.OnGetResult(loginResult);
            });
        }
    }
}