namespace Squader.Api.Areas.Users.Dtos
{
    public class CreateUserRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
    }
}
