## Button with icon

Image Properties
* Build Action - Resource
* Copy to Output Directory - Do not copy


```xml
     <Button x:Name="" 
             BorderBrush="#e6e6e6"
             Background="Transparent"
             Foreground="Black"
             Margin="5"
             Command="{Binding ..Command}">
                <Image Source="left-arrow.png" Height="15"/>
            </Button>
```

If you want to use FontAwesome icons look [here](https://github.com/doubleII/Libraries/blob/main/Tipps/00007-wpf-resource-file.md)
