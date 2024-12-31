using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Threading;
using System;
using System.Collections.Generic;

namespace MaxPos.Controls
{
    public class ClockControl : UserControl
    {
        private readonly TextBlock _timeBlock;
        private readonly TextBlock _dateBlock;
        private readonly DispatcherTimer _timer;
        private readonly Dictionary<DayOfWeek, string> _ukrainianDays;

        public ClockControl()
        {
            _ukrainianDays = new Dictionary<DayOfWeek, string>
            {
                { DayOfWeek.Monday, "Понеділок" },
                { DayOfWeek.Tuesday, "Вівторок" },
                { DayOfWeek.Wednesday, "Середа" },
                { DayOfWeek.Thursday, "Четвер" },
                { DayOfWeek.Friday, "П'ятниця" },
                { DayOfWeek.Saturday, "Субота" },
                { DayOfWeek.Sunday, "Неділя" }
            };

            var stackPanel = new StackPanel
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            _timeBlock = new TextBlock
            {
                FontSize = 20,
                FontWeight = FontWeight.Bold,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            _dateBlock = new TextBlock
            {
                FontSize = 14,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            stackPanel.Children.Add(_timeBlock);
            stackPanel.Children.Add(_dateBlock);

            Content = stackPanel;

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += Timer_Tick;
            _timer.Start();

            UpdateTime(); // Початкове оновлення
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }

        private void UpdateTime()
        {
            var now = DateTime.Now;
            _timeBlock.Text = now.ToString("HH:mm:ss");
            
            // Використовуємо власний словник для назв днів
            string dayName = _ukrainianDays[now.DayOfWeek];
            _dateBlock.Text = $"{now.ToString("dd.MM.yyyy")} - {dayName}";
        }

        protected override void OnDetachedFromVisualTree(VisualTreeAttachmentEventArgs e)
        {
            base.OnDetachedFromVisualTree(e);
            _timer.Stop();
        }
    }
}