namespace Dashboard.SourceControl.Bitbucket.Entities
{
    public class RequestTokenCredentials
    {
        public string TokenSecret { get; set; }

        public string Token { get; set; }

        public bool CallbackConfirmed { get; set; }
    }
}
