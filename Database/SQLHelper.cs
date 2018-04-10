using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    class SQLHelper
    {
        public static string ConnectionString
        {
            get
            {
                return "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=LandingPage;Integrated Security=False;Integrated Security = SSPI;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";                
            }
        }
    }
}
