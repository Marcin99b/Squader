namespace Squader.DomainModel.Teams
{
    public class TeamRole
    {
        public int Id { get; private set; }
        public string Role { get; private set; }
        public bool ChangeUsersRoles { get; private set; }
        public bool DeleteUsers { get; private set; }
        public bool DeleteTeam { get; private set; }

        public static TeamRole Owner = new TeamRole
        {
            Id = 0,
            Role = "Owner",
            ChangeUsersRoles = true,
            DeleteUsers = true,
            DeleteTeam = true
        };

        public static TeamRole Admin = new TeamRole
        {
            Id = 1,
            Role = "Admin",
            ChangeUsersRoles = true,
            DeleteUsers = true,
            DeleteTeam = false
        };

        public static TeamRole User = new TeamRole
        {
            Id = 2,
            Role = "User",
            ChangeUsersRoles = false,
            DeleteUsers = false,
            DeleteTeam = false
        };
    }
}
