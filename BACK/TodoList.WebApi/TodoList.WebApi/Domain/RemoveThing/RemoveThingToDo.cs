using System;
using CQRSlite.Commands;

namespace TodoList.WebApi.Domain.RemoveThing {
    public class RemoveThingToDo : ICommand
    {
        public Guid Id { get; }

        public RemoveThingToDo(Guid id)
        {
            Id = id;
        }
    }
}