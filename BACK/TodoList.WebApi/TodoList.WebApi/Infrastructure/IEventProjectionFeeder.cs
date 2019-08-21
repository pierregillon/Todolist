using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSlite.Events;

namespace TodoList.WebApi.Infrastructure
{
    public interface IEventProjectionFeeder
    {
        Task Feed(IEnumerable<IEvent> events);
    }
}