using System;
using GooglePlayGames;

namespace RexScripts
{
    public class GoogleLogin : ILogin
    {
        private void Start()
        {
            PlayGamesPlatform.Activate();
        }

        protected override void Login()
        {
            PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
        }

        private void ProcessAuthentication(bool isSuccess)
        {
            if (isSuccess)
            {
                var loginResult = new LoginResult
                {
                    IsSuccess = true,
                    UserProfile = new UserProfile(PlayGamesPlatform.Instance.localUser.id,
                        PlayGamesPlatform.Instance.localUser.userName),
                    Message = "Login Google Play Games success."
                };
                LoginManager.OnGetResult(loginResult);
            }
            else
            {
                var loginResult = new LoginResult
                {
                    IsSuccess = false,
                    Message = "Login Google Play Games failed."
                };
                LoginManager.OnGetResult(loginResult);
            }
        }
    }
}