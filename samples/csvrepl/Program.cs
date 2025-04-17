﻿using KustoLoco.Core;
using KustoLoco.Core.Console;
using KustoLoco.Core.Settings;
using KustoLoco.FileFormats;
using Microsoft.VisualBasic;
using NotNullStrings;
using Spectre.Console;
using System.Reflection;
using System.Runtime.CompilerServices;

ShowHelpIfAppropriate();
var settings = new KustoSettingsProvider();
var result = await CsvSerializer.Default(settings,new SystemConsole())
    .LoadTable(args.First(), "data");

if (result.Error.IsNotBlank())
{
    Console.WriteLine(result.Error);
    return;
}

var context = new KustoQueryContext()
     .AddTable(result.Table);

while (true)
{
    Console.Write(">");
    var query = Console.ReadLine().Trim();
    var res = await context.RunQuery(query);
    if (res.Error.IsNotBlank())
    {
        Console.WriteLine(res.Error);
    }
    else
    {
        Console.WriteLine(KustoFormatter.Tabulate(res));
        Console.WriteLine($"{res.QueryDuration}ms");
    }
}


void ShowHelpIfAppropriate()
{
    if (args.Length != 0) return;
    var programName = $"{Assembly.GetExecutingAssembly().GetName().Name}.exe";
    var help = $"""
                This program demonstrates the use of KQL to query a CSV file specified by the user.
                Usage:
                 {programName} c:\temp\mydata.csv
                """;
    AnsiConsole.MarkupLineInterpolated($"[yellow]{help}[/]");
    Environment.Exit(0);
}
