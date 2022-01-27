// See https://aka.ms/new-console-template for more information

using Terminal.Gui;
using Watch.Cli;

public static class Program
{
    public static Task<int> Main(params string[] args)
    {
        App.UpdateFrequency = TimeSpan.FromSeconds(1);
        App.Args = args;

        Application.Run<App>();

        return Task.FromResult(0);
    }
}
