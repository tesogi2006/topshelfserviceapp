using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace WindowServiceApp.Configs
{
    public class MyAppInfo : IAppInfo
    {
        public Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
