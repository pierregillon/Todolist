using CQRSlite.Commands;
using CQRSlite.Domain;
using CQRSlite.Events;
using CQRSlite.Queries;
using StructureMap;

namespace TodoList.WebApi.Infrastructure
{
    public class TodoListRegistry : Registry
    {
        public TodoListRegistry()
        {
            For<ICommandSender>().Use<StructureMapCommandSender>().Singleton();
            For<IQueryProcessor>().Use<StructureMapQueryProcessor>().Singleton();
            For<StructureMapEventPublisher>().Use<StructureMapEventPublisher>().Singleton();
            For<IEventPublisher>().Use<StructureMapEventPublisher>().Singleton();
            For<IRepository>().Use<Repository>();

            // Infrastructure
            For<ReadSideDatabase>().Singleton();

            // Scans
            Scan(scanner => {
                scanner.AssemblyContainingType(typeof(Program));
                scanner.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<>));
            });

            Scan(scanner => {
                scanner.AssemblyContainingType(typeof(Program));
                scanner.ConnectImplementationsToTypesClosing(typeof(IQueryHandler<,>));
            });

            Scan(scanner => {
                scanner.AssemblyContainingType(typeof(Program));
                scanner.ConnectImplementationsToTypesClosing(typeof(IEventHandler<>));
            });
        }
    }
}