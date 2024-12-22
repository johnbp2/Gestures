using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Application.Common
{

    public class AppendConsole
    {
        public delegate void AppendConsoleText(string text);
        public AppendConsoleText appendConsoleTextDelegate;
    }
   
    public interface IForm
    {
        object Invoke(Delegate method, object[] args);
      //  delegate void appender(string text);

         AppendConsole Appender { get; set; }
        //  public AppendConsoleText appendConsoleTextDelegate(){GetHashCode ;
    }
}
