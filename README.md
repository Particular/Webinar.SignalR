# SignalR and Messaging Demos

This repository contains sample code demonstrating how to connect frontend to backend using SignalR and messaging.

## Prerequisites

In order to run the sample code, several infrastructure components need to be installed:

 - Frontend Web apps and backend services are hosted in Azure Cloud Services and [Azure SDK for .NET 2.9](https://www.microsoft.com/en-us/download/details.aspx?id=51657) is required to run them locally in an emulated environment.
 - NServiceBus framework is used to connect the frontend to the backend. This sample uses [RabbitMQ](https://www.rabbitmq.com/) as [transport](http://docs.particular.net/nservicebus/transports/).
 - [Redis](http://redis.io/) is used as the backplane to scaleout SignalR.

Please refer to documentation of each individual component for download and setup instructions.

## Configuration

### RabbitMQ connection string

RabbitMQ connection string can be configured by setting the `Value` property of the `Shared.RabbitMqConnectionString` class in the `Shared` project.

### Redis connection parameters

Redis connection parameters such as server address, port, and password can be configured by setting relevant properties of the `Frontend.Config.RedisConnectionData` class in the `Frontend` project.

When running Redis locally with no password required, the `Password` property should be set to an empty string.

### Azure Cloud Services configuration

In order to run the sample code locally using Azure Compute Emulator, set the `CloudService` project as the startup project and configure it to run using the full emulator. This allows multiple instances of the frontend Web app and the backend service to execute in a load balanced environment (as opposed to the express emulator which is limited to a single instance). Full emulator requires Visual Studio to run with elevated privileges.
