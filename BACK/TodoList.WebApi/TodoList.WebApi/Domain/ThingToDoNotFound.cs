using System;
using CQRSlite.Domain.Exception;

namespace TodoList.WebApi.Domain
{
    public class ThingToDoNotFound : Exception
    {
        public ThingToDoNotFound(Guid id, AggregateNotFoundException innerException) : base($"The thing to do with id {id} was not found.", innerException) { }
    }
}