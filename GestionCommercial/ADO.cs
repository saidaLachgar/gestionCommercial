using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace GestionCommercial
{
    class ADO
    {
        public SqlConnection cn = new SqlConnection(@"Data Source =.\SQLEXPRESS01 ;Initial Catalog = gestcom; Integrated Security = True");
        public SqlDataAdapter da = new SqlDataAdapter();
        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public SqlDataReader dr;
        public SqlCommand cmd;
        public void Open()
        {//cn.ConnectionString = (@"Data Source =.\SQLEXPRESS ;Initial Catalog = gestcom; Integrated Security = True");
            if (cn.State == ConnectionState.Closed || cn.State == ConnectionState.Broken) 
            {              
               cn.Open();
            }
        }
        public void Close()
        {
            if (cn.State == ConnectionState.Open|| cn.State == ConnectionState.Broken)
            {                
                cn.Close();
            }
        }
    }
}
