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
    

    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
      
    }



 
}
