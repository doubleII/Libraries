## Table of content



## App.xaml

In DataType add your ViewModel.cs file and into DataTemplate add your View.xaml name.

```xaml
    <Application.Resources>
        <ResourceDictionary>
            <DataTemplate DataType="{x:Type textStyle:..ViewModel}">
                <textStyle:..View/>
            </DataTemplate>
        </ResourceDictionary>
    </Application.Resources>
</Application>
```
