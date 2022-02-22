## Allow new line, if you click on enter key

The Property `AcceptReturen` allow new line and `Textwrapping` allow multilines.

```xaml
 <TextBox x:Name="MessageBox" 
         TextWrapping="Wrap" 
         AcceptsReturn="True"
         Margin="0 10 0 0 "
         Text="{
          Binding Message,
          UpdateSourceTrigger=PropertyChanged}"/>
```
