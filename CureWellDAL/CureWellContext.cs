using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CureWellDAL
{
    public class CureWellContext
    {
        private SqlConnection con;

        public SqlConnection Connection
        {
            get
            {
                con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=CureWell;Integrated Security=True;TrustServerCertificate=True");
                return con;
            }
        }
    }
}