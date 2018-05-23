using System;
using ICommand = Squader.Cqrs.ICommand;

namespace Squader.DomainModel.Advertisements.Commands
{
    public class GetAdvertisementById : ICommand
    {
        public Guid Id { get; private set; }

        public GetAdvertisementById(Guid id)
        {
            Id = id;
        }
    }
}
