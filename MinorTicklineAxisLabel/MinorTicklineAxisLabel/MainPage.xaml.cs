using Syncfusion.Maui.Toolkit.Charts;

namespace MinorTicklineAxisLabel
{
    public partial class MainPage : ContentPage
    {
        private double offsetX = -0.43;
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
                foreach(var item in XAxis.VisibleLabels)
                {
                    string label = (Convert.ToDouble(item.Content) + 1).ToString();
                    double midYear = Convert.ToDouble(item.Content) + 0.5;
                    labels.Add(midYear, label);
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
}
