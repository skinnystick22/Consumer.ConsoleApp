using Consumer.ConsoleApp;
using Vax;

var services = new ServiceCollection();

// services.AddSingleton<IConsoleWriter, ConsoleWriter>();
// services.AddSingleton<IIdGenerator, IdGenerator>();
//
services.AddSingleton<ConsoleWriter>();

services.AddTransient(provider => new IdGenerator(provider.GetService<ConsoleWriter>()!));

var serviceProvider = services.BuilderServiceProvider();

var service1 = serviceProvider.GetService<IdGenerator>();
var service2 = serviceProvider.GetService<IdGenerator>();

service1.PrintId();
service2.PrintId();