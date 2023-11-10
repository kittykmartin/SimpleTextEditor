using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.WinUi3;
using Serilog.Sinks.WinUi3.LogViewModels;
using Serilog.Templates;
using SimpleTextEditor.Logging;
using SimpleTextEditor.ViewModels;
namespace SimpleTextEditor.Views;

public sealed partial class MainPage : Page
{
    private ItemsRepeaterLogBroker _logBroker;

    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
        BuildLogging();
    }



    private void BuildLogging()
    {
        // Create your custom LogBroker.
        _logBroker = new ItemsRepeaterLogBroker(
            LogViewer,
            LogScrollViewer,
            new EmojiLogViewModelBuilder(defaultForeground: Colors.White)
                // Timestamp format
                .SetTimestampFormat(new ExpressionTemplate("[{@t:yyyy-MM-dd HH:mm:ss.fff}]"))
                // Level format and colors
                .SetLevelsFormat(new ExpressionTemplate("{@l:u3}"))
                .SetLevelForeground(LogEventLevel.Verbose, Colors.Gray)
                .SetLevelForeground(LogEventLevel.Debug, Colors.Gray)
                .SetLevelForeground(LogEventLevel.Warning, Colors.Yellow)
                .SetLevelForeground(LogEventLevel.Error, Colors.Red)
                .SetLevelForeground(LogEventLevel.Fatal, Colors.HotPink)
                // Message format and colors
                .SetMessageFormat(new ExpressionTemplate("{@m}"))
                .SetMessageForeground(LogEventLevel.Verbose, Colors.Gray)
                .SetMessageForeground(LogEventLevel.Debug, Colors.Gray)
                .SetMessageForeground(LogEventLevel.Warning, Colors.Yellow)
                .SetMessageForeground(LogEventLevel.Error, Colors.Red)
                .SetMessageForeground(LogEventLevel.Fatal, Colors.HotPink)
                // Exception format and color
                .SetExceptionFormat(new ExpressionTemplate("{@x}"))
                .SetExceptionForeground(Colors.HotPink)
        );

        // Register your LogBroker with WriteTo.WinUi3Control() and create the logger.
        Log.Logger = new LoggerConfiguration()
            .WriteTo.WinUi3Control(_logBroker)
            .CreateLogger();
    }
}
