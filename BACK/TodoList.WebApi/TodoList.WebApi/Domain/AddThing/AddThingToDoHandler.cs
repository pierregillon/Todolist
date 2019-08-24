using System.Threading.Tasks;
using CQRSlite.Commands;
using CQRSlite.Domain;

namespace TodoList.WebApi.Domain.AddThing
{
    public class AddThingToDoHandler : ICommandHandler<AddThingToDo>
    {
        private readonly IRepository _repository;

        public AddThingToDoHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(AddThingToDo command)
        {
            var thing = new ThingToDo(command.Id, command.Description);
            await _repository.Save(thing);
        }
    }
}