using System;

namespace TodoList.WebApi.Domain
{
    public class CannotEditThingDone : Exception
    {
        public CannotEditThingDone(Guid id) : base($"The thing to do with id {id} is done, so can not be edited.") { }
    }
}