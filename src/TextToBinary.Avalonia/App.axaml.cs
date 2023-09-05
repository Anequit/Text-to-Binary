using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using TextToBinary.Avalonia.Services;
using TextToBinary.Avalonia.ViewModels;
using TextToBinary.Avalonia.Views;
using Microsoft.Extensions.DependencyInjection;

namespace TextToBinary.Avalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);

            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };

            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<IClipboardService>(x => new ClipboardService(desktop.MainWindow));

            Services = services.BuildServiceProvider();
        }

        base.OnFrameworkInitializationCompleted();
    }

    public new static App? Current => Application.Current as App;

    public IServiceProvider? Services { get; private set; }
}