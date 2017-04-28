MarkEmbling.Utilities
=====================

A collection of common extension methods, helpers and other frequently used code. This package serves to keep them all together and allows easy re-use and versioning across projects.

This package is [available on NuGet](https://www.nuget.org/packages/MarkEmbling.Utilities/).

Tests based on [xUnit](https://xunit.github.io/) can be found in the `test/MarkEmbling.Utilities.Tests` project.

This package replaces the previous `MarkEmbling.Utils` package and targets .NET Standard 1.1. As well as the extension methods and helpers which are provided in this package, `MarkEmbling.Utils` used to contain the following:

 - Features for pluralising words and so on - these have now moved to [`MarkEmbling.Grammar`](https://github.com/markembling/MarkEmbling.Grammar) where they will continue to be developed and maintained, targetting .NET Standard.
 - Windows Forms controls - these were wrapped up in the `MarkEmbling.Utils` solution and published to the [`MarkEmbling.Utils.Forms` NuGet package](https://www.nuget.org/packages/MarkEmbling.Utils.Forms/). I'll be finding an appropriate place to put these in due course but I'm not expecting to do that much development to them going forward.
 