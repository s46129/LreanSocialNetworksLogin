namespace RexScripts
{
    public class UserProfile
    {
        public readonly string UserId;
        public readonly string UserName;

        public UserProfile(string userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }
    }
}