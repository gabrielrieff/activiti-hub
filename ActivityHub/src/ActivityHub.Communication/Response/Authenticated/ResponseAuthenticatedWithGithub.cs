namespace ActivityHub.Communication.Response.Authenticated
{
    public class ResponseAuthenticatedWithGithub
    {
        public string access_token { get; set; } = string.Empty;
        public string token_type { get; set; } = string.Empty;
        public string scope { get; set; } = string.Empty;
    }
}
