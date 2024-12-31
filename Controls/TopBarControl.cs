using Avalonia.Controls;
using Avalonia.Layout;
using MaxPos.Controls;
using MaxPos.Controls;

public class TopBarControl : Grid
{
    private SearchTextBox _searchBox;
    
    public TopBarControl()
    {
        ColumnDefinitions = new ColumnDefinitions("*, 300");

        var clockControl = new ClockControl();
        Grid.SetColumn(clockControl, 1);
        Children.Add(clockControl);

        _searchBox = new SearchTextBox
        {
            Watermark = "Пошук за кодом товару, штрихкодом, або номером телефону клієнта",
            HorizontalAlignment = HorizontalAlignment.Stretch,
        };

        Grid.SetColumn(_searchBox, 0);
        Children.Add(_searchBox);
    }

    public void AttachVirtualKeyboard(VirtualKeyboard keyboard)
    {
        _searchBox.AttachVirtualKeyboard(keyboard);
    }
}