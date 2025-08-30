using System;
using System.Globalization;

public class TerminalCommands
{
    private readonly TerminalController _terminal;
    private readonly Rover _rover;

    public TerminalCommands(TerminalController terminal, Rover rover)
    {
        _terminal = terminal;
        _rover = rover;
        _terminal.OnCommandEntered += Handle;
    }

    private void Handle(string line)
    {
        if (string.IsNullOrWhiteSpace(line)) return;

        var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var cmd = parts[0].ToLowerInvariant();
        var args = parts.Length > 1 ? parts[1..] : Array.Empty<string>();

        switch (cmd)
        {
            case "move":
                if (!TryF(args, out float m))
                {
                    _terminal.Print("usage: move <meters>");
                    break;
                }

                _rover.Move(m);
                _terminal.Print("OK");
                break;

            case "turn":
                if (!TryF(args, out float d))
                {
                    _terminal.Print("usage: turn <deg>");
                    break;
                }

                _rover.Turn(d);
                _terminal.Print("OK");
                break;

            // (Optional niceties)
            case "status":
                _terminal.Print(_rover.Status());
                break;

            case "clear":
                _terminal.Clear();
                break;

            case "help":
                _terminal.Print("Commands: move <m>, turn <deg>, status, clear");
                break;

            default:
                _terminal.Print($"Unknown command '{cmd}'. Try 'help'.");
                break;
        }
    }

    private static bool TryF(string[] a, out float v) =>
        float.TryParse(a.Length > 0 ? a[0] : "", NumberStyles.Float, CultureInfo.InvariantCulture, out v);
}