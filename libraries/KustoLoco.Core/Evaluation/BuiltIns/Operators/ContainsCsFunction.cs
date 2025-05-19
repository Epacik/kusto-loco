﻿using System;

// ReSharper disable PartialTypeWithSinglePart
namespace KustoLoco.Core.Evaluation.BuiltIns.Impl;

[KustoImplementation(Keyword = "Operators.ContainsCs")]
internal partial class ContainsCsFunction
{
    private static bool Impl(string a, string b) => a.Contains(b, StringComparison.InvariantCulture);
}


[KustoImplementation(Keyword = "Operators.HasCs")]
internal partial class HasCsFunction
{
    private static bool Impl(string a, string b) => a.Contains(b, StringComparison.InvariantCulture);
}
