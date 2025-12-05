using System.Security.Cryptography;
using System.Text;

namespace SmartPlantBuddy.Services;

public class SecurePinService
{
    private const string PinKey = "app_pin_hash";

    public async Task<bool> IsFirstLaunchAsync()
    {
        var hash = await SecureStorage.Default.GetAsync(PinKey);
        return string.IsNullOrEmpty(hash);
    }

    public async Task SetPinAsync(string pin)
    {
        var hash = ComputeHash(pin);
        await SecureStorage.Default.SetAsync(PinKey, hash);
    }

    public async Task<bool> ValidatePinAsync(string pin)
    {
        var stored = await SecureStorage.Default.GetAsync(PinKey);
        return stored == ComputeHash(pin);
    }

    private string ComputeHash(string input)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(input + "SmartPlantBuddySalt2025");
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}