using Terminal.Gui;

namespace Watch.Cli;

public sealed class App : Toplevel
{
    public static TimeSpan UpdateFrequency { get; set; }
    public static string[]? Args { get; set; }

    public App()
    {
        if (Args == null)
        {
            throw new ArgumentNullException(nameof(Args));
        }

        var view = new View
        {
            X = 0,
            Y = 1,
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };

        var label = new Label("Output");
        view.Add(label);

        Add(view);

        Application.MainLoop.AddTimeout(UpdateFrequency, _ =>
        {
            using var pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = Args[0];
            pProcess.StartInfo.Arguments = string.Join(" ", Args[1..]); // any additional arguments
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            pProcess.StartInfo.CreateNoWindow = true; //not diplay a windows
            pProcess.Start();
            var output = pProcess.StandardOutput.ReadToEnd(); //The output result
            pProcess.WaitForExit();

            label.Text = output;

            return true;
        });
    }
}