using System.Threading.Tasks;
using CQRSlite.Commands;
using CQRSlite.Domain;

namespace TodoList.WebApi.Domain.RemoveThing
{
    public class RemoveThingToDoHandler : ICommandHandler<RemoveThingToDo>
    {
        private readonly IRepository _repository;

        public RemoveThingToDoHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveThingToDo command)
        {
            var thingToDo = await _repository.Get<ThingToDo>(command.Id);
            thingToDo.MarkAsDone();
            await _repository.Save(thingToDo);
        }
    }
}