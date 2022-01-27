using Terminal.Gui;

namespace Watch.Cli;

public static class Program
{
    public static Task<int> Main(params string[]? args)
    {
        if (args == null)
        {
            throw new ArgumentNullException(nameof(args));
        }

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