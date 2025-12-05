using System.Windows;

namespace SmartPlantBuddy;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new NavigationPage(new Views.LoginPage(MainPage.Services.GetService<SecurePinService>())));
    }
}