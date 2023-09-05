using System;
using System.Threading.Tasks;
using Avalonia.Controls;

namespace TextToBinary.Avalonia.Services;

public class ClipboardService : IClipboardService
{
    private readonly Window _window;

    public ClipboardService(Window window)
    {
        _window = window;
    }

    public async Task SetClipboardAsync(string text)
    {
        if (_window.Clipboard is null)
            throw new PlatformNotSupportedException("No Clipboard present.");

        await _window.Clipboard.SetTextAsync(text);
    }
}