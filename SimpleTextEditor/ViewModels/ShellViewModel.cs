﻿using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Navigation;

using SimpleTextEditor.Contracts.Services;

namespace SimpleTextEditor.ViewModels;

public partial class ShellViewModel : ObservableRecipient
{
    [ObservableProperty]
    private bool isBackEnabled;

    public ICommand MenuFileExitCommand
    {
        get;
    }

    public ICommand MenuViewslogCommand
    {
        get;
    }

    public ICommand MenuSettingsCommand
    {
        get;
    }

    public ICommand MenuViewsMainCommand
    {
        get;
    }

    public INavigationService NavigationService
    {
        get;
    }

    public ShellViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;

        MenuFileExitCommand = new RelayCommand(OnMenuFileExit);
        MenuViewslogCommand = new RelayCommand(OnMenuViewslog);
        MenuSettingsCommand = new RelayCommand(OnMenuSettings);
        MenuViewsMainCommand = new RelayCommand(OnMenuViewsMain);
    }

    private void OnNavigated(object sender, NavigationEventArgs e) => IsBackEnabled = NavigationService.CanGoBack;

    private void OnMenuFileExit() => Application.Current.Exit();

    private void OnMenuViewslog() => NavigationService.NavigateTo(typeof(logViewModel).FullName!);

    private void OnMenuSettings() => NavigationService.NavigateTo(typeof(SettingsViewModel).FullName!);

    private void OnMenuViewsMain() => NavigationService.NavigateTo(typeof(MainViewModel).FullName!);
}
