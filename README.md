# How to Display Axis Labels for Minor Tick Lines in .NET MAUI Toolkit Charts
This article offers a comprehensive guide on how to display Axis Labels for Minor Tick Lines in .NET MAUI Toolkit Cartesian Chart.

The [SfCartesianChart](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.SfCartesianChart.html) includes support for [Annotations](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.SfCartesianChart.html#Syncfusion_Maui_Toolkit_Charts_SfCartesianChart_Annotations), allowing developers to enhance data visualization. While axis labels are not displayed automatically for minor ticks, you can use [TextAnnotation](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.TextAnnotation.html) to manually place custom labels at the positions of minor tick lines, effectively simulating axis labels for them.

Learn step-by-step instructions and gain insights to display Axis Labels for Minor Tick Lines.

### Configure the Toolkit Cartesian Chart
Define [SfCartesianChart](https://help.syncfusion.com/maui-toolkit/cartesian-charts/getting-started) with [DateTimeAxis](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.DateTimeAxis.html) for the X-axis and [NumericalAxis](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.NumericalAxis.html) for the Y-axis. Add a [LineSeries](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.LineSeries.html) to visualize data points.


#### XAML
```xml
  <chart:SfCartesianChart>
  
     <chart:SfCartesianChart.XAxes>
         <chart:DateTimeAxis IntervalType="Months" Interval="1"/>
     </chart:SfCartesianChart.XAxes>
  
     <chart:SfCartesianChart.YAxes>
         <chart:NumericalAxis Minimum="0" Maximum="120" Interval="40"/>
     </chart:SfCartesianChart.YAxes>
  
     ......
  
     <chart:LineSeries ItemsSource="{Binding TemperatureData}"
                   XBindingPath="Date"
                   YBindingPath="Value"
                   ShowMarkers="True"/>
  
     <chart:LineSeries ItemsSource="{Binding HumidityData}"
                   XBindingPath="Date"
                   YBindingPath="Value"
                   ShowMarkers="True"/>
  
     <chart:LineSeries ItemsSource="{Binding RainfallData}"
                   XBindingPath="Date"
                   YBindingPath="Value"
                   ShowMarkers="True"/>
  
  </chart:SfCartesianChart>
```

### Display the Axis Labels for Minor Tick Lines
Enable minor ticks by setting the [MinorTicksPerInterval](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.RangeAxisBase.html#Syncfusion_Maui_Toolkit_Charts_RangeAxisBase_MinorTicksPerInterval) property on the axis. Then, use code-behind logic to convert axis values into screen coordinates and add [TextAnnotation](https://help.syncfusion.com/maui-toolkit/cartesian-charts/annotation#text-annotation) with properties like [X1](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.ChartAnnotation.html#Syncfusion_Maui_Toolkit_Charts_ChartAnnotation_X1), [Y1](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.ChartAnnotation.html#Syncfusion_Maui_Toolkit_Charts_ChartAnnotation_Y1), [Text](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.TextAnnotation.html#Syncfusion_Maui_Toolkit_Charts_TextAnnotation_Text) and [LabelStyle](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.TextAnnotation.html#Syncfusion_Maui_Toolkit_Charts_TextAnnotation_LabelStyle), using [CoordinateUnit](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.ChartAnnotation.html#Syncfusion_Maui_Toolkit_Charts_ChartAnnotation_CoordinateUnit) to Pixel for accurate and customizable label placement.

#### XAML
```xml
  <chart:SfCartesianChart>
  
     <chart:SfCartesianChart.XAxes>
         <chart:DateTimeAxis IntervalType="Months" Interval="1" MinorTicksPerInterval="1"/>
     </chart:SfCartesianChart.XAxes>
  
     ......
  
  </chart:SfCartesianChart>
```

#### C#
```csharp
  protected override void OnAppearing()
  {
     base.OnAppearing();
  
     Dispatcher.Dispatch(async () =>
     {
         await Task.Delay(300);
         var labels = new[]
         {
             new { Date = new DateTime(2023, 1, 15), Label = "16" },
             new { Date = new DateTime(2023, 2, 14), Label = "14" },
             new { Date = new DateTime(2023, 3, 15), Label = "16" },
             new { Date = new DateTime(2023, 4, 15), Label = "15" },
             new { Date = new DateTime(2023, 5, 15), Label = "16" },
             new { Date = new DateTime(2023, 6, 15), Label = "15" },
             new { Date = new DateTime(2023, 7, 15), Label = "16" },
             new { Date = new DateTime(2023, 8, 15), Label = "16" },
             new { Date = new DateTime(2023, 9, 15), Label = "15" },
             new { Date = new DateTime(2023, 10, 15), Label = "16" },
             new { Date = new DateTime(2023, 11, 15), Label = "15" },
         };
  
         double adjustDays = -2.5;
  
         foreach (var item in labels)
         {
             var adjustedDate = item.Date.AddDays(adjustDays).ToOADate();
             AddDynamicAnnotation(adjustedDate, -67, item.Label);
             adjustDays += 11.7;
         }
  
     });
  }
  
  public void AddDynamicAnnotation(double xAxisValue, double yAxisValue, string labelText)
  {
     // Convert axis values to screen points
     var x = chart.ValueToPoint(XAxis, xAxisValue);
     var y = chart.ValueToPoint(YAxis, yAxisValue);
  
     // Create the annotation
     var annotation = new TextAnnotation
     {
         X1 = x,
         Y1 = y,
         Text = labelText,
         CoordinateUnit = ChartCoordinateUnit.Pixel,
         LabelStyle = new ChartAnnotationLabelStyle
         {
             FontAttributes = FontAttributes.Italic,
             FontSize = 16,
         }
     };
  
     // Add to chart annotations
     chart.Annotations.Add(annotation);
  }
```
### Output:

![MinorTicklineAxisLabelOutput](https://github.com/user-attachments/assets/2dd54a9c-b149-4529-a6e9-4e3e98588a13)

### Troubleshooting

#### Path too long exception

If you are facing a path too long exception when building this example project, close Visual Studio and rename the repository to a shorter name before building the project.

For more details, refer to the KB on [how to display axis labels for minor ticklines in .NET MAUI Toolkit Charts]().
