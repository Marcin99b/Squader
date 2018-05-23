using System;

namespace Squader.DomainModel.Advertisements
{
    public class Advertisement
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        public Advertisement(string title, string description)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
        }
    }
}
