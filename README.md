# DreamersCode.Utilities.Lookups.Languages

## Introduction 
A .Net lib that offers a lists of all the languages as per ISO-639-2 in a handy lookup mode.

# Getting Started
## How To Use
1. Download the package from NuGet.org (Package name: DreamersCode.Utilities.Lookups.Languages)
2. The static class "LanguageCollection" offers up a property "AllLanguages" which allows you to enumerate through all the languages or filter using LINQ.
    1. **.Net 8**: The list defaults to a FrozenSet that prioritizes read speed for faster queries
    2. **.Net Standard 2.0 & 2.1**: The list defaults to IReadOnlyList    

# Example usage:
```
    var result = LanguageCollection.AllLanguages.SingleOrDefault(x => x.ThreeLetterCode.Equals("MLT", StringComparison.OrdinalIgnoreCase));
    Console.WriteLine($"Lang Name In English {result.LanguageNames.Single(x => x.LanguageCode.Equals("eng", StringComparison.OrdinalIgnoreCase))}");
    Console.WriteLine($"Lang Three Letter Code  {result.ThreeLetterCode}");
```

# Release Notes
## Version 2.0.0 (Rel Date: 16/08/2026)
- Migrated from Azure DevOps to GitHub
- Updated to support Dot Net 10
- Dropped support for Dot Net 4.6.2 (replaced with Dot Net Standard 2.0 instead)

## Version 1.1.3 (Rel Date: 20/01/2025)
- Updated to support Dot Net 9
- Updates related to pipeline fixes due to dot net version upgrade
- Updates due to wrong dates in readme file
 
## Version 1.0.1 (Rel Date: 17/02/2024)
- Fixed Repo URL

## Version 1.0.0 (Rel Date: 15/02/2024)
- Initial Version

# Contribute
Feel free to send any feedback or suggestions to suggestions@dreamerscode.com