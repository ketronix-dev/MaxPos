using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Layout;

public class CustomerInfoPanel : Border
{
    public CustomerInfoPanel()
    {
        BorderBrush = Brushes.Gray;
        BorderThickness = new Thickness(1);
        CornerRadius = new CornerRadius(5);
        Margin = new Thickness(10);
        Padding = new Thickness(15);

        Child = CreateCustomerInfoContent();
    }

    private StackPanel CreateCustomerInfoContent()
    {
        return new StackPanel
        {
            Spacing = 10,
            Children =
            {
                CreateCustomerHeader(),
                new Separator
                {
                    Background = Brushes.LightGray,
                    Height = 1,
                    Margin = new Thickness(0, 5)
                },
                CreateCustomerStats()
            }
        };
    }

    private Grid CreateCustomerHeader()
    {
        return new Grid
        {
            ColumnDefinitions = new ColumnDefinitions("*, Auto"),
            Children =
            {
                new StackPanel
                {
                    Children =
                    {
                        new TextBlock
                        {
                            Text = "Клієнт",
                            FontSize = 14,
                            Foreground = Brushes.Gray
                        },
                        new TextBlock
                        {
                            Text = "Іванов Іван Іванович",
                            FontSize = 18,
                            FontWeight = FontWeight.Bold,
                        }
                    }
                },
                new Button
                {
                    [Grid.ColumnProperty] = 1,
                    Content = "Обрати клієнта",
                    Height = 40,
                    Padding = new Thickness(15, 5),
                    Margin = new Thickness(10, 0),
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Right
                }
            }
        };
    }

    private Grid CreateCustomerStats()
    {
        var grid = new Grid
        {
            ColumnDefinitions = new ColumnDefinitions("Auto, *"),
            RowDefinitions = new RowDefinitions("Auto, Auto, Auto, Auto")
        };

        AddStatRow(grid, "Загальна сума покупок:", "15,478.50 ₴", 0);
        AddStatRow(grid, "Знижка:", "7%", 1, Brushes.Green);
        AddStatRow(grid, "Бонусні бали:", "1,245", 2, Brushes.Blue);
        AddStatRow(grid, "Борг:", "0.00 ₴", 3, Brushes.Red);

        return grid;
    }

    private void AddStatRow(Grid grid, string label, string value, int row, IBrush valueBrush = null)
    {
        grid.Children.Add(new TextBlock
        {
            Text = label,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Left,
            [Grid.RowProperty] = row,
            [Grid.ColumnProperty] = 0
        });

        grid.Children.Add(new TextBlock
        {
            Text = value,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Right,
            FontWeight = FontWeight.Bold,
            Foreground = valueBrush ?? Brushes.Black,
            [Grid.RowProperty] = row,
            [Grid.ColumnProperty] = 1
        });
    }
}
