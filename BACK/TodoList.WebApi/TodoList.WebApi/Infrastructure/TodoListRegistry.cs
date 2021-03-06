﻿using CQRSlite.Commands;
using CQRSlite.Domain;
using CQRSlite.Events;
using CQRSlite.Queries;
using StructureMap;
using TodoList.WebApi.Infrastructure.Read;
using TodoList.WebApi.Infrastructure.Write;

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
            For<IEventStore>().Use<InMemoryEventStore>().Singleton();

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