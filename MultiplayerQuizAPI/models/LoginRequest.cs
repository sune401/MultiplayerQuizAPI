namespace MultiplayerQuizAPI.models
{
    public class LoginRequest
    {
        public int id { get; set; }
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string passwordHash { get; set; }
        public string password { get; set; }
    }
}
