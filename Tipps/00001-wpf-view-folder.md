## Move MainWindow.xaml to Views folder

1. Add the folder name in MainWindow.cs namenspace `yournamespace.Views`.

```c#
namespace YourNamespace.Views
```
3. Add the folder name in MainWindow.xaml namespace `yournamespace.Views`.

```xml
<Window x:Class="YourNamespace.Views.MainWindow"
        ...
```

5. Add the folder name in App.xaml file. 

```xml
<Application x:Class="SWM.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             StartupUri="Views/MainWindow.xaml">
```
