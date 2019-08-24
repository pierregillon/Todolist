# Todolist
A simple application to experiment Angular 8, TypeScript, Asp.net Core, CQRS, EventSourcing

## FRONT : Angular II
- Angular 8 and Typescript

## BACK : ASP.NET Core 2.2
Stack :
- CQRS architecture using commands and queries
  * In-memory bus (projections fed by structuremap container)
  * In-memory read database
- Modeling using Domain events (EventSourcing)
  * In-memory eventstore
  
Libraries
- CQRSLite
- Structuremap

## Tests
2 kinds of tests :
- acceptance tests : global tests using interaction between commands and events
- unit tests : test using a single command / event

Libraries
- xUnit
- NSubstitute
