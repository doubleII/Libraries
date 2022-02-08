## Load Wpf Application from App

Change App.xam

```c#
<Application x:Class="Yournamespace.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:Yournamespace"
             StartupUrl="Views/MainWindow.xaml">
    <Application.Resources>
         
    </Application.Resources>
</Application>
```

to 
```c#
<Application x:Class="Yournamespace.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:Yournamespace"
             Startup="Application_Startup">
    <Application.Resources>
         
    </Application.Resources>
</Application>
```
add into App.xaml.cs

```c#
    private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                MainWindow mw = new MainWindow();
                mw.Show();
            }
            catch (Exception ex)
            {
                Current.Shutdown();
            }
        }
```
