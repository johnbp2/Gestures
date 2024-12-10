using System;
using System.Diagnostics;
namespace JohnBPearson.Application.Common
{

    /// <summary>
    /// 
    /// "Each assembly has a version number as part of its identity.
    /// As such, two assemblies that differ by version number are considered 
    /// by the runtime to be completely different assemblies. 
    /// This version number is physically represented
    /// as a four-part string with the following format:" 
    /// <code>
    /// <major version>.<minor version>.<build number>.<revision>
    /// </code>
    ///   </summary>
    ///   
    /// 
    ///    <see cref="Learn/Net/Assembly/Versioning"/> 
    /// 

    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public struct SymanticVersion : IEquatable<SymanticVersion>
    {
        /// <summary>
        /// First component in the 
        /// </summary>
        public  int Major;
        public int Minor;
        public int Build;
        public int Revision;
        /// <summary>
        /// full path to the AssemblyInfo.cs file
        /// </summary>
        public string AssemblyInfo;
        public string Settings;

        private string GetDebuggerDisplay()
        {
            return ToString();
        
        }


        public override string ToString()
        {
            return $"{Major}.{Minor}.{Build}.{Revision}-{AssemblyInfo}";
        }

        public override bool Equals(object obj)
        {
            return obj is SymanticVersion version && Equals(version);
        }

        public bool Equals(SymanticVersion other)
        {
            return Major == other.Major &&
                   Minor == other.Minor &&
                   Build == other.Build &&
                   Revision == other.Revision &&
                   AssemblyInfo == other.AssemblyInfo;
        }

        public static bool operator ==(SymanticVersion left, SymanticVersion right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SymanticVersion left, SymanticVersion right)
        {
            return !(left == right);
        }
    }
}
