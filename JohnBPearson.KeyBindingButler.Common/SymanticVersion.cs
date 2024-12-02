using System.Diagnostics;
namespace JohnBPearson.Application.Common
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public struct SymanticVersion
    {
        public  int Major;
        public int Minor;
        public int Build;
        public int Revision;
        public string AssemblyInfo;
        public string Settings;

        private string GetDebuggerDisplay()
        {
            return ToString();
        
        }


        public override string ToString()
        {
            return $"{Major}.{Minor}.{Build}.{Revision}";
        }
    }
}
