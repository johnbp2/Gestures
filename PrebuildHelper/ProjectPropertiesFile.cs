
namespace PrebuildHelper
{

    internal class ProjectPropertiesFile
    {
        internal ProjectPropertiesFile(string[] lines, PrebuildHelper.file file, string fullPath)
        {
        this.FullPath = fullPath;
            this.Lines = lines;
            this.File = file;
        }
        internal string[] Lines
        {
            get; 
        }

        internal file File
        {
            get; 
        }
        

        internal string FullPath
        {
            get; 
        }

    }


}
