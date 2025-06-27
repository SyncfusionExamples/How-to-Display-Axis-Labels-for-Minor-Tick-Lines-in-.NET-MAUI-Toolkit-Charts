# How to Display Axis Labels for Minor Tick Lines in .NET MAUI Toolkit Charts
This article offers a comprehensive guide on how to display Axis Labels for Minor Tick Lines in .NET MAUI Toolkit Cartesian Chart.

The [SfCartesianChart](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.SfCartesianChart.html) includes support for [Annotations](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.SfCartesianChart.html#Syncfusion_Maui_Toolkit_Charts_SfCartesianChart_Annotations), allowing developers to enhance data visualization. While axis labels are not displayed automatically for minor ticks, you can use [TextAnnotation](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.TextAnnotation.html) to manually place custom labels at the positions of minor tick lines, effectively simulating axis labels for them.

Learn step-by-step instructions and gain insights to display Axis Labels for Minor Tick Lines.

### Configure the Toolkit Cartesian Chart
Define [SfCartesianChart](https://help.syncfusion.com/maui-toolkit/cartesian-charts/getting-started) with both X-axis and Y-axis set as [NumericalAxis](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.NumericalAxis.html) to represent numeric data. Add a [LineSeries](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.LineSeries.html) to visualize data points.

#### XAML
```xml
  <chart:SfCartesianChart>

    <chart:SfCartesianChart.XAxes>
        <chart:NumericalAxis Minimum="2002" Interval="2" Maximum="2020"/>
    </chart:SfCartesianChart.XAxes>

    <chart:SfCartesianChart.YAxes>
        <chart:NumericalAxis Minimum="0" Maximum="120" Interval="20"/>
    </chart:SfCartesianChart.YAxes>

    ......

    <chart:LineSeries ItemsSource="{Binding WheatCultivationData}"
                      XBindingPath="Year"
                      YBindingPath="Value"
                      Label="Wheat"
                      ShowMarkers="True"/>

    <chart:LineSeries ItemsSource="{Binding RiceCultivationData}"
                      XBindingPath="Year"
                      YBindingPath="Value"
                      Label="Rice"
                      ShowMarkers="True"/>

    <chart:LineSeries ItemsSource="{Binding MaizeCultivationData}"
                      XBindingPath="Year"
                      YBindingPath="Value"
                      Label="Maize"
                      ShowMarkers="True"/>

  </chart:SfCartesianChart> 
```

### Display the Axis Labels for Minor Tick Lines
Enable minor ticks by setting the [MinorTicksPerInterval](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.RangeAxisBase.html#Syncfusion_Maui_Toolkit_Charts_RangeAxisBase_MinorTicksPerInterval) property on the axis to display additional tick marks between major intervals.This code uses code-behind logic to dynamically add [TextAnnotation](https://help.syncfusion.com/maui-toolkit/cartesian-charts/annotation#text-annotation) labels to a [SfCartesianChart](https://help.syncfusion.com/maui-toolkit/cartesian-charts/getting-started) by converting X-axis values to pixel coordinates with **ValueToPoint**. It calculates midpoints between visible labels and places annotations precisely using properties like [X1](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.ChartAnnotation.html#Syncfusion_Maui_Toolkit_Charts_ChartAnnotation_X1), [Y1](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.ChartAnnotation.html#Syncfusion_Maui_Toolkit_Charts_ChartAnnotation_Y1), [Text](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.TextAnnotation.html#Syncfusion_Maui_Toolkit_Charts_TextAnnotation_Text) and [LabelStyle](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.TextAnnotation.html#Syncfusion_Maui_Toolkit_Charts_TextAnnotation_LabelStyle) and [CoordinateUnit](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.ChartAnnotation.html#Syncfusion_Maui_Toolkit_Charts_ChartAnnotation_CoordinateUnit) to **Pixel**, applying offsetX and offsetY for fine-tuned alignment during the **SizeChanged** event.

#### XAML
```xml
  <chart:SfCartesianChart>

    <chart:SfCartesianChart.XAxes>
        <chart:NumericalAxis MinorTicksPerInterval="1"/>
    </chart:SfCartesianChart.XAxes>

    ......

</chart:SfCartesianChart> 
```

#### C#
```csharp
public partial class MainPage : ContentPage
{
    private double offsetX = -0.45;
    private double offsetY = 17;
    
    public MainPage()
    {
        InitializeComponent();
        this.SizeChanged += MainPage_SizeChanged;
    }
    
    private void MainPage_SizeChanged(object? sender, EventArgs e)
    {
        Dispatcher.Dispatch(async () =>
        {
            await Task.Delay(300);
            var labels = new Dictionary<double, string>();
            var visiblelabels = XAxis.VisibleLabels;
            for (int i = 1; i < visiblelabels.Count; i++)
            {
                double midYear = (Convert.ToDouble(visiblelabels[i - 1].Content) + Convert.ToDouble(visiblelabels[i].Content)) / 2;
                labels.Add(midYear, midYear.ToString());
            }
            
            chart.Annotations.Clear();
            foreach (var item in labels)
            {
                AddDynamicAnnotation(item.Key + offsetX, chart.SeriesBounds.Height + offsetY, item.Value);
            }
        });
    }

    public void AddDynamicAnnotation(double xAxisValue, double yValue, string labelText)
    {
        // Convert axis values to screen points
        var x = chart.ValueToPoint(XAxis, xAxisValue);
        
        // Create the annotation
        var annotation = new TextAnnotation
        {
            X1 = x,
            Y1 = yValue,
            Text = labelText,
            CoordinateUnit = ChartCoordinateUnit.Pixel,
            LabelStyle = new ChartAnnotationLabelStyle
            {
                FontAttributes = FontAttributes.Bold,
                FontSize = 11,
                TextColor = Colors.Black
            }
        };
        chart.Annotations.Add(annotation);
    }
}
```
### Output:

![MinorTicklineAxisLabel](https://github.com/user-attachments/assets/e0faf8ad-5135-48c1-b0b2-d9f70841b140)

### Troubleshooting

#### Path too long exception

If you are facing a path too long exception when building this example project, close Visual Studio and rename the repository to a shorter name before building the project.

For more details, refer to the KB on [how to display axis labels for minor ticklines in .NET MAUI Toolkit Charts](https://support.syncfusion.com/kb/article/19979/how-to-display-axis-labels-for-minor-tick-lines-in-net-maui-toolkit-charts).
