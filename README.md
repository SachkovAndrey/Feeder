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

