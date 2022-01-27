# Watch.Cli

A very simple watch-like command line utility written in .NET, using `Terminal.Gui`.

## Testing

```bash
# Inside Watch.Cli folder
dotnet run -- <command>

# Example: Display list of pods, update every second
dotnet run -- 1000 -- kubectl get pods -n default
```

## Building

```bash
# Build for Release
dotnet build -c Release
```

## Installation & Usage

Add the `/bin` directory created from your build to your PATH.

```powershell
# Powershell
$repoPath = "<path-to-repo-root>"
$binPath = (Join-Path $repoPath "Watch.Cli" "bin" "Release", "net6.0")
$env:Path += ";$binPath"
```

```bash
# Bash
REPO_PATH = "<path-to-repo-root>"
BIN_PATH = $REPO_PATH/Watch.Cli/bin/Release/net6.0

export PATH = $BIN_PATH:$PATH
```

Then you should be able to run:

```bash
watch <frequency-in-ms> <command>

# Example: Display list of pods, update every second
watch 1000 -- kubectl get pods -n default
```
