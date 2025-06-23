using Microsoft.Maui.Controls.Shapes;
using Syncfusion.Maui.Toolkit.Charts;

namespace MinorTicklineAxisLabel
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

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

    }

}
