using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lim_Circus.ADO;

namespace Lim_Circus.Data
{
    public static class DBConnection
    {
        public static Lim_CircusEntities connection = new Lim_CircusEntities();
    }
}
