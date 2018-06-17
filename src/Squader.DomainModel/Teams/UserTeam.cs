using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Squader.DomainModel.Users;

namespace Squader.DomainModel.Teams
{
    public class UserTeam
    {
        [Key]
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public int TeamRoleId { get; private set; }
        public DateTime ChangedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Deleted { get; private set; }

        [NotMapped]
        public TeamRole Role { get; private set; }

        private UserTeam() { }

        public UserTeam(User user, TeamRole role)
        {
            UserId = user.Id;
            SetRole(role);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetRole(TeamRole role)
        {
            if (role == null)
            {
                return;
            }
            Role = role;
            UpdateVersion();
        }

        public void UpdateVersion()
        {
            ChangedAt = DateTime.UtcNow;
        }

        public void Delete()
        {
            Deleted = true;
        }
    }
}
