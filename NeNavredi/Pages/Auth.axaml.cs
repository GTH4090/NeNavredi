using System;
using System.Linq;
using System.Timers;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Dialogs.Internal;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using Microsoft.EntityFrameworkCore;
using static NeNavredi.Classes.Helper;

namespace NeNavredi.Pages;

public partial class Auth : UserControl
{
    private bool capcha = false;
    private DispatcherTimer timer = new DispatcherTimer();

    public Auth()
    {
        InitializeComponent();
        timer.Interval = new TimeSpan(0, 0, 10);
        timer.Tick += TimerOnTick;
    }

    private void TimerOnTick(object? sender, EventArgs e)
    {
        LoginBtn.IsEnabled = true;
        timer.Stop();
    }

    private void doCapcha()
    {
        try
        {
            capcha = true;
            CapchaSp.IsVisible = true;
            OneImg.IsVisible = false;
            TwoImg.IsVisible = false;
            ThreeImg.IsVisible = false;
            Random rd = new Random();
            int r = rd.Next(3);
            if (r == 0)
            {
                OneImg.IsVisible = true;
            }

            if (r == 1)
            {
                TwoImg.IsVisible = true;
            }

            if (r == 2)
            {
                ThreeImg.IsVisible = true;
            }
        }
        catch (Exception e)
        {
            Error();
        }
    }


    private void LoginBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            if (CAnLogin)
            {
                if (capcha)
                            {
                                if (OneImg.IsVisible == true)
                                {
                                    if (CapchaTbx.Text != "A123")
                                    {
                                        return;
                                    }
                                }
                
                                if (TwoImg.IsVisible == true)
                                {
                                    if (CapchaTbx.Text != "B456")
                                    {
                                        return;
                                    }
                                }
                
                                if (ThreeImg.IsVisible == true)
                                {
                                    if (CapchaTbx.Text != "C789")
                                    {
                                        return;
                                    }
                                }
                            }
                
                            if (Db.Users.FirstOrDefault(el => el.Login == LoginTbx.Text && el.Password == PasswordTbx.Text) != null)
                            {
                                Db.Employees.Load();
                                Db.ExplorerEmployees.Load();
                                Db.Bookkeepers.Load();
                                Db.Admins.Load();
                                var item = Db.Users.FirstOrDefault(el => el.Login == LoginTbx.Text && el.Password == PasswordTbx.Text);
                                LoginedUser = item;
                                if (item.Employee != null)
                                {
                                    Navigationn.Content = new EmployeeMenu();
                                }
                                else if (item.ExplorerEmployee != null)
                                {
                                    Navigationn.Content = new ExpEmployeeMenu();
                                }
                                else if (item.Bookkeeper != null)
                                {
                                    Navigationn.Content = new BookkeperMenu();
                                }
                                else if (item.Admin != null)
                                {
                                    Navigationn.Content = new AdminMenu();
                                }
                            }
                            else
                            {
                                Info("Не правильный логин или пароль");
                                doCapcha();
                                LoginBtn.IsEnabled = false;
                                timer.Start();
                                
                            }
            }
            else
            {
                Info("Пока нельзя");
            }
            
        }
        catch (Exception exception)
        {
            Error();
        }
    }

    private void PassperdBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            if (PasswordTbx.PasswordChar == '*')
            {
                PasswordTbx.PasswordChar = '\0';
            }
            else
            {
                PasswordTbx.PasswordChar = '*';
            }
        }
        catch (Exception exception)
        {
            Error();
        }
    }

    private void CapcahBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        doCapcha();
    }
}