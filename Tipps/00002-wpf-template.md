## Table of content
* Using MvvMLightLib from me
* Basic XAML Template
* Basic MainViewModel Template
* MainWindow.xaml.cs


## Using MvvMLightLig


## Basic XAML Template

```xml
<Window x:Class="YourApp.Views.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:YourApp"
        mc:Ignorable="d"
        Background="#FFF4F4F5"
        Title="{Binding Title}" Height="450" Width="800">
        
  <Border Margin="5 5 5 0" Background="White">     
 
      <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
            <RowDefinition Height=".06*"/>
            <RowDefinition Height=".04*"/>
        </Grid.RowDefinitions>
        <Rectangle Fill="#FFF4F4F5" Grid.Row="2" />
        <TextBlock Grid.Row="2" 
                       Margin="10 0 0 0"
                       Text="{Binding Status, UpdateSourceTrigger=PropertyChanged}"/>
    </Grid>
          
  </Border>
        
</Window>

```

## Basic MainViewModel Template

```c#
 public class MainViewModel : BaseViewModel
    {
        public string Title { get; private set; }
        public string Status { get; set; }

        public MainViewModel()
        {
            Title = "Your App title";
        }
    }

```

## MainWindow.xaml.cs

```c#
 public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
```
