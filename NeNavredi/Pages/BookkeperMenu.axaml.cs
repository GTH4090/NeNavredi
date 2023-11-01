using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using static NeNavredi.Classes.Helper;

namespace NeNavredi.Pages;

public partial class BookkeperMenu : UserControl
{
    public BookkeperMenu()
    {
        InitializeComponent();
    }

    

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        NameLb.Content = LoginedUser.Name;
    }

    private void ExitBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Navigationn.Content = new Auth();
        LoginedUser = null;
    }
}