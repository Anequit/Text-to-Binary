using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using TextToBinary.Avalonia.Converters;
using TextToBinary.Avalonia.Services;

namespace TextToBinary.Avalonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly BinaryConverter _binaryConverter; 
    
    public MainWindowViewModel()
    {
        Input = "Type into here.";
        Words = new ObservableCollection<string>();

        _binaryConverter = new BinaryConverter();
        
        Convert();
    }

    public string Input { get; set; }
    
    public ObservableCollection<string> Words { get; set; }

    [RelayCommand]
    private void Convert()
    {
        Words.Clear();

        foreach (string word in Input.Split(' ')) 
            Words.Add(word);

        OnPropertyChanged(nameof(Words));
    }

    [RelayCommand]
    private async Task CopyBinary()
    {
        IClipboardService? clipboardService = App.Current?.Services?.GetService<IClipboardService>();

        if (clipboardService == null)
            throw new NoNullAllowedException("Missing clipboard service");

        string binary = _binaryConverter.Convert(Input, typeof(string), null, CultureInfo.CurrentCulture) as string ??
                        string.Empty;
        
        await clipboardService.SetClipboardAsync(binary);
    }
}