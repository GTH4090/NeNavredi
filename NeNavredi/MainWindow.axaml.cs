using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using NeNavredi.Pages;
using static NeNavredi.Classes.Helper;

namespace NeNavredi;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ExitBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }

    private void LogoutBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        LoginedUser = null;
        Navigationn.Content = new Auth();
    }

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        try
        {
            Win = this;
            Navigationn = MainFrame;
            Navigationn.Content = new Auth();
            TimerMessage.Interval = new TimeSpan(0, 1, 0);
            TimerMessage.Tick += TimerMessageOnTick;
            TimerLogout.Interval = new TimeSpan(0, 2, 0);
            TimerLogout.Tick += TimerLogoutOnTick;

        }
        catch (Exception exception)
        {
            Error();
        }
    }

    
}