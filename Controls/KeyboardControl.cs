using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;

namespace MaxPos.Controls
{
    public class VirtualKeyboard : UserControl
    {
        private readonly Grid _mainGrid;
        private TextBox _targetTextBox;

        public VirtualKeyboard(HorizontalAlignment horizontalAlignment = HorizontalAlignment.Stretch)
        {
            _mainGrid = new Grid
            {
                RowDefinitions = new RowDefinitions("*,*,*,*"),
                ColumnDefinitions = new ColumnDefinitions("*,*,*"),
                HorizontalAlignment = horizontalAlignment,
                VerticalAlignment = VerticalAlignment.Stretch,
                Margin = new Thickness(5)
            };

            CreateNumericKeyboard();
            
            Content = _mainGrid;
        }

        private void CreateNumericKeyboard()
        {
            // Створюємо кнопки 1-9
            for (int i = 1; i <= 9; i++)
            {
                var button = CreateButton(i.ToString());
                Grid.SetRow(button, (i - 1) / 3);
                Grid.SetColumn(button, (i - 1) % 3);
                _mainGrid.Children.Add(button);
            }

            // Додаємо 0
            var zeroButton = CreateButton("0");
            Grid.SetRow(zeroButton, 3);
            Grid.SetColumn(zeroButton, 1);
            _mainGrid.Children.Add(zeroButton);

            // Додаємо крапку
            var dotButton = CreateButton(".");
            Grid.SetRow(dotButton, 3);
            Grid.SetColumn(dotButton, 0);
            _mainGrid.Children.Add(dotButton);

            // Додаємо Backspace
            var backspaceButton = CreateButton("←");
            backspaceButton.Click -= DefaultButtonClick;
            backspaceButton.Click += (s, e) => HandleBackspace();
            Grid.SetRow(backspaceButton, 3);
            Grid.SetColumn(backspaceButton, 2);
            _mainGrid.Children.Add(backspaceButton);
        }

        private Button CreateButton(string content)
        {
            var button = new Button
            {
                Content = content,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness(2),
                MinHeight = 40,
                MinWidth = 40,
                FontSize = 20,
            };
            
            button.Click += DefaultButtonClick;
            return button;
        }

        private void DefaultButtonClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (sender is Button button && button.Content is string content)
            {
                HandleKeyPress(content);
            }
        }

        private void HandleKeyPress(string key)
        {
            if (_targetTextBox != null)
            {
                var selectionStart = _targetTextBox.SelectionStart;
                var text = _targetTextBox.Text ?? string.Empty;
                
                // Перевіряємо, чи можна додати крапку
                if (key == "." && text.Contains("."))
                    return;

                // Перевіряємо, чи це перший символ крапка
                if (key == "." && string.IsNullOrEmpty(text))
                {
                    _targetTextBox.Text = "0.";
                    _targetTextBox.SelectionStart = 2;
                    return;
                }

                _targetTextBox.Text = text.Insert(selectionStart, key);
                _targetTextBox.SelectionStart = selectionStart + key.Length;
            }
        }

        private void HandleBackspace()
        {
            if (_targetTextBox != null && _targetTextBox.SelectionStart > 0)
            {
                var selectionStart = _targetTextBox.SelectionStart;
                var text = _targetTextBox.Text;
                
                if (!string.IsNullOrEmpty(text))
                {
                    _targetTextBox.Text = text.Remove(selectionStart - 1, 1);
                    _targetTextBox.SelectionStart = selectionStart - 1;
                }
            }
        }

        public void AttachToTextBox(TextBox textBox)
        {
            _targetTextBox = textBox;
        }
    }
}