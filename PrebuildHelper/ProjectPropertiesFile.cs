
namespace PrebuildHelper
{

    

    internal class ProjectPropertiesFile
    {
        internal ProjectPropertiesFile(string[] lines, PrebuildHelper.ProjectPropertiesFileType file, string fullPath)
        {
        this.FullPath = fullPath;
            this.Lines = lines;
            this.File = file;
        }
        internal string[] Lines
        {
            get; 
        }

        internal PrebuildHelper.ProjectPropertiesFileType File
        {
            get; 
        }
        


        internal string FullPath
        {
            get; 
        }

    }


}
