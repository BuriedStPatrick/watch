// See https://aka.ms/new-console-template for more information

using Terminal.Gui;
using Watch.Cli;

public static class Program
{
    public static Task<int> Main(params string[] args)
    {
        var splitter = Array.IndexOf(args, "--");
        var watchArgs = args[..splitter];
        var frequency = double.TryParse(watchArgs[0], out var parsed)
            ? parsed
            : 1000;

        App.UpdateFrequency = TimeSpan.FromMilliseconds(frequency);
        App.Args = args[(splitter+1)..];

        Application.Run<App>();

        return Task.FromResult(0);
    }
}
