namespace Squader.DomainModel.Teams
{
    public class TeamRole
    {
        public string Role { get; private set; }
        public bool ChangeUsersRoles { get; private set; }
        public bool DeleteUsers { get; private set; }
        public bool DeleteTeam { get; private set; }

        public static TeamRole Owner = new TeamRole
        {
            Role = "Owner",
            ChangeUsersRoles = true,
            DeleteUsers = true,
            DeleteTeam = true
        };

        public static TeamRole Admin = new TeamRole
        {
            Role = "Admin",
            ChangeUsersRoles = true,
            DeleteUsers = true,
            DeleteTeam = false
        };

        public static TeamRole User = new TeamRole
        {
            Role = "User",
            ChangeUsersRoles = false,
            DeleteUsers = false,
            DeleteTeam = false
        };
    }
}
