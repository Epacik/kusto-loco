﻿using CommandLine;

namespace Lokql.Engine.Commands;

/// <summary>
/// Retrieves a named result
/// </summary>
public static class PullCommand
{
    internal static async Task RunAsync(CommandProcessorContext econtext, Options o)
    {
        var exp = econtext.Explorer;
        var res = exp._resultHistory.Fetch(o.Name);
        await exp.InjectResult(res);
    }

    [Verb("pull",  HelpText = "retrieves a stored result and displays it")]
    internal class Options
    {
        [Value(0, HelpText = "Name", Required = true)]
        public string Name { get; set; } = string.Empty;
    }
}
