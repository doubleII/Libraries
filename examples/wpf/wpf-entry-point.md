## Table of content
* Entry point
* Where is the entry point of a wpf application?


## Entry point 

The `Main` method is the entry point of a C# application. Libraries and services do not required a `Main` method as a entry point. When the application is started, 
<br/>the `Main` method is a first method that is invoked.

That's mean, the C# program has only one entry point. If you have more that one class that has a `Main` method, you must compile your program with only one entry point option.

The entry point of console application is a the `Main` method.

## Entry point of a wpf application

The usual entry point of a default wpf application this is the public static void `App.Main` method. This method is defined in `App.g.cs` (auto-generated code) file.
<br/>That#s mean, the `Main` method for a wpf is an auto-generated file.
<br/>The entry point can be overridden in the code-behind of `App.Xaml` file. 

You can change the entry point, if you change the default start-up settings.

The default settings in `App.xaml` file.<br/>
```xml
<Application x:Class="GlobalExceptionHandling.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:GlobalExceptionHandling"
           StartupUri="MainWindow.xaml">
    <Application.Resources>
```

If you want to see the default start-up points expand the `App.xaml` into solution explorer:
 - App.xaml
   - App.xaml.cs
     - App
       - InitializeComponent():void
       - Main():void
      
## Define the start-up of wpf application

1. Changed startup settings in `App.xaml` file.<br/>
```xml
<Application x:Class="GlobalExceptionHandling.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:GlobalExceptionHandling"
             Startup="Application_Startup">
<Application.Resources>
```

2. Add into `App.xaml.cs` the defined event from `App.xaml` file.

```c#
 private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                MainWindow mw = new MainWindow();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Global exception: {ex}.");
                Console.WriteLine("Close App...");
                Current.Shutdown();
            }
        }
```



Now you can see the startup event in `App.xaml.cs` file:
 - App.xaml
   - App.xaml.cs
     - App
       - Application_Startup(object, StartupEventArgs):void
       - InitializeComponent():void
       - Main():void

