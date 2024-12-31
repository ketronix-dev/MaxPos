using Avalonia;
using Avalonia.Controls;
using MaxPos.Controls;

namespace MaxPos.Windows;

public class MainWindow : Window
{
    private TopBarControl _topBar;
    
    public MainWindow()
    {
#if DEBUG
        this.AttachDevTools();
#endif
        InitializeWindow();
        Content = CreateMainLayout();
    }

    private void InitializeWindow()
    {
        Title = "MaxPOS";
        Width = 400;
        Height = 300;
        MinHeight = 200;
        MinWidth = 300;
        WindowState = WindowState.Maximized;
    }

    private Grid CreateMainLayout()
    {
        var grid = new Grid
        {
            RowDefinitions = new RowDefinitions("50, *, Auto, 200"),
        };

        _topBar = new TopBarControl();
        Grid.SetRow(_topBar, 0);
        grid.Children.Add(_topBar);

        var contentArea = new ContentAreaControl();
        Grid.SetRow(contentArea, 1);
        grid.Children.Add(contentArea);

        var quickProducts = new QuickProductsPanel();
        Grid.SetRow(quickProducts, 2);
        grid.Children.Add(quickProducts);

        var bottomZone = CreateBottomZone();
        Grid.SetRow(bottomZone, 3);
        grid.Children.Add(bottomZone);

        return grid;
    }

    private Grid CreateBottomZone()
    {
        var bottomZone = new Grid
        {
            ColumnDefinitions = new ColumnDefinitions("Auto, Auto, *, 200, Auto")
        };

        var totalAmount = new TotalAmountPanel();
        Grid.SetColumn(totalAmount, 0);
        bottomZone.Children.Add(totalAmount);

        var customerInfo = new CustomerInfoPanel();
        Grid.SetColumn(customerInfo, 1);
        bottomZone.Children.Add(customerInfo);

        var keyboard = new VirtualKeyboard();
        _topBar.AttachVirtualKeyboard(keyboard);
        Grid.SetColumn(keyboard, 3);
        bottomZone.Children.Add(keyboard);

        var orderButtons = new OrderButtonsPanel();
        Grid.SetColumn(orderButtons, 4);
        bottomZone.Children.Add(orderButtons);

        return bottomZone;
    }
}