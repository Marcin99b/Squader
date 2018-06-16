using System;

namespace Squader.DomainModel.Teams
{
    public class UserTeam
    {
        public Guid UserId { get; private set; }
        public string TeamRole { get; private set; }
        public DateTime ChangedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
