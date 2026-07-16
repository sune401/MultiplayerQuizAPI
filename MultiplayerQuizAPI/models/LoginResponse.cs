namespace MultiplayerQuizAPI.models
{
    public class LoginResponse
    {
        public string token { get; set; }
        public string username { get; set; }
        public bool success { get; set; }
    }
}
