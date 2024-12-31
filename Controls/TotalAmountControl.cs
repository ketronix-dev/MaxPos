using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Layout;

public class TotalAmountPanel : StackPanel
{
    public TotalAmountPanel()
    {
        Margin = new Thickness(50, 0, 30, 0);
        HorizontalAlignment = HorizontalAlignment.Left;
        VerticalAlignment = VerticalAlignment.Center;

        Children.Add(new TextBlock
        {
            Text = "До сплати:",
            FontSize = 40,
            Foreground = Brushes.Black,
            HorizontalAlignment = HorizontalAlignment.Center,
        });

        Children.Add(new Border
        {
            BorderBrush = Brushes.Black,
            BorderThickness = new Thickness(2),
            CornerRadius = new CornerRadius(5),
            Child = new TextBlock
            {
                Text = "1101.50",
                Margin = new Thickness(10, 0, 10, 0),
                FontSize = 60,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Center,
            }
        });
    }
}