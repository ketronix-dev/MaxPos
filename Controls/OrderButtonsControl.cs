using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Layout;

public class OrderButtonsPanel : StackPanel
{
    public OrderButtonsPanel()
    {
        HorizontalAlignment = HorizontalAlignment.Right;
        VerticalAlignment = VerticalAlignment.Center;
        Width = 400;

        Children.Add(new Button
        {
            Content = "Продаж",
            Background = Brushes.Green,
            Foreground = Brushes.White,
            FontSize = 36,
            Height = 90,
            Width = 300,
            Margin = new Thickness(5),
        });

        Children.Add(new Button
        {
            Content = "Очистити чек",
            Background = Brushes.Brown,
            Foreground = Brushes.White,
            Height = 40,
            Width = 150,
            Margin = new Thickness(5),
        });
    }
}