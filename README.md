# SignalR and Messaging Demos

This repository contains sample code demonstrating how to connect frontend to backend using SignalR and messaging.

## Prerequites

In order to run the sample code, several infrastructure components need to be installed:

 - Frontend Web apps and backend services are hosted in Azure Cloud Services and [Azure SDK for .NET 2.8](https://www.microsoft.com/en-us/download/details.aspx?id=50041) is required to run them locally in an emulated environment.
 - NServiceBus framework is used to connect the frontend to the backend. This sample uses [RabbitMQ](https://www.rabbitmq.com/) as [transport](http://docs.particular.net/nservicebus/transports/).
 - [Redis](http://redis.io/) is used as the backplane to scaleout SignalR.

Please refer to documentation of each individual component for download and setup instructions.

## Configuration

### RabbitMQ connection string

RabbitMQ connection string can be set using `Backend.RabbitMqConnectionString.Value` property in the `Shared` project.

### Redis connection data

Redis connection data such as server address, port, and password can be set setting appropriate properties of the `Frontend.Config.RedisConnectionData` class in the `Frontend` project.