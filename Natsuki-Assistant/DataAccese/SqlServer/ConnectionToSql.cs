using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Common.Cache;



namespace DataAccese
{
    public class ConnectionToSq
    {
        public string connectionString;
        
        public ConnectionToSq() 
        {
            //ETHERNETCONNECT
            connectionString = "server ="+UserLoginCache.Servi+"; DataBase=MyCompany; integrated security = true";
            Common.Cache.UserLoginCache.conexion = connectionString;
            
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
