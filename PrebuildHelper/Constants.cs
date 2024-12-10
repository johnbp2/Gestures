namespace PrebuildHelper
{

    internal static class Constants
    {

        internal static string searchString1 = @"[assembly: AssemblyVersion(";
        internal static string searchString2 = @"[assembly: AssemblyFileVersion(";
        internal static string[] fileNames = { "AssemblyInfo.cs", "Settings.settings" };
    }

    internal enum ProjectPropertiesFileType
    {
        AssemblyInfo = 0,
        Settings = 1
    } 
}