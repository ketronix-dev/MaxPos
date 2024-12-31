using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Layout;
using Avalonia.Media;
using Path = Avalonia.Controls.Shapes.Path;

namespace MaxPos.Controls
{
    public class SearchTextBox : ContentControl
    {
        private TextBox _textBox;
        
        public static readonly StyledProperty<string> WatermarkProperty =
            AvaloniaProperty.Register<SearchTextBox, string>(nameof(Watermark));

        public static readonly StyledProperty<string> TextProperty =
            AvaloniaProperty.Register<SearchTextBox, string>(nameof(Text));

        public string Watermark
        {
            get => GetValue(WatermarkProperty);
            set => SetValue(WatermarkProperty, value);
        }

        public string Text
        {
            get => GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public SearchTextBox()
        {
            _textBox = new TextBox
            {
                Height = 40,
                FontSize = 24,
                Classes = { "outline" },
                SelectionBrush = Brushes.CornflowerBlue,
                SelectionForegroundBrush = Brushes.Azure,
                VerticalContentAlignment = VerticalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Padding = new Thickness(45, 0, 5, 0), // Додаємо відступ зліва для іконки
                Margin = new Thickness(10,0)
            };

            var searchIcon = new Path
            {
                Data = Geometry.Parse("M15.5 14h-.79l-.28-.27A6.471 6.471 0 0 0 16 9.5 6.5 6.5 0 1 0 9.5 16c1.61 0 3.09-.59 4.23-1.57l.27.28v.79l5 4.99L20.49 19l-4.99-5zm-6 0C7.01 14 5 11.99 5 9.5S7.01 5 9.5 5 14 7.01 14 9.5 11.99 14 9.5 14z"),
                Fill = Brushes.Gray,
                Width = 20,
                Height = 23,
                Margin = new Thickness(20, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            var panel = new Panel();
            
            _textBox.Bind(TextBox.WatermarkProperty, this.GetObservable(WatermarkProperty));
            _textBox.Bind(TextBox.TextProperty, this.GetObservable(TextProperty));

            panel.Children.Add(_textBox);
            panel.Children.Add(searchIcon);

            Content = panel;
        }

        public void AttachVirtualKeyboard(VirtualKeyboard keyboard)
        {
            keyboard.AttachToTextBox(_textBox);
        }
    }
}