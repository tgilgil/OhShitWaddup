using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listener
{
    class OhShitWaddupDetector
    {
        private const string OhShitWaddup = "DAT BOI";

        public bool IsWorthyOhShitWaddup(string stringToCheck)
        {
            return stringToCheck.ToUpper().Contains(OhShitWaddup);
        }
    }
}
