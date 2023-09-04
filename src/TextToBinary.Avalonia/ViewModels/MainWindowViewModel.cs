using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.Input;
using TextToBinary.Avalonia.Converters;

namespace TextToBinary.Avalonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        Input = "Type into here.";
        Words = new ObservableCollection<string>();
        
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
}