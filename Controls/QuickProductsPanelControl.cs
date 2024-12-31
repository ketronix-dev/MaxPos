using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;

public class QuickProductsPanel : WrapPanel
{
    public QuickProductsPanel()
    {
        Margin = new Thickness(0, 10);
        VerticalAlignment = VerticalAlignment.Center;

        Children.Add(CreateQuickProductButton("Швидкий товар 1"));
        Children.Add(CreateQuickProductButton("Швидкий товар 2"));
        Children.Add(CreateQuickProductButton("Швидкий товар 3"));
    }

    private Button CreateQuickProductButton(string text)
    {
        return new Button
        {
            Margin = new Thickness(10, 0),
            Content = text,
            Height = 30
        };
    }
}