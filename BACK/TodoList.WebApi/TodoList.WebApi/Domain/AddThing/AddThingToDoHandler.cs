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

        public async Task Handle(AddThingToDo message)
        {
            var thing = new ThingToDo(message.Description);
            await _repository.Save(thing);
        }
    }
}