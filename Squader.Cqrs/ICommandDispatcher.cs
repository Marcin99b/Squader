﻿using System.Threading.Tasks;

namespace Squader.Cqrs
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : ICommand;
    }
}
