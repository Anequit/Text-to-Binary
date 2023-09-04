using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using TextToBinary.Avalonia.Models;

namespace TextToBinary.Avalonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        Input = "Type into here.";
        Words = new ObservableCollection<Word>();
        
        Convert();
    }

    public string Input { get; set; }
    
    public ObservableCollection<Word> Words { get; set; }

    [RelayCommand]
    private void Convert()
    {
        string[] words = Input.Split(" ");
        
        Words.Clear();

        foreach (string word in words) 
            Words.Add(new Word(word));

        OnPropertyChanged(nameof(Words));
    }
}