using System;
using Avalonia.Controls;
using Avalonia.Threading;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using NeNavredi.Models;
using NeNavredi.Pages;

namespace NeNavredi.Classes;

public class Helper
{
    public static NeNavrediDbContext Db = new NeNavrediDbContext();
    public static Window Win = null;
    public static ContentControl Navigationn = null;

    public static bool CAnLogin = true;

    public static User LoginedUser = null;

    public static DispatcherTimer TimerLogout = new DispatcherTimer();
    public static void TimerLogoutOnTick(object? sender, EventArgs e)
    {
        Navigationn.Content = new Auth();
        LoginedUser = null;
        CantLoginTimer.Interval = new TimeSpan(0, 1, 0);
        CAnLogin = false;
        CantLoginTimer.Tick += CantLoginTimerOnTick;
        CantLoginTimer.Start();
        

    }

    private static void CantLoginTimerOnTick(object? sender, EventArgs e)
    {
        CantLoginTimer.Stop();
        CAnLogin = true;
    }

    public static DispatcherTimer TimerMessage = new DispatcherTimer();

    private static DispatcherTimer CantLoginTimer = new DispatcherTimer();
    
    public static void TimerMessageOnTick(object? sender, EventArgs e)
    {
        Info("Осталась одна минута/15 минут");
        TimerMessage.Stop();
    }

    public static void Error(string message = "Ошибка БД")
    {
        MessageBoxManager.GetMessageBoxStandard("Ошибка", message, ButtonEnum.Ok, Icon.Error).ShowWindowDialogAsync(Win);
    }
    public static void Info(string message = "")
    {
        MessageBoxManager.GetMessageBoxStandard("Ифно", message, ButtonEnum.Ok, Icon.Info).ShowWindowDialogAsync(Win);
    }
}