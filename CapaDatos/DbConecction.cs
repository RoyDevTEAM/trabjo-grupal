using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//biliotecas agregadas
using System.Data.SqlClient;

namespace CapaDatos
{
    public abstract class DbConecction
    {
        public static string cn = "Server=JOSUE-HS;Database=db_minimercado;Trusted_Connection=True;Integrated Security=True";
        private readonly string connectionString;

        public DbConecction()
        {
            connectionString = cn;
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
