using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using static  NeNavredi.Classes.Helper;

namespace NeNavredi.Pages;

public partial class EmployeeMenu : UserControl
{
    
    public EmployeeMenu()
    {
        InitializeComponent();
    }

    private int minutes = 2;
    private DispatcherTimer _timer = new DispatcherTimer();

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        try
        {
            NameLb.Content = LoginedUser.Name;
            TimerLogout.Start();
            TimerMessage.Start();
            _timer.Interval = new TimeSpan(0, 1, 0);
            _timer.Tick +=TimerOnTick;
            _timer.Start();

        }
        catch (Exception exception)
        {
            Error();
        }
    }

    private void TimerOnTick(object? sender, EventArgs e)
    {
        minutes--;
        if (minutes >= 0)
        {
            TimerLb.Content = "0;" + minutes;
        }
        else
        {
            _timer.Stop();
        }
    }

    private void ExitBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Navigationn.Content = new Auth();
        LoginedUser = null;
    }
}