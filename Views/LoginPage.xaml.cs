using Microsoft.Maui;
using SmartPlantBuddy.Services;

namespace SmartPlantBuddy.Views;

public partial class LoginPage : ContentPage
{
    private readonly SecurePinService _pinService;
    private bool _isFirstLaunch;

    public LoginPage(SecurePinService pinService)
    {
        InitializeComponent();
        _pinService = pinService;
        CheckLaunchState();
    }

    private async void CheckLaunchState()
    {
        _isFirstLaunch = await _pinService.IsFirstLaunchAsync();
        InstructionLabel.Text = _isFirstLaunch ? "Set your 4-digit PIN" : "Enter your PIN";
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        var pin = PinEntry.Text;
        if (string.IsNullOrWhiteSpace(pin) || pin.Length != 4 || !pin.All(char.IsDigit))
        {
            ErrorLabel.Text = "Please enter a valid 4-digit PIN";
            ErrorLabel.IsVisible = true;
            return;
        }

        bool success;
        if (_isFirstLaunch)
        {
            await _pinService.SetPinAsync(pin);
            success = true;
        }
        else
        {
            success = await _pinService.ValidatePinAsync(pin);
        }

        if (success)
        {
            Application.Current.MainPage = new AppShell();
        }
        else
        {
            ErrorLabel.Text = "Incorrect PIN";
            ErrorLabel.IsVisible = true;
        }
    }
}