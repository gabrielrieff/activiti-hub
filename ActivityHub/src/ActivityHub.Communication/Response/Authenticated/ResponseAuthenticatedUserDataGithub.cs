namespace ActivityHub.Communication.Response.Authenticated
{
    public class ResponseAuthenticatedUserDataGithub
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string avatar_url { get; set; } = string.Empty;
    }
}
