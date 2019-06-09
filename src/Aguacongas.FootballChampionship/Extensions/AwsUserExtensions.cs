namespace Aguacongas.AwsServices
{
    public static class AwsUserExtensions
    {
        public static bool IsAdmin(this AwsUser user)
        {
            return user.SignInUserSession.IdToken.Payload.Groups.Contains("Admin");
        }
    }
}
