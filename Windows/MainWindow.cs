using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Layout;
using Avalonia.Media;
using MaxPos.Controls;

namespace MaxPos.Windows;

public class MainWindow : Window
{
    private TextBox _searchBox;

    public MainWindow()
    {
#if DEBUG
        this.AttachDevTools();
#endif
        // Налаштування вікна
        Title = "MaxPOS";
        Width = 400;
        Height = 300;
        MinHeight = 200;
        MinWidth = 300;

        WindowState = WindowState.Maximized;

        var grid = new Grid
        {
            RowDefinitions = new RowDefinitions("70, *, Auto, 200"),
        };

        var rowBackground = new Grid()
        {
            ColumnDefinitions = new ColumnDefinitions("*, 300")
        };

        var clockControl = new ClockControl();
        Grid.SetColumn(clockControl, 1);
        rowBackground.Children.Add(clockControl);

        _searchBox = new TextBox()
        {
            Watermark = "Пошук за кодом товару, штрихкодом, або номером телефону клієнта",
            Height = 40,
            FontSize = 15,
            Margin = new Thickness(5),
            SelectionBrush = Brushes.CornflowerBlue,
            SelectionForegroundBrush = Brushes.Azure,
            HorizontalAlignment = HorizontalAlignment.Stretch,
            Classes = { "outline" }
        };

        Grid.SetColumn(_searchBox, 0);
        rowBackground.Children.Add(_searchBox);

        Grid.SetRow(rowBackground, 0);
        grid.Children.Add(rowBackground);

        var rowBackground2 = new Grid()
        {
            ColumnDefinitions = new ColumnDefinitions("*, 100")
        };

        var colRed = new Rectangle
        {
            Fill = Brushes.Coral,
        };

        var colBlack = new Rectangle
        {
            Fill = Brushes.Black,
        };

        Grid.SetColumn(colRed, 0);
        Grid.SetColumn(colBlack, 1);
        rowBackground2.Children.Add(colRed);
        rowBackground2.Children.Add(colBlack);

        Grid.SetRow(rowBackground2, 1); // встановлюємо в перший рядок
        grid.Children.Add(rowBackground2);

        var rowBackground4 = new WrapPanel()
        {
            Margin = new Thickness(0,10),
            VerticalAlignment = VerticalAlignment.Center,
            Children =
            {
                new Button()
                {
                    Margin = new Thickness(10,0),
                    Content = "Швидкий товар 1",
                    Height = 50,
                },
                new Button()
                {
                    Margin = new Thickness(10,0),
                    Content = "Швидкий товар 2",
                    Height = 50
                },
                new Button()
                {
                    Margin = new Thickness(10,0),
                    Content = "Швидкий товар 3",
                    Height = 50,
                }
            }
        };


        var bottomZone = CreateBottomZone();

        Grid.SetRow(rowBackground4, 2); // встановлюємо в перший рядок
        Grid.SetRow(bottomZone, 3); // встановлюємо в перший рядок

        grid.Children.Add(rowBackground4);
        grid.Children.Add(bottomZone);

        // Встановлення вмісту вікна
        Content = grid;
    }

    private Grid CreateBottomZone()
    {
        var bottomZone = new Grid()
        {
            ColumnDefinitions = new ColumnDefinitions("Auto, Auto, *, 200, Auto")
        };

        var OrderButtons = new StackPanel()
        {
            HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Center,
            Width = 400,
            Children =
            {
                new Button()
                {
                    Content = "Продаж",
                    Background = Brushes.Green,
                    Foreground = Brushes.White,
                    FontSize = 36,
                    Height = 90,
                    Width = 300,
                    Margin = new Thickness(5),
                },
                new Button()
                {
                    Content = "Очистити чек",
                    Background = Brushes.Brown,
                    Foreground = Brushes.White,
                    Height = 40,
                    Width = 150,
                    Margin = new Thickness(5),
                },
            }
        };

        var totalText = new StackPanel()
        {
            Margin = new Thickness(50, 0, 30, 0),
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Center,
            Children =
            {
                new TextBlock()
                {
                    Text = "До сплати:",
                    FontSize = 40,
                    Foreground = Brushes.Black,
                    HorizontalAlignment = HorizontalAlignment.Center,
                },
                new Border()
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(2),
                    CornerRadius = new CornerRadius(5),
                    Child = new TextBlock()
                    {
                        Text = "1101.50",
                        Margin = new Thickness(10, 0, 10, 0),
                        FontSize = 60,
                        Foreground = Brushes.Black,
                        HorizontalAlignment = HorizontalAlignment.Center,
                    }
                },
            }
        };

        Grid.SetColumn(totalText, 0);
        bottomZone.Children.Add(totalText);

        var customerInfo = new Border
        {
            BorderBrush = Brushes.Gray,
            BorderThickness = new Thickness(1),
            CornerRadius = new CornerRadius(5),
            Margin = new Thickness(10),
            Padding = new Thickness(15),
            Child = new StackPanel
            {
                Spacing = 10,
                Children =
                {
                    new Grid
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
                    },
                    new Separator
                    {
                        Background = Brushes.LightGray,
                        Height = 1,
                        Margin = new Thickness(0, 5)
                    },
                    new Grid
                    {
                        ColumnDefinitions = new ColumnDefinitions("Auto, *"),
                        RowDefinitions = new RowDefinitions("Auto, Auto, Auto, Auto"),
                        Children =
                        {
                            // Рядок 1 - Загальна сума покупок
                            CreateGridTextBlock("Загальна сума покупок:", 0, 0),
                            CreateGridTextBlock("15,478.50 ₴", 0, 1, true),

                            // Рядок 2 - Знижка
                            CreateGridTextBlock("Знижка:", 1, 0),
                            CreateGridTextBlock("7%", 1, 1, true, Brushes.Green),

                            // Рядок 3 - Бали
                            CreateGridTextBlock("Бонусні бали:", 2, 0),
                            CreateGridTextBlock("1,245", 2, 1, true, Brushes.Blue),

                            // Рядок 4 - Борг
                            CreateGridTextBlock("Борг:", 3, 0),
                            CreateGridTextBlock("0.00 ₴", 3, 1, true, Brushes.Red)
                        }
                    }
                }
            }
        };

        Grid.SetColumn(customerInfo, 1);
        bottomZone.Children.Add(customerInfo);


        var keyboard = new VirtualKeyboard();
        keyboard.AttachToTextBox(_searchBox);
        Grid.SetColumn(keyboard, 3); // або інший потрібний рядок
        bottomZone.Children.Add(keyboard);

        Grid.SetColumn(OrderButtons, 4);
        bottomZone.Children.Add(OrderButtons);

        return bottomZone;
    }

    private TextBlock CreateGridTextBlock(string text, int row, int column, bool isBold = false,
        IBrush foreground = null)
    {
        var textBlock = new TextBlock
        {
            Text = text,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = column == 0 ? HorizontalAlignment.Left : HorizontalAlignment.Right
        };

        if (isBold)
        {
            textBlock.FontWeight = FontWeight.Bold;
        }

        if (foreground != null)
        {
            textBlock.Foreground = foreground;
        }

        Grid.SetRow(textBlock, row);
        Grid.SetColumn(textBlock, column);

        return textBlock;
    }
}