using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Controls.Templates;
using Avalonia.Layout;
using Avalonia.Media;
using MaxPos.Classes;

public class ContentAreaControl : Grid
{
    public ContentAreaControl()
    {
        ColumnDefinitions = new ColumnDefinitions("*, 100");

        var productsPanel = new Panel();
        Grid.SetColumn(productsPanel, 0);

        var listBox = new ListBox
        {
            ItemsSource = CreateSampleProducts(),
            Margin = new Thickness(5),
            Padding = new Thickness(0),
            Background = Brushes.Transparent
        };

        listBox.ItemTemplate = new FuncDataTemplate<ProductItem>((item, _) =>
        {
            if (item == null) return new TextBlock { Text = "Invalid item" };

            return new Border
            {
                Background = Brushes.White,
                BorderBrush = Brushes.LightGray,
                BorderThickness = new Thickness(0, 0, 0, 1),
                Padding = new Thickness(8, 4),
                Height = 50,
                Child = new Grid
                {
                    ColumnDefinitions = new ColumnDefinitions("60, 4*, Auto"),
                    Children =
                    {
                        // Код товару
                        new TextBlock
                        {
                            Text = item.Code,
                            Foreground = Brushes.Gray,
                            VerticalAlignment = VerticalAlignment.Center,
                            [Grid.ColumnProperty] = 0,
                        },
                        // Опис товару (Назва, В наявності, Штрихкод)
                        new StackPanel
                        {
                            Orientation = Orientation.Horizontal,
                            Spacing = 20,
                            [Grid.ColumnProperty] = 1,
                            Children =
                            {
                                // Назва товару
                                new TextBlock
                                {
                                    VerticalAlignment = VerticalAlignment.Center,
                                    Text = $"{item.Name}",
                                    FontSize = 14,
                                    FontWeight = FontWeight.Bold,
                                },
                                // В наявності
                                new TextBlock
                                {
                                    VerticalAlignment = VerticalAlignment.Center,
                                    Text = $"В наявності: {item.Quantity}",
                                    FontSize = 12,
                                    Foreground = Brushes.Gray,
                                },
                                // Штрихкод
                                new TextBlock
                                {
                                    VerticalAlignment = VerticalAlignment.Center,
                                    Text = $"Штрихкод: {item.Barcode}",
                                    FontSize = 12,
                                    Foreground = Brushes.Gray,
                                }
                            }
                        },
                        // Ціна
                        new TextBlock
                        {
                            Text = $"\u20B4{item.Price:F2}",
                            FontWeight = FontWeight.SemiBold,
                            MinWidth = 70,
                            TextAlignment = TextAlignment.Right,
                            VerticalAlignment = VerticalAlignment.Center,
                            [Grid.ColumnProperty] = 2,
                        }
                    }
                }
            };
        });


        productsPanel.Children.Add(listBox);
        Children.Add(productsPanel);

        // Чорний стовпчик
        Children.Add(new Rectangle
        {
            Fill = Brushes.Black,
            [Grid.ColumnProperty] = 1
        });
    }

    private ObservableCollection<ProductItem> CreateSampleProducts()
    {
        return new ObservableCollection<ProductItem>
        {
            new ProductItem
            {
                Name = "Кава Арабіка",
                Price = 199.99m,
                Quantity = 50,
                Code = "1001",
                Category = "Напої",
                Barcode = GenerateRandomBarcode()
            },
            new ProductItem
            {
                Name = "Чорний чай Earl Grey",
                Price = 89.50m,
                Quantity = 100,
                Code = "1002",
                Category = "Напої",
                Barcode = GenerateRandomBarcode()
            },
            new ProductItem
            {
                Name = "Круасан з шоколадом",
                Price = 45.00m,
                Quantity = 30,
                Code = "1003",
                Category = "Випічка",
                Barcode = GenerateRandomBarcode()
            },
            new ProductItem
            {
                Name = "Сендвіч з куркою",
                Price = 75.00m,
                Quantity = 15,
                Code = "1004",
                Category = "Закуски",
                Barcode = GenerateRandomBarcode()
            },
            new ProductItem
            {
                Name = "Тірамісу",
                Price = 95.00m,
                Quantity = 20,
                Code = "1005",
                Category = "Десерти",
                Barcode = GenerateRandomBarcode()
            }
        };
    }

    private string GenerateRandomBarcode()
    {
        return new Random().Next(100000000, 999999999).ToString();
    }
}