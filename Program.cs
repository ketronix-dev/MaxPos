using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Styling;
using Avalonia.Themes.Simple;
using MaxPos.Windows;

namespace MaxPos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .StartWithClassicDesktopLifetime(args);
        }
    }

    public class App : Application
    {
        
        public override void Initialize()
        {
            base.Initialize();
            
            var theme = new SimpleTheme();
            RequestedThemeVariant = ThemeVariant.Light;
            Styles.Add(theme);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}