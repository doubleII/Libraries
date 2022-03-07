## Table of content
* Resource file
* Font Awesome icons


## Resource file

Global control style you can put directly into `MainWindow.xaml` like this:

```xaml
<Window.Resources>
  <!--custom settings-->
  <Style TargetType="Button" x:key="btn">
    <Setter Property="Background" Value="Black"/>
    <Setter Property="Foreground" Value="White"/>
  </Style>
  
  <!--default settings-->
    <Style TargetType="Button">
    <Setter Property="Background" Value="Blue"/>
    <Setter Property="Foreground" Value="White"/>
  </Style>
</Window.Resources>

<Grid>
  ...
  <!--default settings-->
   <Button Content="ButtonName" Command="{Binding ClickCommand}"/>
   
   <!--custom settings-->
    <Button Style="{StaticResource btn}" Content="ButtonName" Command="{Binding ClickCommand}"/>
    ...
</Grid>
```

or you can put this settings into `App.xaml` file:

```xml
    <Application.Resources>
        <ResourceDictionary>
          <!--default settings are without key-->
          <Style TargetType="Label">
                <Setter Property="HorizontalContentAlignment" Value="Right" />
                <Setter Property="VerticalContentAlignment" Value="Right" />
            </Style>
          
            <!--custom settings-->
            <Style TargetType="Label" x:key="lableStyle">
                <Setter Property="HorizontalContentAlignment" Value="Center" />
                <Setter Property="VerticalContentAlignment" Value="Center" />
            </Style>

            <Style TargetType="TextBox" x:key="textBoxStyle">
                <Setter Property="HorizontalContentAlignment" Value="Center" />
                <Setter Property="VerticalContentAlignment" Value="Center" />
                <Setter Property="Margin" Value="12" />
            </Style>
        </ResourceDictionary>
    </Application.Resources>
```

```MainWindow.xaml
<Grid>
  <!--default settings the same like on the top-->
  
  <!--custom settings-->
  <TextBox Style="{StaticResource textBoxStyle}"/>
  
</Grid>
```
or you can put directly your style settings into resource file [tutorial](https://www.youtube.com/watch?v=Y9hElE-vx34&ab_channel=ToskersCorner)

## Font Awesome icons

1. Add `FontAwesome.wpf` NugetPackage.
2.  Add the Reference into `App.xaml` file.

```xml
    <Application.Resources>
        <ResourceDictionary>
            <FontFamily x:Key="FontAwesome">/Fonts/fontawesome-webfont.ttf#FontAwesome</FontFamily>
        </ResourceDictionary>
    </Application.Resources>
```

3. Add Reference into `MainWindow.xaml` file

```xaml
<Window x:class="YourApp"
  ...
  xmlns:fa="clr-namespace:FontAwesome.WPF;assembly="FontAwesome.WPF"
  ...
>

  <Grid>
    ...
    <StackPanel>
      <fa:ImageAwesome Icon="Github"></fa:ImageAwesome>
    </StackPanel>
  </Grid>
  
</Window>
```

