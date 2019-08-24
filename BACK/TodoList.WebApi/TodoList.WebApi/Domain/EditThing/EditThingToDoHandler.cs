using System;
using System.Threading.Tasks;
using CQRSlite.Commands;
using CQRSlite.Domain;
using CQRSlite.Domain.Exception;

namespace TodoList.WebApi.Domain.EditThing {
    public class EditThingToDoHandler : ICommandHandler<EditThingToDo>
    {
        private readonly IRepository _repository;

        public EditThingToDoHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(EditThingToDo command)
        {
            try {
                var thing = await _repository.Get<ThingToDo>(command.Id);
                thing.Edit(command.NewDescription);
                await _repository.Save(thing);
            }
            catch (AggregateNotFoundException ex) {
                throw new ThingToDoNotFound(command.Id, ex);
            }
        }
    }
}