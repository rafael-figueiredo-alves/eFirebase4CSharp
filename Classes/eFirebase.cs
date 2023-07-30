using eFirebase4CSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFirebase4CSharp.Classes
{
    public class eFirebase : IeFirebase
    {
        public static IeFirebase New() { return new eFirebase(); }
        public string GetVersion()
        {
            return "eFirebase - Version 0.0.1-alpha";
        }
    }
}
