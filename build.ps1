# Clean, restore packages, build
dotnet clean --configuration Release
dotnet restore
dotnet build --configuration Release

# Run tests and exit if there are any errors
dotnet test test/MarkEmbling.Utils.Tests/MarkEmbling.Utils.Tests.csproj --configuration Release
if ($lastExitCode -ne 0) { exit $lastExitCode }

# Publish packages to the NuGet gallery
$files = Get-ChildItem src/MarkEmbling.Utils/bin/Release -Filter *.nupkg
foreach ($file in $files) {
    $choices = @()
    $choices += [Management.Automation.Host.ChoiceDescription]::new("&Publish", "Publish this package to the NuGet gallery")
    $choices += [Management.Automation.Host.ChoiceDescription]::new("&Skip", "Skip this package")
    $answer = $Host.UI.PromptForChoice("Publish Package", "Publish $file to the NuGet gallery?", $choices, 1)
    if ($answer -eq 0) {
        dotnet nuget push $file.FullName --source https://www.nuget.org
    }
}
