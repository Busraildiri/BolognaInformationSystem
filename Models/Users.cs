namespace BolognaInformationSystem.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string TCIdentityNumber { get; set; }
        public string PasswordHash { get; set; }
        public string UserType { get; set; }
    }

}
