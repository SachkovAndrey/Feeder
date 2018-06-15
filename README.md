# Feeder

## Application description

The Feeder app allows you to browse posts and associated comments stored in a separate database component.

## Debugging

Solution -> Set StartUp Projects... -> Set Multiple startup projects: radio button,
select Feeder.WebService(Action - Start) and Feeder.WpfApp (Action - Start) 

## Configuration

Set the connection string one of them ("42", "towel", "local", "vogon")
in Feeder.WebService.Web.Config  - <AppSettings> - <ConnectionString>

Set the host address with port (e.g. http://localhost:65425/) in 
Feeder.WpfApp.App.Config - <AppSettings> - <BaseAddress>
E.g. for ISSExpress - You can know your host address after first run Feeder.WebService in browser address string.

Set the schedule interval in seconds (20 by default) for background loading Comments and Post data in
Feeder.WpfApp.App.Config - <AppSettings> - <ObservableScheduleInterval>

This App.Config also contains EndPont addresses

## Projects Description

### Feeder.Db

This project implements the faсade logic over the database component.
Also project contains mappers from database component to project entities

### Feeder.Db.Tests

This project contains unit tests for Feeder.Db.Mappers

### Feeder.Common

This project contains a declaration of the interfaces of the mappers,
as well as common extensions and exceptions

### Feeder.Core

This project is the top-level entities that are used in the client application (Feeder.WpfApp)

### Feeder.DAL

This project implements data access layer, contains repositories for all Feeder.Db entities.
Also this project implements mapping logic from Feeder.Db.Entities to Feeder.Core.Models

### Feeder.DAL.Tests

This project contains unit tests for Feeder.DAL.Mappers

### Feeder.Services

This project implements an intermediate layer of abstraction between the Feeder.WebService and Feeder.DAL

### Feeder.WebService

This project describes a set of end points (Asp.Net web api) and filtering of exceptions.
Each end point is a web address.
The client sends a request to this address and receives a response.
The request handler returns the result from the database through Feeder.Services

### Feeder.ServiceClient

This project implements clients logic to Feeder.WebService end points via HttpClient.
The response from the service is deserialized and returned as Feeder.Core.Models

### Feeder.WpfApp

This project is a client application for the end user.
The project describes the view models, views. Contains progress bar logic, background data loading logic, navigation logic.
Also this project contains styles and images for application                 

### Feeder.WpfApp.Tests

This project contains unit tests for Feeder.WpfApp.ViewModels
