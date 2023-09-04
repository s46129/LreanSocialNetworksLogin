using Line.LineSDK;

namespace RexScripts
{
    public class LineLogin : ILogin
    {
        protected override void Login()
        {
            var scopes = new[] { "profile", "openid" };
            LineSDK.Instance.Login(scopes, result =>
            {
                result.Match(
                    value =>
                    {
                        var loginResult = new LoginResult
                        {
                            IsSuccess = true,
                            UserProfile = new UserProfile(value.UserProfile.UserId, value.UserProfile.DisplayName)
                        };
                        LoginManager.OnGetResult(loginResult);
                    },
                    error =>
                    {
                        var loginResult = new LoginResult
                        {
                            IsSuccess = false,
                            Message = error.Message
                        };
                        LoginManager.OnGetResult(loginResult);
                    }
                );
            });
        }
    }
}