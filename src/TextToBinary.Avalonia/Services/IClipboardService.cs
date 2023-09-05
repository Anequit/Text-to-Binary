using System.Threading.Tasks;

namespace TextToBinary.Avalonia.Services;

public interface IClipboardService
{
    public Task SetClipboardAsync(string text);
}