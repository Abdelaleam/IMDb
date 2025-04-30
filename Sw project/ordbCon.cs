using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace Sw_project
{
   public abstract class ordbCon
    {
        protected string ordb = "Data source=orcl;User Id=hr;Password=hr;";
        protected OracleConnection conn;
        protected ordbCon()
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }
        ~ordbCon()
        {
            conn.Dispose();
        }
    }
}
